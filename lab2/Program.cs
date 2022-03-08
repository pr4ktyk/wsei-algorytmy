using System;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ex1 = { 11, 22, 33, 44, 55 };
            Console.WriteLine($"Zadanie 1: {sumOfTable(ex1, 0)}");

            int[] ex2 = { 2, 1, 2, 2, 1, 3, 7, 8 };
            Console.WriteLine($"Zadanie 2: {repetitions(ex2, 0, 2)}");
        }

        public static int sumOfTable(int[] tab, int index)
        {
            int sum = 0;
            if (index < tab.Length)
            {
                sum += tab[index++];
                sum += sumOfTable(tab, index);
            }
            return sum;
        }

        public static int repetitions(int[] tab, int index, int k)
        {
            int rep = 0;

            if (index < tab.Length)
            {
                if (k == tab[index++]) rep++;
                rep += repetitions(tab, index, k);
            }

            return rep;
        }
    }
}
