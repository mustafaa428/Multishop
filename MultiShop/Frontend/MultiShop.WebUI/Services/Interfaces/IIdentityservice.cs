using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityservice
    {
        Task<bool> SıgnIn(SignInDto signupDto);
        Task<bool> GetRefserhToken();
    }
}
