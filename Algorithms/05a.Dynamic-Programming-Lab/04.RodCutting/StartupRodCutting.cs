namespace RodCutting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartupRodCutting
    {
        private static int[] priceList;
        private static int[] bestPrice;
        private static int[] bestCombo;

        public static void Main()
        {
            priceList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            bestPrice = new int[priceList.Length];
            bestCombo = new int[priceList.Length];

            bestPrice[0] = 0;
            bestPrice[1] = priceList[1];

            int rodPiecesBestPrice = CutRod(n);
            Console.WriteLine(rodPiecesBestPrice);

            ReconsructSolution(n);

            /* Input:
             * 0 1 5 8 9 10 16 17 20 24 30
             * 7
             * Output:
             * 18
             * 2 2 3
             */
        }

        private static int CutRod(int n)
        {
            for (int pieceLen = 1; pieceLen <= n; pieceLen++)
            {
                int currentBestPrice = bestPrice[pieceLen];

                for (int piece = 1; piece <= pieceLen; piece++)
                {
                    currentBestPrice = Math.Max(
                        bestPrice[pieceLen],
                        priceList[piece] + bestPrice[pieceLen - piece]);

                    if (bestPrice[pieceLen] < currentBestPrice)
                    {
                        bestPrice[pieceLen] = currentBestPrice;
                        bestCombo[pieceLen] = piece;
                    }
                }
            }

            return bestPrice[n];
        }

        private static void ReconsructSolution(int n)
        {
            var piecesList = new List<int>();

            while (n > 0)
            {
                piecesList.Add(bestCombo[n]);

                n = n - bestCombo[n];
            }

            Console.WriteLine(string.Join(" ", piecesList));
        }
    }
}
