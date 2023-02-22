using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1004
{
    public class ReverseComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    public class ReverseComparer1 : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }

    internal class _08_Sort
    {
        int[] a = { 1, 2, 3, 4, 5, 6, 7 };

       public static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 54, 54, 2, 3132, 132, 1, 321, 3412 };

            Array.Sort(arr, new ReverseComparer());

            foreach(int value in arr)
            {
                Console.Write(value+", ");
            }

            Console.WriteLine("\n");
            string[] arr2 = { "adf", "afsdfs", "dffdfd", "vczzxcz", "123erwqweq" };

            Array.Sort(arr2, new ReverseComparer1());

            foreach (string value in arr2)
            {
                Console.Write(value + ", ");
            }

        }
    }
}
