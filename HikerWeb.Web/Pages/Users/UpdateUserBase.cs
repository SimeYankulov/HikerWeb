using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HikerWeb.Web.Pages
{
    public class UpdateUserBase:ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public UpdateUserDto User { get; set; } = new UpdateUserDto();
        [Inject]
        public IUserService userService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                User = await userService.GetItemToUpdate(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async Task HandleValidSubmit()
        {
            var result = await userService.UpdateItem(User);
            if (result != null)
            {
                NavigationManager.NavigateTo("/User/" + User.Id);
            }

        }
        public async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            var fileFormat = "image/png";

            var imageFile = await inputFileChangeEventArgs.File.RequestImageFileAsync(fileFormat, 250, 250);

            var buffer = new byte[imageFile.Size];

            await imageFile.OpenReadStream(1512000).ReadAsync(buffer);

            User.ProfilePicture = $"data:{fileFormat};base64,{Convert.ToBase64String(buffer)}";
        }

    }
}
