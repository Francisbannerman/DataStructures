using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Data Structures\n");
            string[] arr1 = new string[6];
            arr1[0] = "1";
            arr1[1] = "2";
            arr1[2] = "3";
            arr1[3] = "4";
            arr1[4] = "5";
            string arr2 = "9";
            Console.WriteLine(arr1.Length+"\n");

            Arrays arrays= new Arrays();

            var results = arrays.DeleteByIndex(arr1, 2);

            foreach(var item in results )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n"+arr1.Length);

            Console.ReadKey();

            //Console.WriteLine("Hello Data Structures");
            //Console.WriteLine();
            //string item1 = "sicnarf";
            //string[] item2 = new string[] { "s", "i", "c", "n", "a", "r", "c", "f" };

            //int[] intItem1 = { 1, 5, 8, 10, 12 };
            //int[] intItem2 = { 4, 7, 9, 11, 15 };


            //Arrays arrays = new Arrays();
            ////arrays.Reverse(item1);
            ////arrays.ReverseArray(item2);
            ////arrays.Merge(intItem1, intItem2);
            ////var results = arrays.DeleteByIndex(item2, 2);
            ////var results = arrays.DeleteByItem(item2, "c");
            //var results = arrays.DeleteAllOfItem(item2, "c");

            //foreach (string item in results)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.ReadKey();
        }
    }
}