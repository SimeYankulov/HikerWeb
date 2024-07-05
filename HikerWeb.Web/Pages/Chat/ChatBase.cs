using HikerWeb.Models.DTOs;
using HikerWeb.Models.DTOs.UserDtos;

using HikerWeb.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;


namespace HikerWeb.Web.Pages.Chat
{
    public class ChatBase : ComponentBase
    {
        [Inject]
        public NavigationManager Navigation{ get; set; }
        [Parameter]
        public int ToUserId { get; set; }
        public ResponseUserInfoDto ToUser { get; set; } = new ResponseUserInfoDto();
        public int FromUserId { get; set; } = LoggedIn.UserId;
        public string MessageText { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        private HubConnection hubConnection;



        [Inject]
        public IUserService UserService { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            Message message = new Message() { ToUserId = 10, FromUserId = 1, MessageText = "Hey wanna go to Musala Peak with Kozuf?" };
            Message message2 = new Message() { ToUserId = 1, FromUserId = 10, MessageText = "Sure, when are they going ?" };
            Messages.Add(message);
            Messages.Add(message2);

            ToUser = await this.UserService.GetUser(ToUserId);

            hubConnection = new HubConnectionBuilder().
                                WithUrl("https://localhost:7192/chathub")
                                .Build();

            hubConnection.On<Message>("ReceiveMessage", (message) =>
            {

                Messages.Add(message);
                StateHasChanged();
            });
        
            await hubConnection.StartAsync();
            
           
        }
        public async Task Send()
        {
            Message message = new Message();
            message.ToUserId = ToUserId;
            message.FromUserId = FromUserId;
            message.MessageText = MessageText;

            Messages.Add(message);
            StateHasChanged();
            await hubConnection.SendAsync("SendMessage", message);
        }

    }
}
