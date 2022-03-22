using System;
using System.Linq;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] unsorted = new int[] { 7, 5, 6, 3, 4, 2, 1, 8, 9, 3 };
            PrintArray(unsorted);
            int[] sorted = SelectionSort(unsorted);
            PrintArray(sorted);
        }

        public static int[] SelectionSort(int[] arr)
        {
            int[] result = arr.ToArray();

            for (int i = 0; i < result.Length; i++)
            {
                int temp = i;
                for (int j = i + 1; j < result.Length; j++)
                    if (result[j] < result[temp]) temp = j;
                (result[temp], result[i]) = (result[i], result[temp]);
            }

            return result;
        }

        public static void PrintArray(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(i != arr.Length-1 ? $"{arr[i]}, " : $"{arr[i]}");
            }
            Console.WriteLine(" }");
        }
    }
}
