namespace LongestIncSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartupLIS
    {
        private static int[] sequence;
        private static int[] seqLength;
        private static int[] prevElementIndex;

        public static void Main()
        {
            sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            seqLength = new int[sequence.Length];
            prevElementIndex = new int[sequence.Length];

            int maxLength = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequence.Length; i++)
            {
                seqLength[i] = 1;
                prevElementIndex[i] = -1;
                int current = sequence[i];

                for (int j = 0; j < i; j++)
                {
                    int previous = sequence[j];

                    if (previous < current && seqLength[j] >= seqLength[i])
                    {
                        seqLength[i] = seqLength[j] + 1;
                        prevElementIndex[i] = j;
                    }
                }

                if (seqLength[i] > maxLength)
                {
                    maxLength = seqLength[i];
                    lastIndex = i;
                }
            }

            List<int> longestSequence = RecoverTheLIS(lastIndex);

            string result = string.Join(" ", longestSequence.ToArray());

            Console.WriteLine(result);
        }

        private static List<int> RecoverTheLIS(int lastIndex)
        {
            if (lastIndex == -1)
            {
                return new List<int> { sequence[0] };
            }

            var longestSequence = new List<int>();

            while (lastIndex != -1)
            {
                longestSequence.Add(sequence[lastIndex]);
                lastIndex = prevElementIndex[lastIndex];
            }

            longestSequence.Reverse();

            return longestSequence;
        }
    }
}
