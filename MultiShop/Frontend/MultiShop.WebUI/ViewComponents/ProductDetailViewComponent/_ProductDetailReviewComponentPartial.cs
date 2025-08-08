using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponent
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailReviewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.GetCommentByProductIdAsync(id);
            return View(values);

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage =await client.GetAsync("http://localhost:7025/api/Comments/CommentListByProductId?id="+id);
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            //    return View(values);
            //}
            //return View();
        }
    }
}
