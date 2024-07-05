using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HikerWeb.Web.Pages
{

    public class LoginBase:ComponentBase
    {

        public LoginDto userCredentials = new LoginDto();
        [Inject]
        public IUserService userService { get; set; }

        public string ErrorMessage = "";


        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
       
        public async Task<LoginDto> LoginUser()
        {
            var result = await userService.Login(userCredentials);

            var claim = new Claim(ClaimTypes.Email, result.Email);

            var claimsIdentity = new ClaimsIdentity(
              new[] { claim }, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            new AuthenticationState(claimsPrincipal);

            LoggedIn.UserId = result.Id;

            return result;
        }
    }
}
