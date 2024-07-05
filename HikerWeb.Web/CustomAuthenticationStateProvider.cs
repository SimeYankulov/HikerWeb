using HikerWeb.Models.DTOs.UserDtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace HikerWeb.Web
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ResponseUserDto user = await httpClient.GetFromJsonAsync<ResponseUserDto>("/User/GetCurrentUser");

            if (user != null && user.FName != null)
            {
                var claim = new Claim(ClaimTypes.Name, user.FName);

                var claimsIdentity = new ClaimsIdentity(
                  new[] { claim }, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
