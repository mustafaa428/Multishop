using IdentityModel.Client;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using MultiShop.WebUI.Globals;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using System.Text.Json;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _distributedCache;
        private const string CacheKey = "multishoptoken";

        public ClientCredentialTokenService(
            IOptions<ServiceApiSettings> serviceApiSettings,
            IOptions<ClientSettings> clientSettings,
            HttpClient httpClient,
            IDistributedCache distributedCache)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
            _httpClient = httpClient;
            _distributedCache = distributedCache;
        }

        public async Task<string> GetToken()
        {
            // Önce Redis'ten kontrol et
            var cachedTokenJson = await _distributedCache.GetStringAsync(CacheKey);
            if (!string.IsNullOrEmpty(cachedTokenJson))
            {
                var cachedToken = JsonSerializer.Deserialize<CachedToken>(cachedTokenJson);
                if (cachedToken != null && cachedToken.ExpiresAt > DateTime.UtcNow)
                {
                    return cachedToken.AccessToken;
                }
            }

            // Token yok veya süresi geçmiş, IdentityServer'dan al
            var discovery = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            if (discovery.IsError)
                throw new Exception($"Discovery error: {discovery.Error}");

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discovery.TokenEndpoint,
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
            });


            if (tokenResponse.IsError)
                throw new Exception($"Token request error: {tokenResponse.Error}");

            // Token süresi baz alınarak cache objesi oluştur
            var expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn - 60); // 60 saniye güvenlik payı

            var newCachedToken = new CachedToken
            {
                AccessToken = tokenResponse.AccessToken,
                ExpiresAt = expiresAt
            };

            var jsonToCache = JsonSerializer.Serialize(newCachedToken);

            // Redis'te cache'le (Expiration süresini token süresine göre ayarla)
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = expiresAt,
                SlidingExpiration = TimeSpan.FromMinutes(5)// Son erişimden sonra 5 dk içinde tekrar erişilmezse silinsin
            };

            await _distributedCache.SetStringAsync(CacheKey, jsonToCache, options);


            return tokenResponse.AccessToken;
        }


    }
}
