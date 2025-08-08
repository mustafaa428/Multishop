using System.Security.Claims;

namespace MultiShop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null)
                    return null;

                // Öncelikle sub claim'i dene
                var subClaim = user.FindFirst("sub");
                if (subClaim != null)
                    return subClaim.Value;

                // sub yoksa NameIdentifier claim'ini dene
                var nameIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (nameIdClaim != null)
                    return nameIdClaim.Value;

                // Claim yoksa null dönebilir veya hata atabilirsin
                return null;
            }
        }

    }
}
