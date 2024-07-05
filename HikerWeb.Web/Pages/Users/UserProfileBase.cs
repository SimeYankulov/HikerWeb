using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages
{
    public class UserProfileBase:ComponentBase
    {

        [Parameter]
        public int Id { get; set; }
        public ResponseUserInfoDto User { get; set; } 
        [Inject]
        public IUserService userService { get; set; }
        public IEnumerable<ResponseActivityShortDto> Activities { get; set; }
        [Inject]
        public IUserActivityService userActivityService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            { 
                User = await userService.GetUser(Id);
                Activities = await userActivityService.GetActivitiesForUser(Id);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
        protected async Task NavigateToUpdate()
        {
             NavigationManager.NavigateTo("/User/Update/" + User.Id);
        }
    }
}
