using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages
{
    public class ContactsBase : ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        public IEnumerable<ResponseUserDto> Users { get; set; } = new List<ResponseUserDto>();
        public IEnumerable<ResponseUserDto> FilteredUsers { get; set; } = new List<ResponseUserDto>();

        protected async override Task OnInitializedAsync()
        {
            Users = await UserService.GetItems(LoggedIn.UserId);
            FilteredUsers = Users;
        }
        public async void UpdateFilteredUsers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                FilteredUsers = Users;
            }
            else
            {
                FilteredUsers = Users.Where(c => c.FName.Contains
                                            (searchTerm, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
