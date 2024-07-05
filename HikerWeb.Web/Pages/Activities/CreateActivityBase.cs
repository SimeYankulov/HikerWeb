using Blazored.SessionStorage;
using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Models.DTOs.ActivityDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace HikerWeb.Web.Pages
{
    public class CreateActivityBase:ComponentBase
    {
        [Inject]
        ISessionStorageService sessionStorage { get; set; }
        [Inject]
        IJSRuntime IJsRuntime { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        IActivityService ActivityService { get; set; }
        public AddActivityDto Activity { get; set; } = new AddActivityDto();
        public IEnumerable<ActivityTypeDto> Types { get; set; } = new List<ActivityTypeDto>();

        protected override async Task OnInitializedAsync()
        {
            Types = await this.ActivityService.GetItemsType();
        }
        public async void HandleValidSubmit()
        {
            var storage = await sessionStorage.GetItemAsync<string>("info");

            if (storage != null)
            {
                var data = storage.Split(separator: ',', StringSplitOptions.None);
                Activity.Latitude = data[0];
                Activity.Longitude = data[1];
                Activity.Place = data[2];
                Activity.ClubId = LoggedIn.ClubId;

                if(Activity != null)
                {

                }
                var result = await ActivityService.CreateItem(Activity);
                if (result != null)
                {
                    NavigationManager.NavigateTo("/Activity/" + result.Id);
                }
            }
        }

        public async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            var fileFormat = "image/png";

            var imageFile = await inputFileChangeEventArgs.File.RequestImageFileAsync(fileFormat, 250, 250);

            var buffer = new byte[imageFile.Size];

            await imageFile.OpenReadStream(1512000).ReadAsync(buffer);

            Activity.ImageLink= $"data:{fileFormat};base64,{Convert.ToBase64String(buffer)}";
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await IJsRuntime.InvokeVoidAsync("initMap", null);
            }
        }

    }
}
