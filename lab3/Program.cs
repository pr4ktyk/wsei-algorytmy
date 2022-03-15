using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(50));
        }

        public static long fibonacci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fib(n, mem);
        }
        private static long fib(int n, long[] mem)
        {
            if (n < 0)
            {
                throw new ArgumentException();
            }
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            if (mem[n - 1] == -1)
            {
                mem[n - 1] = fib(n - 1, mem);
            }
            if (mem[n - 2] == -1)
            {
                mem[n - 2] = fib(n - 2, mem);
            }
            return mem[n - 1] + mem[n - 2];
        }

    }
}
