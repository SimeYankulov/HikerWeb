using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace HikerWeb.Web.Pages.Activities
{
    public class ActivityDetailsBase : ComponentBase
    {
        //[Inject]
        //public IJSRuntime jSRuntime { get; set; }
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IActivityService ActivityService { get; set; }
        public ResponseActivityInfoDto Activity { get; set; }
        [Inject]
        public IUserActivityService userActivityService { get; set; }
        [Inject]
        public IUserService userService { get; set; }
        public IEnumerable<ResponseUserDto> Users { get; set; }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Activity = await ActivityService.GetItem(Id);
                Users = await userActivityService.GetUsersForActivity(Id);

                if(Users.Count() > 0)
                {

                }
            }
            catch (Exception)
            {
                
            }
        }

        protected async Task RemoveUser()
        {
            try
            {
                var res = await userActivityService.DeleteItem(LoggedIn.UserId,Id);

                if (res)
                {
                    var user = Users.FirstOrDefault(user => user.Id == LoggedIn.UserId);
                    if(user != null)
                    {
                        Users = Users.Where(user => user.Id != LoggedIn.UserId).ToList();
                    }
                }

                

            }
            catch(Exception){

            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //await jSRuntime.InvokeVoidAsync("initMap", null);
            }
        }
        protected async Task AddUser()
        {
            try
            { 

                var result = await this.userActivityService.AddItem(LoggedIn.UserId, Activity.Id);

                if(result != null)
                {
                    Users = await userActivityService.GetUsersForActivity(Id);
                }
                //Users = await userActivityService.GetUsersForActivity(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
