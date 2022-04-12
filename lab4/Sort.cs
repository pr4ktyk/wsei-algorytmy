using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public abstract class Table
    {
        public static int[] InsertionSort(int[] tab)
        {
            int[] sorted = tab.ToArray();

            for (int i = 1; i < sorted.Length; i++)
            {
                for (int j = i-1; j >= 0; j--)
                {

                }
            }

            return sorted;
        }

        public static void PrintTable(int[] tab)
        {
            Console.Write("{ ");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write(i != tab.Length-1 ? $"{tab[i]}, " : $"{tab[i]}");
                
            }
            Console.WriteLine(" }");
        }
    }
}
