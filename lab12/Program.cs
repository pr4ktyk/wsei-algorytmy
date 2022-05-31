using System;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            if (IsPalindrome("a")
                && IsPalindrome("aaa")
                && IsPalindrome("")
                && IsPalindrome("zakaz")
                && IsPalindrome("ZaKAZ")
                && IsPalindrome("KamilSlimak")
                && !IsPalindrome("abc")
                )
            {
                Console.WriteLine("Zadanie 1: ok");
                points++;
            }

            if (IsAnagram("abcd", "bcda")
                && IsAnagram("aa", "aa")
                && !IsAnagram("AA", "aa")
                && IsAnagram("", "")
                && !IsAnagram("abc", "abca")
                )
            {
                Console.WriteLine("Zadanie 2: ok");
                points++;
            }

            if (LongestIdenticalString("aaaa").Equals("aaaa")
                && LongestIdenticalString("abcddddaaddd").Equals("dddd")
                && LongestIdenticalString("abcd").Equals("a")
                && LongestIdenticalString("abbcdd").Equals("bb")
                )
            {
                Console.WriteLine("Zadanie 3: ok");
                points += 2;
            }
            Console.WriteLine(points);
        }

        // Czy jest palindromem
        public static bool IsPalindrome(string input)
        {
            input = input.ToLower();
            char[] arr = input.ToCharArray();

            for (int i = 0, j = arr.Length-1; i < (arr.Length / 2) && j > (arr.Length / 2); i++, j--)
            {
                if (!(arr[i] == arr[j])) return false;
            }

            return true;
        }

        // Czy łańcuchy są anagramami
        public static bool IsAnagram(string a, string b)
        {
            char[] arr1 = a.ToCharArray();
            char[] arr2 = b.ToCharArray();

            Array.Sort(arr1);
            Array.Sort(arr2);

            for (int i = 0; i < arr1.Length; i++)
            {
                if (!(arr1[i] == arr2[i]))  return false;
            }
            return true;
        }

        //zwróć pierwszy najdłuższy fragment z powtarzających znaków wejścia
        public static string LongestIdenticalString(string input)
        {
            char[] arr = input.ToCharArray();

            string temp = "";
            string result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    temp = arr[i].ToString();
                } else if (arr[i] == arr[i-1])
                {
                    temp += arr[i].ToString();
                }

                if (temp.Length > result.Length)
                {
                    result = temp;
                }

                if (i != 0 && !(arr[i] == arr[i - 1]))
                {
                    temp = arr[i].ToString();
                }
            }
            return result;
        }
    }
}