namespace LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestZigzagStartup
    {
        private static int[] seq;
        private static int[] oddBiggerSeq;
        private static int[] prevElementOddBiggerSeq;
        private static int[] evenBiggerSeq;
        private static int[] prevElementEvenBiggerSeq;

        public static void Main()
        {
            seq = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            oddBiggerSeq = new int[seq.Length];
            prevElementOddBiggerSeq = new int[seq.Length];
            evenBiggerSeq = new int[seq.Length];
            prevElementEvenBiggerSeq = new int[seq.Length];

            List<int> longestZigzagSeq = FindLongestZigzagSeq();

            Console.WriteLine(string.Join(" ", longestZigzagSeq));
        }

        private static List<int> FindLongestZigzagSeq()
        {
            int maxLen = 0;
            int lastIndex = -1;
            bool isOddSeqLonger = false;

            for (int i = 0; i < seq.Length; i++)
            {
                oddBiggerSeq[i] = 1;
                prevElementOddBiggerSeq[i] = -1;
                evenBiggerSeq[i] = 1;
                prevElementEvenBiggerSeq[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (oddBiggerSeq[j] % 2 == 0)
                    {
                        if (seq[i] > seq[j] && oddBiggerSeq[i] <= oddBiggerSeq[j])
                        {
                            oddBiggerSeq[i] = oddBiggerSeq[j] + 1;
                            prevElementOddBiggerSeq[i] = j;
                        }
                    }
                    else
                    {
                        if (seq[i] < seq[j] && oddBiggerSeq[i] <= oddBiggerSeq[j])
                        {
                            oddBiggerSeq[i] = oddBiggerSeq[j] + 1;
                            prevElementOddBiggerSeq[i] = j;
                        }
                    }

                    if (evenBiggerSeq[j] % 2 == 0)
                    {
                        if (seq[i] < seq[j] && evenBiggerSeq[i] <= evenBiggerSeq[j])
                        {
                            evenBiggerSeq[i] = evenBiggerSeq[j] + 1;
                            prevElementEvenBiggerSeq[i] = j;
                        }
                    }
                    else
                    {
                        if (seq[i] > seq[j] && evenBiggerSeq[i] <= evenBiggerSeq[j])
                        {
                            evenBiggerSeq[i] = evenBiggerSeq[j] + 1;
                            prevElementEvenBiggerSeq[i] = j;
                        }
                    }
                }

                if (maxLen < oddBiggerSeq[i])
                {
                    maxLen = oddBiggerSeq[i];
                    lastIndex = i;
                    isOddSeqLonger = true;
                }

                if (maxLen < evenBiggerSeq[i])
                {
                    maxLen = evenBiggerSeq[i];
                    lastIndex = i;
                    isOddSeqLonger = false;
                }
            }

            var longestZigzagSeq = new List<int>();

            if (isOddSeqLonger)
            {
                while (lastIndex != -1)
                {
                    longestZigzagSeq.Add(seq[lastIndex]);
                    lastIndex = prevElementOddBiggerSeq[lastIndex];
                }
            }
            else
            {
                while (lastIndex != -1)
                {
                    longestZigzagSeq.Add(seq[lastIndex]);
                    lastIndex = prevElementEvenBiggerSeq[lastIndex];
                }
            }

            longestZigzagSeq.Reverse();

            return longestZigzagSeq;
        }
    }
}
