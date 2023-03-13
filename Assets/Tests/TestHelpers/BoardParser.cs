using System;
using System.IO;

namespace Tests.TestHelpers
{
    public class BoardParser
    {
        private static readonly char[] Delimiters = { ' ', '\t' };

        public int?[,] Parse(string boardString)
        {
            (int x, int y) = ParseSize(boardString);
            int?[,] board = new int?[x, y];
            StringReader reader = new StringReader(boardString);

            int row = y - 1;
            while (reader.ReadLine() is { } line)
            {
                string[] itemTypes = line.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < itemTypes.Length; i++)
                    board[i, row] = int.TryParse(itemTypes[i], out int itemType) ? itemType : null;

                if (itemTypes.Length != 0)
                    row--;
            }

            return board;
        }
        
        private (int x, int y) ParseSize(string boardString)
        {
            int x = 0, y = 0;
            StringReader reader = new StringReader(boardString);

            while (reader.ReadLine() is { } line)
            {
                string[] itemTypes = line.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
                
                if (itemTypes.Length == 0)
                    continue;

                if (x == 0)
                    x = itemTypes.Length;
                else if (x != itemTypes.Length)
                    throw new ArgumentException($"The number of columns in rows must be the same: {boardString}");

                y++;
            }

            return (x, y);
        }
    }
}