namespace SubsetSumCombinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSumCombinationsStartup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers);

            var targetSum = int.Parse(Console.ReadLine());

            int sumCombinations = CalcSumCombinations(numbers, targetSum);

            if (sumCombinations != 0)
            {
                Console.WriteLine("Subset sum found!");
                Console.WriteLine(sumCombinations);
            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        private static int CalcSumCombinations(int[] numbers, int targetSum)
        {
            var result = new Dictionary<int, int>();
            var combinations = 0;

            result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                foreach (var number in result.Keys.ToList())
                {
                    var newSum = number + currentNumber;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, currentNumber);
                    }

                    if (newSum == targetSum)
                    {
                        combinations++;
                    }
                }
            }

            return combinations;
        }
    }
}
