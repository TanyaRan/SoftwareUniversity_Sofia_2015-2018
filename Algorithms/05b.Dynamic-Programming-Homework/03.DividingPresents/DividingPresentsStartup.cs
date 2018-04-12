namespace DividingPresents
{
    using System;
    using System.Linq;
    using System.Text;

    public class DividingPresentsStartup
    {
        private static int[] presents;
        private static int[] prevIndex;

        public static void Main()
        {
            presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int total = presents.Sum();

            prevIndex = new int[total + 1];
            prevIndex[0] = 0;
            for (int i = 1; i < prevIndex.Length; i++)
            {
                prevIndex[i] = -1;
            }

            for (int i = 0; i < presents.Length; i++)
            {
                for (int j = total; j >= 0; j--)
                {
                    if (prevIndex[j] != -1 && prevIndex[j + presents[i]] == -1)
                    {
                        prevIndex[j + presents[i]] = i;
                    }
                }
            }

            int half = total / 2;

            for (int i = half; i >= 0; i--)
            {
                if (prevIndex[i] != -1)
                {
                    int alansShare = i;
                    int bobsShare = total - i;
                    Console.WriteLine($"Difference: {bobsShare - alansShare}");
                    Console.WriteLine($"Alan:{alansShare} Bob:{bobsShare}");
                    Console.WriteLine($"Alan takes: {GetAlanPresents(alansShare)}");
                    Console.WriteLine("Bob takes the rest.");
                    break;
                }
            }
        }

        private static string GetAlanPresents(int index)
        {
            StringBuilder result = new StringBuilder();

            while (index != 0)
            {
                result.Append(presents[prevIndex[index]]);
                result.Append(" ");
                index = index - presents[prevIndex[index]];
            }

            return result.ToString().Trim();
        }
    }
}
