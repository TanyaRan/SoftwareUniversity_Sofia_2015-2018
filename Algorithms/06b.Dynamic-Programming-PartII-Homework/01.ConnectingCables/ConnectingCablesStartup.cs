namespace ConnectingCables
{
    using System;
    using System.Linq;

    public class ConnectingCablesStartup
    {
        private static int[] p1;
        private static int[] p2;
        private static int[,] maxConnected;

        public static void Main()
        {
            p2 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            p1 = new int[p2.Length];

            for (int i = 1; i <= p2.Length; i++)
            {
                p1[i - 1] = i;
            }

            maxConnected = new int[p1.Length + 1, p2.Length + 1];
            for (int i = 1; i < p1.Length + 1; i++)
            {
                for (int j = 1; j < p2.Length + 1; j++)
                {
                    maxConnected[i, j] = -1;
                }
            }

            int maxPairsConnected = GetMaxConnected(p1.Length, p2.Length);

            Console.WriteLine($"Maximum pairs connected: {maxPairsConnected}");
        }

        private static int GetMaxConnected(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (maxConnected[x, y] != -1)
            {
                return maxConnected[x, y];
            }

            if (p1[x - 1] == p2[y - 1])
            {
                maxConnected[x, y] = 1 + GetMaxConnected(x - 1, y - 1);
            }
            else
            {
                int reduceP1 = GetMaxConnected(x - 1, y);
                int reduceP2 = GetMaxConnected(x, y - 1);

                maxConnected[x, y] = Math.Max(reduceP1, reduceP2);
            }

            return maxConnected[x, y];
        }
    }
}
