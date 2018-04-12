namespace MoveDownRightVariant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindHighestSum_WhenMoveDownRight
    {
        private static int[,] matrix;
        private static int[,] betterSum;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            FillMatrix(rows, cols);

            betterSum = new int[rows, cols];
            long highestSum = FindHighestSum();

            PrintPath();
        }

        private static void FillMatrix(int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                var rowNums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rowNums[j];
                }
            }
        }

        private static long FindHighestSum()
        {
            betterSum[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++)
            {
                betterSum[0, col] = matrix[0, col] + betterSum[0, col - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                betterSum[row, 0] = matrix[row, 0] + betterSum[row - 1, 0];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    betterSum[row, col] = Math.Max(
                        betterSum[row - 1, col], betterSum[row, col - 1]) + matrix[row, col];
                }
            }

            return betterSum[rows - 1, cols - 1];
        }

        private static void PrintPath()
        {
            var result = new List<string>();
            var currentRow = rows - 1;
            var currentCol = cols - 1;

            result.Add($"[{currentRow}, {currentCol}]");

            while (currentRow != 0 || currentCol != 0)
            {
                long up = -1;
                if (currentRow - 1 >= 0)
                {
                    up = betterSum[currentRow - 1, currentCol];
                }

                long left = -1;
                if (currentCol - 1 >= 0)
                {
                    left = betterSum[currentRow, currentCol - 1];
                }

                if (up > left)
                {
                    result.Add($"[{currentRow - 1}, {currentCol}]");
                    currentRow -= 1;
                }
                else
                {
                    result.Add($"[{currentRow}, {currentCol - 1}]");
                    currentCol -= 1;
                }
            }

            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
