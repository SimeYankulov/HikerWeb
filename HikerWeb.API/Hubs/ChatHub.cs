using HikerWeb.Models.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace HikerWeb.API.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Message message)
        {
            var users = new string[] { message.ToUserId.ToString(), message.FromUserId.ToString() };
            await Clients.Users(users).SendAsync("Receive Message", message);
        }
    }
}
