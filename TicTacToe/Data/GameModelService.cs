using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace TicTacToe.Data
{
    public class GameModelService
    {
        //private HubConnection _hubConnection;
        //private static GameModel _gamesettings = new GameModel();

        //public GameModelService()
        //{
        //    _hubConnection.On<GameModel>("ReceiveMessage", (gamesettings) =>
        //    {
        //        _gamesettings = gamesettings;
        //        if (gamesettings.Botturn) { BotPlay(); Send(); }
        //    });

        //    _hubConnection.On<GameModel>(ClientEndpoints.NewHumanGame, (gamesettings) =>
        //    {
        //        _gamesettings = gamesettings;
        //    });

        //}
        public Task<GameModel> GetHumanGameBoardAsync()
        {
            var dto = new GameModel()
            {
                TurnCount = 0,
                Game = new string[9],
                Botgame = false,
                Botturn = false,
                PlayerOWins = new MarkupString(),
                PlayerXWins = new MarkupString(),
                PlayerCatGame = new MarkupString(),
                OWon = false,
                XWon = false,
                CatGame = false,
                Gameover = false,
            };

            for (var i = 0; i < dto.Game.Length; i++)
                dto.Game[i] = string.Empty;

            return Task.FromResult(dto);
        }

        public Task<GameModel> GetBotGameBoardAsync()
        {
            var dto = new GameModel()
            {
                TurnCount = 0,
                Game = new string[9],
                Botgame = true,
                Botturn = false,
                PlayerOWins = new MarkupString(),
                PlayerXWins = new MarkupString(),
                PlayerCatGame = new MarkupString(),
                OWon = false,
                XWon = false,
                CatGame = false,
                Gameover = false,
            };

            for (var i = 0; i < dto.Game.Length; i++)
                dto.Game[i] = string.Empty;

            return Task.FromResult(dto);
        }

    }
}
