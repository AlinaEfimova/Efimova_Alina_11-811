using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList2
{
    class Program
    {
        static void Main()
        {
            int[] arr1 = new int[] { 1, 4, 5, 8 };
            MyLinkedList2 mll1 = new MyLinkedList2(arr1);
            Console.WriteLine($"List 1 = {mll1}");

            int[] arr2 = new int[] { 0, 2, 3, 6, 7, 9 };
            MyLinkedList2 mll2 = new MyLinkedList2(arr2);
            Console.WriteLine($"List 2 = {mll2}");

            mll1.Decode();

            //mll1.Insert(7);
            //Console.WriteLine($"Insert = {mll1}");

            //mll1.Delete(5);
            //Console.WriteLine($"Delete = {mll1}");

            //mll1.Merge(mll2);
            //Console.WriteLine($"Merge = {mll1}");

            //var dividedList = mll2.Divide();
            //Console.WriteLine(dividedList[1]);

            Console.ReadKey();
        }
    }
}
