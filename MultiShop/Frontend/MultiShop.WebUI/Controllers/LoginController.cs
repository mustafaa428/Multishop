using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityservice _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, IIdentityservice identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SıgnIn(signInDto);
            return RedirectToAction("Index", "Default");
        }


        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "ali123";
            signInDto.Password = "Arslan159357.";
            await _identityService.SıgnIn(signInDto);
            return RedirectToAction("Index", "User");
        }
    }
}
