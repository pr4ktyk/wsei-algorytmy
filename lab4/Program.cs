using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab = new int[] { 7, 5, 6, 3, 4, 2, 1, 8, 9, 3, 5, 7, 6, 3, 4, 2, 1, 8, 9, 3 };
            int[] insertionSort = Table.InsertionSort(tab);
            Table.PrintTable(tab);
            Table.PrintTable(insertionSort);

        }
    }
}
