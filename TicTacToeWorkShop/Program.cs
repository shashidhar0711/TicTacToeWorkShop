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
            char userLetter = ticTacToeRepo.ChooseUserChoice();
            ticTacToeRepo.ShowBoard(board);
            ticTacToeRepo.GetUserDesiredMove(board);
            //Console.WriteLine("Enter user index: ");
            //int userIndex = Convert.ToInt32(Console.ReadLine());
            TicTacToeGameRepo.MakeMove(board, 5, userLetter);
        }
    }
}
