using System;
using System.Collections;
using System.Collections.Generic;

namespace lab9
{
    class Program
    {
        class HashTable : IEnumerable
        {
            List<int>[] arr = new List<int>[101];

            public bool Add(int value)
            {
                int hashCode = HashCode(value);
                if (arr[hashCode] == null)
                {
                    arr[hashCode] = new List<int>();
                }
                if (arr[hashCode].Contains(value)) return false;
                else
                {
                    arr[hashCode].Add(value);
                    return true;
                }
            }

            public bool Remove(int value)
            {
                int hashCode = HashCode(value);

                if (arr[hashCode] == null) return false;
                if (!arr[hashCode].Contains(value)) return false;
                else
                {
                    arr[hashCode].Remove(value);
                    return true;
                }
            }

            public bool Contains(int value)
            {
                int hashCode = HashCode(value);
                if(arr[hashCode] != null && arr[hashCode].Contains(value)) return true;
                else return false;
            }

            private int HashCode(int value)
            {
                return Math.Abs(value.GetHashCode()) % arr.Length;
            }

            public IEnumerator<int> GetEnumerator()
            {
                foreach (List<int> list in arr)
                {
                    if (list != null)
                    {
                        foreach (var item in list)
                        {
                            if (item != null)
                            {
                                yield return item;
                            }
                        }
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("".GetHashCode());
            Console.WriteLine("".GetHashCode());
            Console.WriteLine(3.GetHashCode());
            Console.WriteLine();

            HashTable table = new HashTable();
            table.Add(4);
            table.Add(-3);
            table.Add(6);
            table.Add(3);

            Console.WriteLine(table.Add(3));

            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
}
