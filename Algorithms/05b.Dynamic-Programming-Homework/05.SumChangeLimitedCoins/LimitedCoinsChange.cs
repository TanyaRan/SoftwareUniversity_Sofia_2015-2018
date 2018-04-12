namespace SumChangeLimitedCoins
{
    using System;
    using System.Linq;

    public class LimitedCoinsChange
    {
        private static int[] coins;
        private static int sum;

        public static void Main()
        {
            coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(coins); // !!!

            sum = int.Parse(Console.ReadLine());

            if (coins.Length == 1 && coins[0] == sum)
            {
                Console.WriteLine(1);
            }
            else
            {
                long coinsCombinations = FindSumLimitedCoinCombinations();

                Console.WriteLine(coinsCombinations);
            }
        }

        private static long FindSumLimitedCoinCombinations()
        {
            var matrix = new int[coins.Length, sum + 1];
            long solutions = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col >= coins[0])
                {
                    matrix[0, col] = coins[0];
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j];
                    int currentCoin = coins[i];

                    if (currentCoin <= j)
                    {
                        matrix[i, j] =
                            currentCoin + matrix[i - 1, j - currentCoin];
                    }

                    if (matrix[i, j] == sum)
                    {
                        solutions++;
                    }
                }
            }

            //Console.Write("  ");
            //Console.WriteLine(string.Join(" ", coins));
            //Console.WriteLine();
            //PrintMatrix(matrix);

            return solutions;
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
