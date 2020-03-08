using Microsoft.AspNetCore.Components;

namespace TicTacToe.Data
{
    public class GameModel
    {
        public int TurnCount { get; set; }
        public string[] Game { get; set; }
        public bool Botgame { get; set; }
        public bool Botturn { get; set; }
        public bool PlayerXTurn { get; set; }
        public bool PlayerOTurn { get; set; }
        public MarkupString PlayerOWins { get; set; }
        public MarkupString PlayerXWins { get; set; }
        public MarkupString PlayerCatGame { get; set; }
        public bool XWon { get; set; }
        public bool OWon { get; set; }
        public bool CatGame { get; set; }
        public bool Gameover { get; set; }
    }
}
