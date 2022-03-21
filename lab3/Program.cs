using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Fibonacci(30): {fibonacci(30, null, null)}");

            Console.WriteLine();

            CashRegister bank = new CashRegister(1, 2, 4);
            Console.WriteLine();
            bank.Payment(new int[] { 0, 0, 2 }, 8);
            Console.WriteLine(bank);
        }

        public static long fibonacci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fib(n, mem);
        }

        public static long fibonacci(int n, long? a, long? b)
        {
            if (n < 0) throw new ArgumentException();
            if (n == 0) return 0;
            if (n == 1) return 1;

            if (a == null) a = fibonacci(n-1, null, null);
            if (b == null) b = fibonacci(n-2, null, null);
            return (long)b + (long)a;
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