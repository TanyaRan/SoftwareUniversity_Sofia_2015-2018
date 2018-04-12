namespace LongestCommonSubseq
{
    using System;

    public class LongestCommonSubseqStartup
    {
        public static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            // Longest Common Subsequence => lcs
            var lcs = new int[first.Length + 1, second.Length + 1];

            for (int row = 1; row <= first.Length; row++)
            {
                for (int col = 1; col <= second.Length; col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row, col - 1];

                    var result = Math.Max(up, left);

                    if (first[row - 1] == second[col - 1])
                    {
                        result = Math.Max(lcs[row - 1, col - 1] + 1, result);
                    }

                    lcs[row, col] = result;
                }
            }

            Console.WriteLine(lcs[first.Length, second.Length]);

            /* recover
            var currentRow = first.Length;
            var currentCol = second.Length;

            while (currentRow > 0 && currentCol > 0)
            {
                if (first[currentRow - 1] == second[currentCol - 1])
                {
                    Console.WriteLine(first[currentRow - 1]);
                    currentRow--;
                    currentCol--;
                }
                else if (lcs[currentRow - 1, currentCol] == lcs[currentRow, currentCol])
                {
                    currentRow--;
                }
                else if (lcs[currentRow - 1, currentCol] != lcs[currentRow, currentCol])
                {
                    currentCol--;
                }
            }
            */
        }
    }
}
