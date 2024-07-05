using Blazored.SessionStorage;
using HikerWeb.Web.Services;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace HikerWeb.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();


            builder.Services.AddTransient(sp =>
                    new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7192/") });

            builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IClubService, ClubService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserActivityService, UserActivityService>();

            builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();
            builder.Services.AddBlazoredSessionStorage();

            await builder.Build().RunAsync();
        }
    }
}