using System;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ex1 = { 11, 22, 33, 44, 55 };
            Console.WriteLine($"Zadanie 1: {sumOfTable(ex1, 0)}");

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
    }
}
