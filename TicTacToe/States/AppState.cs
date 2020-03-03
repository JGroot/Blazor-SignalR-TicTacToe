using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Extensions;

namespace TicTacToe.States
{
    public class AppState
    {
        //private readonly List<Expense> _expenses = new List<Expense>();
        //public IReadOnlyList<Expense> Expenses => _expenses;

        private string[] _game = new string[9];
        public string[] Game => _game;

        public event Action OnGameChanged;

        public void TakeTurn(string[] game, int turnCount, int i)
        {
            if (turnCount.isEven())
            {
                game[i] = "X";
            }
            else
            {
                game[i] = "O";
            }
            turnCount++;
            StateChanged();
        }

        private void StateChanged() => OnGameChanged?.Invoke();
    }
}
