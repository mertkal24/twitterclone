using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ChatApp:Hub
    {
        public Task SendMessagetoGroup(string message,string username, string roomName )
        {
            return Clients.Group(roomName).SendAsync("ReceiveMessage",username+": "+ message);
        }
        public Task JoinGroup(string roomName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
