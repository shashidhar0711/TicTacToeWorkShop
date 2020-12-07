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
            ticTacToeRepo.ShowBoard(board);
            ticTacToeRepo.GetUserDesiredMove(board);
            Player player = GetWhoStartsFirst();
            char userLetter = ticTacToeRepo.ChooseUserChoice();
            Console.WriteLine("Check if won "+ ticTacToeRepo.IsWinner(board,userLetter));
            char computerLetter = (userLetter == 'X') ? 'O' : 'X';
            int computerMove = ticTacToeRepo.GetComputerMove(board, computerLetter, userLetter);
        }
    }
}
