using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeWorkShop
{
    public class TicTacToeGameRepo
    {
        /// <summary>
        /// Creates the tic tac toe board.
        /// </summary>
        /// <returns></returns>
        public char[] CreateTicTacToeBoard()
        {
            char[] board = new char[10];
            for (int i = 1; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }

        /// <summary>
        /// Chooses the user choice.
        /// </summary>
        /// <returns></returns>
        public char ChooseUserChoice()
        {
            Console.WriteLine("Choose your letter: ");
            string userChoice = Console.ReadLine();
            return char.ToUpper(userChoice[0]);
        }

        /// <summary>
        /// Shows the board.
        /// </summary>
        /// <param name="board">The board.</param>
        public void ShowBoard(char[] board)
        {
            Console.WriteLine(board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("----------");
            Console.WriteLine(board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("----------");
            Console.WriteLine(board[7] + " | " + board[8] + " | " + board[9]);
            Console.WriteLine("----------");
        }

        /// <summary>
        /// Gets the user desired move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public int GetUserDesiredMove(char[] board)
        {
            int[] validCells = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            while (true)
            {
                Console.WriteLine("What is your desired next move?");
                int index = Convert.ToInt32(Console.ReadLine());
                if (Array.Find<int>(validCells, element => element == index) != 0 && IsSpaceFree(board, index))
                {
                    return index;
                }
                else
                {
                    Console.WriteLine("Not a Valid Entry !! Try again.");
                }
            }
        }

        /// <summary>
        /// Determines whether [is space free] [the specified board].
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if [is space free] [the specified board]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSpaceFree(char[] board, int index)
        {
            return board[index] == ' ';
        }
    }
}
