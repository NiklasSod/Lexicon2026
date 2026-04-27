using System;
using System.Collections.Generic;
using System.Text;

// https://open.kattis.com/problems/1dfroggereasy

namespace LexiconTest1.Kattis
{
    internal class Frogger
    {
        record GameData(int StartingSquare, int MagicNumber, int[] Board);

        static void Main(string[] args)
        {

            GameData? data = ParseInput();
            if (data == null) return;

            FrogResult result = Outcome(data);

            Console.WriteLine(result.StatusOfGame);
            Console.WriteLine(result.NumberOfJumps);
            Console.ReadLine();
        }

        static GameData? ParseInput()
        {
            //string? gameInfo = Console.ReadLine();
            string? gameInfo = "6 4 42";
            if (string.IsNullOrEmpty(gameInfo)) return null;

            string[] gameInfoParts = gameInfo.Split();
            if (gameInfoParts.Length < 3) return null;

            int amountOfSquares = int.Parse(gameInfoParts[0]);
            int startingSquare = int.Parse(gameInfoParts[1]);
            int magicNumber = int.Parse(gameInfoParts[2]);

            //string? numberOnSquaresStringLine = Console.ReadLine();
            string? numberOnSquaresStringLine = "-9 1 42 -2 -3 -3";
            if (string.IsNullOrWhiteSpace(numberOnSquaresStringLine)) return null;

            string[] stringBoardParts = numberOnSquaresStringLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (stringBoardParts.Length == 0) return null;

            int[] boardParts = new int[stringBoardParts.Length];

            for (int i = 0; i < stringBoardParts.Length; i++)
            {
                boardParts[i] = int.Parse(stringBoardParts[i]);
            }

            if (boardParts.Length != amountOfSquares) return null;

            // amountOfSquares not needed anymore, boardParts has "extra" information now (length and value)
            return new GameData(startingSquare, magicNumber, boardParts);
        }

        record struct FrogResult(string StatusOfGame, int NumberOfJumps);

        static FrogResult Outcome(GameData data)
        {
            int start = data.StartingSquare - 1;
            int magic = data.MagicNumber;
            int[] board = data.Board;

            // List<int> cycleNumber = new List<int>();
            HashSet<int> alreadyVisitedNumber = [];
            int boardPosition = start;
            int jumps = 0;

            while (boardPosition < board.Length && boardPosition >= 0)
            {
                if (board[boardPosition] == magic)
                {
                    return new FrogResult { StatusOfGame = "magic", NumberOfJumps = jumps };
                }

                if (!alreadyVisitedNumber.Add(boardPosition))
                {
                    return new FrogResult { StatusOfGame = "cycle", NumberOfJumps = jumps };
                }

                alreadyVisitedNumber.Add(boardPosition);

                int moveValue = board[boardPosition];
                boardPosition += moveValue;
                jumps++;
            }

            string status = (boardPosition < 0) ? "left" : "right";

            return new FrogResult { StatusOfGame = status, NumberOfJumps = jumps };
        }
    }
}
