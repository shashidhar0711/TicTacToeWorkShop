using System;

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
            char userChoice = ticTacToeRepo.ChooseUserChoice();
            ticTacToeRepo.ShowBoard(board);
            ticTacToeRepo.GetUserDesiredMove(board);
        }
    }
}
