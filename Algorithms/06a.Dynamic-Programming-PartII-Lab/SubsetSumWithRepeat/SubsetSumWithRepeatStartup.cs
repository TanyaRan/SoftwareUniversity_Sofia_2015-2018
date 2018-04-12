namespace SubsetSumWithRepeat
{
    using System;
    using System.Linq;

    public class SubsetSumWithRepeatStartup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var targetSum = int.Parse(Console.ReadLine());

            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        var newSum = sum + numbers[i];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }
                }
            }

            // recover
            while (targetSum != 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var tempSum = targetSum - numbers[i];
                    if (tempSum >= 0 && possibleSums[tempSum])
                    {
                        Console.Write(numbers[i] + " ");
                        targetSum = tempSum;
                    }
                }
            }

            Console.WriteLine(possibleSums[targetSum]);
        }
    }
}
