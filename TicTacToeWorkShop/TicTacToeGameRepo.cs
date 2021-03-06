﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeWorkShop
{
    public class TicTacToeGameRepo
    {
        /// Constants
        public const int HEAD = 0;
        public const int TAIL = 1;
        private static readonly char computerLetter;
        /// <summary>
        /// Enumeration of player
        /// </summary>
        public enum Player
        {
            USER, COMPUTER
        };

        /// <summary>
        /// Enumeration types of game status
        /// </summary>
        public enum GameStatus
        {
            WON, FULL_BOARD, CONTINUE
        };

        /// <summary>
        /// UC1
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
        /// UC2
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
        /// UC3
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
        /// UC4
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
        /// UC5
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
        /// UC6
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
        /// UC7
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
        /// UC8 On Computer getting its turn would like the computer to play like me.
        /// UC9 Check if my Opponent can win then play to block it.
        /// UC10 Choice would be to take one of the available corners.
        /// UC11 My Subsequent Choices will be corners if not available then take the centre and
        /// Lastly any of the available sides.
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
            // Center move
            if (IsSpaceFree(board, 5)) 
                return 5;
            int[] sideMoves = { 2, 4, 6, 8 };
            computerMove = GetRandomMoveFromList(board, sideMoves);
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
        /// UC10
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

        /// <summary>
        /// UC12
        /// Gets the game status.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="move">The move.</param>
        /// <param name="letter">The letter.</param>
        /// <param name="wonMessage">The won message.</param>
        /// <returns></returns>
        public GameStatus GetGameStatus(char[] board, int move, char letter, string wonMessage)
        {
            MakeMove(board, move, letter);
            if (IsWinner(board, letter))
            {
                ShowBoard(board);
                Console.WriteLine(wonMessage);
                return GameStatus.WON;
            }
            if (IsBoardFull(board))
            {
                ShowBoard(board);
                Console.WriteLine("Game is Tie");
                return GameStatus.FULL_BOARD;
            }
            return GameStatus.CONTINUE;
        }

        /// <summary>
        /// Check Board is full
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsBoardFull(char[] board)
        {
            for (int index = 1; index < board.Length; index++)
            {
                if (IsSpaceFree(board, index))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// UC13
        /// Plays the again.
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            Console.WriteLine("Do you want to Play Again? (yes/no)");
            string option = Console.ReadLine().ToLower();
            if (option.Equals("yes"))
                return true;
            return false;
        }
    }
}
