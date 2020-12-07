using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeWorkShop
{
    public class TicTacToeGameRepo
    {
        /// Constants
        public const int HEAD = 0;
        public const int TAIL = 1;
        /// <summary>
        /// Enumeration of player
        /// </summary>
        public enum Player
        {
            USER, COMPUTER
        };

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

        /// <summary>
        /// Makes the move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="index">The index.</param>
        /// <param name="letter">The letter.</param>
        public static void MakeMove(char[] board, int index, char letter)
        {
            bool isSpaceFree = IsSpaceFree(board, index);
            if (isSpaceFree)
            {
                board[index] = letter;
            }
        }

        /// <summary>
        /// Gets the who starts first.
        /// </summary>
        /// <returns></returns>
        public static Player GetWhoStartsFirst()
        {
            int toss = RandomCheck(2);
            Console.WriteLine("Random Toss is : "+toss);
            return (toss == HEAD) ? Player.COMPUTER : Player.COMPUTER;
        }

        /// <summary>
        /// Randoms the check.
        /// </summary>
        /// <param name="userchoice">The userchoice.</param>
        /// <returns></returns>
        public static int RandomCheck(int userchoice)
        {
            Random random = new Random();
            return random.Next(0, 2);
        }

        /// <summary>
        /// Determines whether the specified board is winner.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="symbol">The symbol.</param>
        /// <returns>
        ///   <c>true</c> if the specified board is winner; otherwise, <c>false</c>.
        /// </returns>  
        public bool IsWinner(char[] board, char symbol)
        {
            return (board[1] == symbol && board[2] == symbol && board[3] == symbol) ||
                   (board[4] == symbol && board[5] == symbol && board[6] == symbol) ||
                   (board[7] == symbol && board[8] == symbol && board[9] == symbol) ||
                   (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                   (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                   (board[3] == symbol && board[6] == symbol && board[9] == symbol) ||
                   (board[1] == symbol && board[5] == symbol && board[9] == symbol) ||
                   (board[3] == symbol && board[5] == symbol && board[7] == symbol);
        }

        /// <summary>
        /// Gets the computer move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="computerLetter">The computer letter.</param>
        /// <returns></returns>
        public int GetComputerMove(char[] board, char computerLetter, char userLetter)
        {
            int winningMove = GetWinningMove(board, computerLetter);
            if (winningMove != 0)
            {
                return winningMove;
            }
            int userWinningMove = GetWinningMove(board, userLetter);
            if (userWinningMove != 0)
            {
                return userWinningMove;
            }
            int[] cornerMoves = { 1, 3, 7, 9 };
            int computerMove = GetRandomMoveFromList(board, cornerMoves);
            if (computerMove != 0)
            {
                return computerMove;
            }
            return 0;
        }

        /// <summary>
        /// Gets the winning move.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="computerLetter">The computer letter.</param>
        /// <returns></returns>
        private int GetWinningMove(char[] board, char computerLetter)
        {
            for (int index = 1; index < board.Length; index++)
            {
                char[] copyOfBoard = GetCopyOfBoard(board);
                if (IsSpaceFree(copyOfBoard, index))
                {
                    MakeMove(copyOfBoard, index, computerLetter);
                    if (IsWinner(copyOfBoard, computerLetter))
                    {
                        return index;
                    }
                }
            }
            return 0;

        }

        /// <summary>
        /// Gets the copy of board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <returns></returns>
        public char[] GetCopyOfBoard(char[] board)
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, 0, boardCopy, 0, board.Length);
            return boardCopy;
        }

        /// <summary>
        /// Gets the random move from list.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="moves">The moves.</param>
        /// <returns></returns>
        public static int GetRandomMoveFromList(char[] board, int[] moves)
        {
            for (int index = 0; index < moves.Length; index++)
            {
                if (IsSpaceFree(board, moves[index]))
                    return moves[index];
            }
            return 0;
        }
    }
}
