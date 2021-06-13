using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonMaster.Hubs
{
    public class DungeonMasterHub : Hub
    {
        public async Task SendMessage(string message, string page)
        {
            await Clients.All.SendAsync("MessageReceived", message, page);
        }
    }
}
