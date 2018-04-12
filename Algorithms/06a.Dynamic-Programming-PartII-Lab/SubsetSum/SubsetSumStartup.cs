namespace SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSumStartup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var targetSum = int.Parse(Console.ReadLine());

            var sums = CalcSums(numbers);

            if (sums.ContainsKey(targetSum))
            {
                Console.WriteLine("YES");

                // recover first finded sum
                while (targetSum != 0)
                {
                    var number = sums[targetSum];

                    Console.Write(number);

                    targetSum -= number;
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static Dictionary<int, int> CalcSums(int[] numbers)
        {
            var result = new Dictionary<int, int>();

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
                }
            }

            return result;
        }
    }
}
