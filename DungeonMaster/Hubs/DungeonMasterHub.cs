using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DungeonMaster.Hubs
{
    /// <summary>
    /// Hub used to send and receive messages from Clients.
    /// Based upon the Microsoft SignalR Tutorial.
    /// </summary>
    public class DungeonMasterHub : Hub
    {
        /// <summary>
        /// Asynchronously Send messages to all connected clients.
        /// Based upon the Microsoft SignalR tutorial.
        /// </summary>
        /// <param name="message">Message to be sent to all clients.</param>
        /// <param name="page">Page which the message applies to.</param>
        /// <returns></returns>
        public async Task SendMessage(string message, string page)
        {
            await Clients.All.SendAsync("MessageReceived", message, page);
        }
    }
}
