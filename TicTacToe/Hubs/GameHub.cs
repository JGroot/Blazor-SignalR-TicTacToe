using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.Data;
using TicTacToe.Extensions;

namespace TicTacToe.Hubs
{
    public class GameHub : Hub
    {
        readonly GameModelService _service = new GameModelService();
        const string O = "O";
        const string X = "X";

        public async Task NewHumanGame(GameModel gamesettings)
        {
            gamesettings = await _service.GetHumanGameBoardAsync();
            await Clients.All.SendAsync(ClientEndpoints.NewHumanGame, gamesettings);
        }

        public async Task NewBotGame(GameModel gamesettings)
        {
            gamesettings = await _service.GetBotGameBoardAsync();
            await Clients.All.SendAsync(ClientEndpoints.NewBotGame, gamesettings);
        }

        public async Task SendMessage(GameModel gamesettings)
        {
            await Clients.All.SendAsync(ClientEndpoints.ReceiveMessage, gamesettings);
        }

        public async Task TakePlayerTurn(int i, GameModel gamesettings)
        { 
            if (gamesettings.PlayerXTurn)
            {
                gamesettings.Game[i] = X;
            }
            else if (gamesettings.PlayerOTurn)
            {
                gamesettings.Game[i] = O;
            }
            await EndPlayerTurn(gamesettings);
        }


        private async Task EndPlayerTurn(GameModel gamesettings)
        {
            await HandleGameOver(gamesettings);
            if (!gamesettings.Gameover)
            {
                gamesettings.TurnCount++;
                gamesettings.PlayerXTurn = !gamesettings.PlayerXTurn;
                gamesettings.PlayerOTurn = !gamesettings.PlayerOTurn;
                if (gamesettings.Botgame)
                    gamesettings.Botturn = !gamesettings.Botturn;
                await Clients.All.SendAsync(ClientEndpoints.EndTurn, gamesettings);
            }
        }

        public async Task TakeBotTurn(GameModel gamesettings)
        {
            var rng = new Random();
            Thread.Sleep(rng.Next(100, 3000));

            // 0 1 2
            // 3 4 5
            // 6 7 8
            bool shouldSetMiddle = string.IsNullOrEmpty(gamesettings.Game[4]) || gamesettings.Game.ShouldSetMiddle();
            if (shouldSetMiddle)
            {
                gamesettings.Game[4] = O;
            }
            else if (gamesettings.Game.ShouldSetUpperLeft())
                gamesettings.Game[0] = O;
            else if (gamesettings.Game.ShouldSetUpperMiddle())
                gamesettings.Game[1] = O;
            else if (gamesettings.Game.ShouldSetUpperRight())
                gamesettings.Game[2] = O;
            else if (gamesettings.Game.ShouldSetLeftMiddle())
                gamesettings.Game[3] = O;
            else if (gamesettings.Game.ShouldSetRightMiddle())
                gamesettings.Game[5] = O;
            else if (gamesettings.Game.ShouldSetLowerLeft())
                gamesettings.Game[6] = O;
            else if (gamesettings.Game.ShouldSetLowerMiddle())
                gamesettings.Game[7] = O;
            else if (gamesettings.Game.ShouldSetLowerRight())
                gamesettings.Game[8] = O;
            else
            {
                var randomEmpty = Array.IndexOf(gamesettings.Game, string.Empty, rng.Next(0, 8));
                gamesettings.Game[randomEmpty] = O;
            }

            await EndPlayerTurn(gamesettings);
        }


        private async Task HandleGameOver(GameModel gamesettings)
        {
            if (gamesettings.Game.XWins())
            {
                gamesettings.PlayerXWins = new MarkupString("<strong>Game Over:</strong> Player X has won the game!");
                gamesettings.XWon = true;
                gamesettings.Gameover = true;
            }
            else if (gamesettings.Game.OWins())
            {
                gamesettings.PlayerOWins = new MarkupString("<strong>Game Over:</strong> Player O has won the game!");
                gamesettings.OWon = true;
                gamesettings.Gameover = true;
            }
            else if (gamesettings.Game.CatGame())
            {
                gamesettings.PlayerCatGame = new MarkupString("<strong>Game Over:</strong> Cat game! Everyone wins!");
                gamesettings.CatGame = true;
                gamesettings.Gameover = true;
            }

            if (gamesettings.Gameover)
            {
                gamesettings.PlayerXTurn = false;
                gamesettings.PlayerOTurn = false;
                gamesettings.Botturn = false;
                await Clients.All.SendAsync("GameOver", gamesettings);
            }              
        }
    }
}
