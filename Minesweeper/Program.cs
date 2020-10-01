using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[][] 
            {
                new char[]{'E', 'E', 'E', 'E', 'E'},
                new char[]{'E', 'E', 'M', 'E', 'E'},
                new char[]{'E', 'E', 'E', 'E', 'E'},
                new char[]{'E', 'E', 'E', 'E', 'E'}
            };

           // char[][] boards = new char[][]
           //{
           //     new char[]{'B', '1', 'E', '1', 'B'},
           //     new char[]{'B', '1', 'M', '1', 'B'},
           //     new char[]{'B', '1', '1', '1', 'B'},
           //     new char[]{'B', 'B', 'B', 'B', 'E'}
           //};

            int[] click = new int[] { 3, 0 };
            Console.WriteLine(UpdateBoard(board, click));
        }

        static int[][] directions = new int[][]
            {
            new int[] {-1,0},
            new int[] {1,0 },
            new int[] {-1,-1},
            new int[] {1,1},
            new int[] {0,-1},
            new int[] {0,1 },
            new int[] {1,-1},
            new int[] {-1,1 },
        };

        static char[][] UpdateBoard(char[][] board, int[] click)
        {
            int row = click[0];
            int column = click[1];
            int maxRow = board.Length;
            int maxColumn = board[0].Length;

            if (board[row][column] == 'M' || board[row][column] == 'X')
            {
                board[row][column] = 'X';
                return board;
            }

            int count = 0;

            foreach(var dir in directions)
            {
                int newRow = dir[0] + row;
                int newColumn = dir[1] + column;
                if (newRow >= 0 && newRow < maxRow
                    && newColumn >= 0 && newColumn < maxColumn
                    && board[newRow][newColumn] == 'M') count++;
            }

            if (count > 0)
            {
                board[row][column] = (char)(count + '0');
                return board;
            }

            board[row][column] = 'B';

            foreach (var dir in directions)
            {
                int newRow = dir[0] + row;
                int newColumn = dir[1] + column;
                if (newRow >= 0 && newRow < maxRow
                    && newColumn >= 0 && newColumn < maxColumn
                    && board[newRow][newColumn] == 'E') UpdateBoard(board, new int[] { newRow, newColumn });
            }

            return board;
        }
    }
}
