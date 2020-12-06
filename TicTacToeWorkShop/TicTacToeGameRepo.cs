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
    }
}
