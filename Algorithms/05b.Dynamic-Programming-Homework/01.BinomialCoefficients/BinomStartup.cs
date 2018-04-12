namespace BinomialCoefficients
{
    using System;

    public class BinomStartup
    {
        private static long[,] binoms;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            binoms = new long[n + 1, k + 1];

            Console.WriteLine(Binom(n, k));
        }

        private static long Binom(int n, int k)
        {
            if (binoms[n, k] != 0)
            {
                return binoms[n, k];
            }

            if (k > n)
            {
                return 0;
            }

            if (k == 0 || n == k)
            {
                return 1;
            }

            binoms[n, k] = Binom(n - 1, k - 1) + Binom(n - 1, k);

            return binoms[n, k];
        }
    }
}
