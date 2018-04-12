namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KnapsackStartup
    {
        public static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            var items = new List<Item>();

            var line = Console.ReadLine();

            while (line != "end")
            {
                var parts = line
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                items.Add(new Item
                {
                    Name = parts[0],
                    Weight = int.Parse(parts[1]),
                    Price = int.Parse(parts[2])
                });

                line = Console.ReadLine();
            }

            var prices = new int[items.Count + 1, maxCapacity + 1];
            var includedItems = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row <= items.Count; row++)
            {
                var item = items[row - 1];

                for (int col = 0; col <= maxCapacity; col++)
                {
                    if (item.Weight > col)
                    {
                        continue;
                    }

                    var excluding = prices[row - 1, col];
                    var including = item.Price + prices[row - 1, col - item.Weight];

                    if (including > excluding)
                    {
                        prices[row, col] = including;
                        includedItems[row, col] = true;
                    }
                    else
                    {
                        prices[row, col] = excluding;
                    }
                }
            }

            var capacity = maxCapacity;
            var result = new List<Item>();

            for (int itemIndex = items.Count - 1; itemIndex >= 0; itemIndex--)
            {
                if (capacity <= 0)
                {
                    break;
                }

                if (includedItems[itemIndex + 1, capacity])
                {
                    var currentItem = items[itemIndex];

                    result.Add(currentItem);

                    capacity -= currentItem.Weight;
                }
            }

            Console.WriteLine("Total Weight: " + result.Sum(x => x.Weight));
            Console.WriteLine("Total Value: " + prices[items.Count, maxCapacity]);

            var names = result.Select(x => x.Name).ToList();
            names.Sort();
            Console.WriteLine(string.Join("\n", names));
        }
    }
}
