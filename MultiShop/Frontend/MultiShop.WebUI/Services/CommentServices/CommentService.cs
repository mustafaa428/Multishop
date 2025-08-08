using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> GetCommentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");
        }

        public async Task<UpdateCommentDto> GetCommentByIdAsync(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<UpdateCommentDto>($"Comments/{id}");
            return response;
        }

        public async Task AddCommentAsync(CreateCommentDto comment)
        {
            var response = await _httpClient.PostAsJsonAsync("Comments", comment);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCommentAsync(UpdateCommentDto comment)
        {
            await _httpClient.PutAsJsonAsync("Comments", comment);
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>($"Comments/CommentListByProductId?id=" + id);
            return response;
        }
    }
}
