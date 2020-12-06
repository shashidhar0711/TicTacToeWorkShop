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
    }
}
