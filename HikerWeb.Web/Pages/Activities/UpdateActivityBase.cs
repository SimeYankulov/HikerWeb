using HikerWeb.Models.DTOs.Activity;
using HikerWeb.Web.Services;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;

namespace HikerWeb.Web.Pages.Activities
{
    public class UpdateActivityBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IActivityService ActivityService { get; set; }
        public UpdateActivityDto Activity { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            { 
                Activity = await ActivityService.GetItemToUpdate(Id);
            }
            catch (Exception)
            {
                
            }
        }

        protected async Task HandleValidSubmit()
        {
            var result = await ActivityService.UpdateItem(Activity);
            if (result != null)
            {
                NavigationManager.NavigateTo("/Activity/" + Activity.Id);
            }

        }
        public async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            var fileFormat = "image/png";

            var imageFile = await inputFileChangeEventArgs.File.RequestImageFileAsync(fileFormat, 1500, 900);

            var buffer = new byte[imageFile.Size];

            await imageFile.OpenReadStream(1512000).ReadAsync(buffer);

            Activity.ImageLink = $"data:{fileFormat};base64,{Convert.ToBase64String(buffer)}";
        }
    }

}
