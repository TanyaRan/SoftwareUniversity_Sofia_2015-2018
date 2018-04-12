namespace SumChangeUnlimitedCoins
{
    using System;
    using System.Linq;

    public class UnlimitedCoinsChange
    {
        private static int[] coins;
        private static int sum;

        public static void Main()
        {
            coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            sum = int.Parse(Console.ReadLine());

            int coinsCombinations = FindSumChangeCombinations();

            Console.WriteLine(coinsCombinations);
        }

        private static int FindSumChangeCombinations()
        {
            var matrix = new int[coins.Length + 1, sum + 1];

            for (int row = 0; row <= coins.Length; row++)
            {
                matrix[row, 0] = 1;
            }

            for (int col = 1; col <= sum; col++)
            {
                matrix[0, col] = 0;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (coins[i - 1] <= j)
                    {
                        var currentCoin = coins[i - 1];
                        matrix[i, j] =
                            matrix[i, j - currentCoin] + matrix[i - 1, j];
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j];
                    }
                }
            }

            //Console.Write("  ");
            //Console.WriteLine(string.Join(" ", coins));
            //Console.WriteLine();
            //PrintMatrix(matrix);

            return matrix[coins.Length, sum];
        }

        //private static void PrintMatrix(int[,] matrix)
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write(matrix[i, j] + " ");
        //        }

        //        Console.WriteLine();
        //    }
        //}
    }
}
