using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace TicTacToe.Data
{
    public class GameModelService
    {
        public Task<GameModel> GetHumanGameBoardAsync()
        {
            var dto = new GameModel()
            {
                TurnCount = 0,
                Game = new string[9],
                Botgame = false,
                Botturn = false,
                PlayerXTurn = true,
                PlayerOTurn = false,
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
                PlayerXTurn = true,
                PlayerOTurn = false,
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
