using HikerWeb.Models.DTOs.UserDtos;
using HikerWeb.Web.Services;
using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HikerWeb.Web.Pages
{
    public class CreateUserBase:ComponentBase
    {
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public UpdateUserDto User = new UpdateUserDto();
        
        public string ErrorMessage { get;set; }
        protected async Task HandleValidSubmit()
        {
            var result = await UserService.CreateItem(User);
            if (result != null)
            {
                NavigationManager.NavigateTo("/User/" + result.Id);
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
