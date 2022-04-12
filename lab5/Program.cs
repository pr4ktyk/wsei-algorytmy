/*using System;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 3, 2, 7, 1, 9, 8 };
        }
    }

    public class MergeSortInPLace
    {
        public static void Sort(int[] arr)
        {
            SortArray(arr, 0, arr.Length - 1);
        }
        private static void SortArray(int[] arr, int left, int right)
        {
            if (left == right)
            {
                return;
            }
            if (left + 1 == right)
            {
                if (arr[left] > arr[right])
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                }
            }
            var mid = (left + right) / 2;
            SortArray(arr, left, mid);
            SortArray(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
        //zaimplementuj tę metodę, tak, aby wykonać scalanie w miejscu
        //left  - indeks pierwszego elementu pierwszej podtablicy
        //mid   - indeks ostatniego elementu pierwszej podtablicy
        //right - indeks ostatniego elementu drugiej podtablicy
        //Przykład
        //arr   => {2, 4, 6, 3, 5, 8, 11, 7}
        //left  => 0
        //mid   => 2
        //right => 5
        //po wykonaniu scalania tablica arr powinna mieć postać:
        //arr => {2, 3, 4, 5, 6, 8, 11, 7}
        private static void Merge(int[] arr, int left, int mid, int right)
        {

            var result = new int[arr1.Length + arr2.Length];
            for (int i = 0, j1 = 0, j2 = 0; i < result.Length; i++)
            {
                if (j1 < arr1.Length && j2 < arr2.Length)
                {
                    result[i] = arr1[j1] < arr2[j2] ? arr1[j1++] : arr2[j2++];
                    continue;
                }
                if (j1 < arr1.Length)
                {
                    result[i] = arr1[j1++];
                    continue;
                }
                if (j2 < arr2.Length)
                {
                    result[i] = arr2[j2++];
                }

            }
        }
}*/