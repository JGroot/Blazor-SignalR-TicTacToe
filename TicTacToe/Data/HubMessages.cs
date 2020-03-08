using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Data
{
    public static class HubMessages
    {
    }

    public static class ClientEndpoints
    {
        public const string NewHumanGame = "NewHumanGame";
        public const string NewBotGame = "NewBotGame";
        public const string ReceiveMessage = "ReceiveMessage";
        public const string NextTurn = "NextTurn";
        public const string GameOver = "GameOver";

    }

    public static class ServerEndpoints
    {
        public const string PlayerMove = "PlayerMove";
    }
}
