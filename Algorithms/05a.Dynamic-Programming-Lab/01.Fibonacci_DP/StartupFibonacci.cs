namespace Fibonacci_DP
{
    using System;

    public class StartupFibonacci
    {
        private static int[] arr;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long nthFibonacci = CalculateFibonacci(n);

            Console.WriteLine(nthFibonacci);
        }

        private static long CalculateFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            arr = new int[n + 1];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                arr[i] = arr[i - 2] + arr[i - 1];
            }

            return arr[n];
        }
    }
}
