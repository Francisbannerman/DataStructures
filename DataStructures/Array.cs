using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello Data Structures");
    //        Console.WriteLine();

    //        Arrays arr = new Arrays();

    //        Console.ReadLine();
    //    }
    //}

    public class Arrays
    {
        char[] chars = new char[] { };

        public void Reverse(string word)
        {
            chars = word.ToCharArray();

            if (chars.Length < 2 || word.GetType() != typeof(string))
            {
                Console.WriteLine("Masa why. This isn't a string.");
            }
            for (int i = word.Length - 1; i >= 0; i--)
            {
                Console.Write(chars[i].ToString());
            }
        }

        public void ReverseArray(string[] input)
        {
            if (input.Length < 2 || input.GetType() != typeof(string[]))
            {
                Console.WriteLine("Masa why. This ain't a string array.");
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                string reversedInput = input[i];
                Console.WriteLine(reversedInput);
            }
        }

        public void Merge(int[] arr1, int[] arr2)
        {
            int[] merged = new int[arr1.Length + arr2.Length];
            int i = 1;
            int j = 1;
            var array1item = arr1[0];
            var array2item = arr2[0];

            while (arr1 != null || arr2 != null)
            {
                if (arr1[0] < arr2[0] && i < arr1.Length)
                {
                    merged.Append(arr1[0]).ToArray();
                    arr1[0] = arr1[i];
                    i++;
                }
                else if (arr2[0] < arr1[0] && j < arr2.Length)
                {
                    merged.Append(arr2[0]).ToArray();
                    arr2[0] = arr2[j];
                    j++;
                }
            }
            foreach (var item in merged)
            {
                Console.WriteLine(item);
            }
        }

        public string[] Append(string[] array, string item)
        {
            array = array.Append(item).ToArray();
            return array;
        }

        public string[] Prepend(string[] array, string item)
        {
            array = array.Prepend(item).ToArray();
            return array;
        }

        public string[] InsertByCopyToNewArray(string[] array, string item, int pos)
        {
            string[] newarray = new string[array.Length+1];

            for (int i = 0; i < array.Length+1; i++)
            {
                if (i < pos - 1)
                {
                    newarray[i] = array[i];
                }
                else if (i == pos - 1)
                {
                    newarray[i] = item;
                }
                else
                {
                    newarray[i] = array[i-1];
                }
            }
            return newarray;
        }

        public string[] InsertByShifting(string[] array, string item, int pos)
        {
            for (int i = array.Length-1; i>= pos; i--)
            {
                array[i] = array[i - 1];
            }
            array[pos - 1] = item;
            return array;
            //remember to keep the string[] array size bigger than the actual element size as insert does not increase array size
        }

        public string[] DeleteByIndex(string[] array, int pos)
        {
            //convert the array to a list
            var arrayList = array.ToList();
            //use the 'removeAt' function of lists to remove at said position
            arrayList.RemoveAt(pos);
            //convert list back to an array
            array = arrayList.ToArray();
            //return original array without the item in the index
            return array;
        }

        public string[] DeleteByItem(string[] array, string item)
        {
            //convert the array to a list
            var arrayList = array.ToList();
            //use the 'remove' function of lists to remove the first instance of the item
            arrayList.Remove(item);
            //convert list back to an array
            array = arrayList.ToArray();
            //return original array without the item in it
            return array;
        }

        public string[] DeleteAllOfItem(string[] array, string item)
        {
            //convert the array to a list
            var arrayList = array.ToList();
            //use the 'remove' function of lists to remove the first instance of the item
            arrayList.RemoveAll(x => x == item);
            //convert list back to an array
            array = arrayList.ToArray();
            //return original array without the item in it
            return array;
        }
    }
}