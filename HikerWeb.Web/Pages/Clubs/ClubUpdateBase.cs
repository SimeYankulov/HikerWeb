using HikerWeb.Models.DTOs.ClubDtos;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HikerWeb.Web.Pages
{
    public class ClubUpdateBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IClubService ClubService { get; set; }
        public UpdateClubDto Club { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Club = await ClubService.GetItemToUpdate(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async Task HandleValidSubmit()
        {
            var result = await ClubService.UpdateItem(Club);
            if (result != null)
            {
                NavigationManager.NavigateTo("/ClubDetails/" + Club.Id);
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
