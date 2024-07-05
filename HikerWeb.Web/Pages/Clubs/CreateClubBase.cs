using HikerWeb.Models.DTOs.ClubDtos;
using HikerWeb.Web.Services;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HikerWeb.Web.Pages
{
    public class CreateClubBase:ComponentBase
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        public IClubService ClubService { get; set; }

        public UpdateClubDto Club = new UpdateClubDto();

        protected async Task HandleValidSubmit()
        {
            var result = await ClubService.CreateItem(Club);
            if (result != null)
            {
                NavigationManager.NavigateTo("/ClubDetails/" + result.Id);
            }

        }
        public async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            var fileFormat = "image/png";

            var imageFile = await inputFileChangeEventArgs.File.RequestImageFileAsync(fileFormat, 250, 250);

            var buffer = new byte[imageFile.Size];

            await imageFile.OpenReadStream(1512000).ReadAsync(buffer);

            Club.LogoUrl = $"data:{fileFormat};base64,{Convert.ToBase64String(buffer)}";
        }

    }
     
}
