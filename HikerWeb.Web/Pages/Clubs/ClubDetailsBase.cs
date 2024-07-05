using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ClubDtos;
using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages
{
    public class ClubDetailsBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IClubService ClubService { get; set; }
        [Inject]
        public IActivityService ActivityService { get; set; }
        [Inject]
        public IUserService UserService { get; set; }  
        public ResponseUserInfoDto User { get; set; }
        public ResponseClubInfoDto Club { get; set; }

        public IEnumerable<ResponseUserDto> Members { get; set; }
        public IEnumerable<ResponseActivityDto> Activities { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                
                User = await UserService.GetUser(LoggedIn.UserId);
                Club = await  ClubService.GetItem(Id);
                Members = await UserService.GetClubMembers(Club.Id);
                Activities = await ActivityService.GetItemsByClub(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async Task UpdateUserClub()
        {
            var result = await UserService.UpdateUsersClub(User.Id,Club.Id);
            if (result == true)
            {
                NavigationManager.NavigateTo("/Club/" + Club.Id);
            }
        }


    }
}
