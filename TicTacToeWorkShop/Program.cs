using System;
using static TicTacToeWorkShop.TicTacToeGameRepo;

namespace TicTacToeWorkShop
{
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to tictactoe workshop");
            TicTacToeGameRepo ticTacToeRepo = new TicTacToeGameRepo();
            char[] board = ticTacToeRepo.CreateTicTacToeBoard();
            char userLetter = ticTacToeRepo.ChooseUserChoice();
            char computerLetter = (userLetter == 'X') ? 'O' : 'X';
            Player player = GetWhoStartsFirst();
            bool gameIsPlaying = true;
            GameStatus gameStatus;
            while (gameIsPlaying)
            {
                /// Player turns
                if (player.Equals(Player.USER))
                {
                    ticTacToeRepo.ShowBoard(board);
                    int userMove = ticTacToeRepo.GetUserDesiredMove(board);
                    string wonMessage = "Hurray! You have won the game!";
                    gameStatus = ticTacToeRepo.GetGameStatus(board, userMove, userLetter, wonMessage);
                    player = Player.COMPUTER;
                }
                else
                {
                    /// Computer Turn
                    string wonMessage = "The Computer has beaten you! You lose.";
                    int computerMove = ticTacToeRepo.GetComputerMove(board, computerLetter, userLetter);
                    gameStatus = ticTacToeRepo.GetGameStatus(board, computerMove, computerLetter, wonMessage);
                    player = Player.USER;
                }
                if (gameStatus.Equals(GameStatus.CONTINUE))
                    continue;
                if(TicTacToeGameRepo.PlayAgain()) goto PlayAgain;
                gameIsPlaying = false;
            }
        }
    }
}
