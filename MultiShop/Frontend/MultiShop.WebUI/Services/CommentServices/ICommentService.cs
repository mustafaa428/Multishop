using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetCommentsAsync();
        Task<UpdateCommentDto> GetCommentByIdAsync(string id);
        Task AddCommentAsync(CreateCommentDto comment);
        Task UpdateCommentAsync(UpdateCommentDto comment);
        Task<List<ResultCommentDto>> GetCommentByProductIdAsync(string productId);
    }
}
