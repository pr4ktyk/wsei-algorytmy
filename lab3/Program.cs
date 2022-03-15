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

        public class CashRegister
        {
            private static int ONE = 0;
            private static int TWO = 1;
            private static int FIVE = 2;

            private readonly int[] _coins = new int[3];

            public CashRegister(int[] coins)
            {
                _coins = coins;
            }

            int[] Payment(int[] income, int amount)
            {
                if (amount > getAmount(income))
                {
                    return new int[] { };
                }

                // warunki, które uniemożliwiają wykonanie
            }

            private int getAmount(int[] coins)
            {
                return (coins[0] * 1) + (coins[1] * 2) + (coins[2] * 5);
            }

            private int getRemainder(int[] income, int amount)
            {
                return getAmount(income) + amount;
            }

            private void registerCash(int[] income)
            {
                income[ONE] += _coins[ONE];
                income[TWO] += _coins[TWO];
                income[FIVE] += _coins[FIVE];
            }

            private int[] calculateRest(int rest)
            {
                //implementowanie obliczania liczby monet skladajacych sie na reszte
            }
        }
    }
}
