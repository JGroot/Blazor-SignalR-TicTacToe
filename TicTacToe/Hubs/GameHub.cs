using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TicTacToe.Data;

namespace TicTacToe.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendMessage(GameModel gamesettings)
        {
            await Clients.All.SendAsync("ReceiveMessage", gamesettings);
        }
    }
}
