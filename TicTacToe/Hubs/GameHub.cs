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

        private static GameModel _gamesettings = new GameModel();
        readonly GameModelService _service = new GameModelService();
       // private HubConnection _hubConnection;
        const string O = "O";
        const string X = "X";

        public GameHub()
        {

        }

        //public async Task PlayerTurn(int location)
        //{
        //    if (gamesettings.IsValidLocation(location))
        //        gamesettings.ApplyXorO(location);

        //    await Clients.All.SendAsync("ReceiveMessage", gamesettings);
        //}

        public async Task NewHumanGame()
        {
            _gamesettings = await _service.GetHumanGameBoardAsync();
            await Clients.All.SendAsync(ClientEndpoints.NewHumanGame, _gamesettings);

        }

        public async Task NewBotGame()
        {
            _gamesettings = await _service.GetBotGameBoardAsync();
            await Clients.All.SendAsync(ClientEndpoints.NewBotGame, _gamesettings);
        }

        public async Task SendMessage(GameModel gamesettings)
        {
            await Clients.All.SendAsync(ClientEndpoints.ReceiveMessage, gamesettings);
        }

        public async Task TakePlayerTurn(int i)
        {
            if (_gamesettings.PlayerXTurn)
            {
                _gamesettings.Game[i] = X;
            }
            else if (_gamesettings.PlayerOTurn)
            {
                _gamesettings.Game[i] = O;
            }
            await HandleGameOver();

            EndPlayerTurn();
            await Clients.All.SendAsync(ClientEndpoints.NextTurn, _gamesettings);
        }


        public void EndPlayerTurn()
        {
            _gamesettings.TurnCount++;
            _gamesettings.PlayerXTurn = !_gamesettings.PlayerXTurn;
            _gamesettings.PlayerOTurn = !_gamesettings.PlayerOTurn;
            _gamesettings.Botturn = !_gamesettings.Botturn;
        }

        public void TakeBotTurn()
        {
            var rng = new Random();
            Thread.Sleep(rng.Next(100, 3000));

            // 0 1 2
            // 3 4 5
            // 6 7 8
            bool shouldSetMiddle = string.IsNullOrEmpty(_gamesettings.Game[4]) || _gamesettings.Game.ShouldSetMiddle();
            if (shouldSetMiddle)
            {
                _gamesettings.Game[4] = O;
            }
            else if (_gamesettings.Game.ShouldSetUpperLeft())
                _gamesettings.Game[0] = O;
            else if (_gamesettings.Game.ShouldSetUpperMiddle())
                _gamesettings.Game[1] = O;
            else if (_gamesettings.Game.ShouldSetUpperRight())
                _gamesettings.Game[2] = O;
            else if (_gamesettings.Game.ShouldSetLeftMiddle())
                _gamesettings.Game[3] = O;
            else if (_gamesettings.Game.ShouldSetRightMiddle())
                _gamesettings.Game[5] = O;
            else if (_gamesettings.Game.ShouldSetLowerLeft())
                _gamesettings.Game[6] = O;
            else if (_gamesettings.Game.ShouldSetLowerMiddle())
                _gamesettings.Game[7] = O;
            else if (_gamesettings.Game.ShouldSetLowerRight())
                _gamesettings.Game[8] = O;
            else
            {
                var randomEmpty = Array.IndexOf(_gamesettings.Game, string.Empty, rng.Next(0, 8));
                _gamesettings.Game[randomEmpty] = O;
            }

            
            EndPlayerTurn();
        }


        public async Task HandleGameOver()
        {
            if (_gamesettings.Game.XWins())
            {
                _gamesettings.PlayerXWins = new MarkupString("<strong>Game Over:</strong> Player X has won the game!");
                _gamesettings.Gameover = true;
            }
            else if (_gamesettings.Game.OWins())
            {
                _gamesettings.PlayerOWins = new MarkupString("<strong>Game Over:</strong> Player O has won the game!");
                _gamesettings.Gameover = true;
            }
            else if (_gamesettings.Game.CatGame())
            {
                _gamesettings.PlayerCatGame = new MarkupString("<strong>Game Over:</strong> Cat game! Everyone wins!");
                _gamesettings.Gameover = true;
            }

            if (_gamesettings.Gameover)
                await Clients.All.SendAsync("GameOver", _gamesettings);
        }
    }
}
