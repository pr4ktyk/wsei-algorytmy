using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibonacci(50));

            Console.WriteLine(SinTable.Sin(5));
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
        class SinTable
        {
            static readonly int MAX = 360;
            static private double[] sinTable;
            static SinTable()
            {
                sinTable = new double[MAX];
                for (int i = 0; i < sinTable.Length; i++)
                {
                    sinTable[i] = Math.Sin(i * Math.PI  / 180);
                }
            }

            public static double Sin(int degree)
            {
                if(degree > 0)
                {
                    return sinTable[degree % MAX];
                } else
                {
                    return -sinTable[-degree % MAX];
                }
            }
        }
    }
}
