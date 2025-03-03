using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinMaxBinarySearch
{
    class Program
    {
        static void Main()
        {
            int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] unsortedArray = { 8, 5, 3, 2, 7, 6, 4, 1 };
            int searchValue = 7;

            Console.WriteLine("N is: " + sortedArray.Length);
            Console.WriteLine();

            Console.WriteLine("Testing Min Function:");
            Console.WriteLine("Best Case (First Element is Min): " + Min(sortedArray));
            Console.WriteLine("Worst Case (Last Element is Min): " + Min(unsortedArray));

            Console.WriteLine("\nTesting Max Function:");
            Console.WriteLine("Best Case (First Element is Max): " + Max(sortedArray.Reverse().ToArray()));
            Console.WriteLine("Worst Case (Last Element is Max): " + Max(unsortedArray.Reverse().ToArray()));

            Console.WriteLine("\nTesting Linear Search:");
            Console.WriteLine("Best Case (First Element Match): " + LinearSearch(sortedArray, sortedArray[0]));
            Console.WriteLine("Worst Case (Last Element Match): " + LinearSearch(sortedArray, sortedArray[sortedArray.Length - 1]));

            Console.WriteLine("Average Case (Middle Element Match): " + LinearSearch(sortedArray, sortedArray[(sortedArray.Length - 1) / 2]));

            Console.WriteLine("\nTesting Binary Search:");
            Console.WriteLine("Best Case (Middle Element Match): " + BinarySearch(sortedArray, sortedArray[(sortedArray.Length - 1) / 2]));
            Console.WriteLine("Worst Case (Not Found Case): " + BinarySearch(sortedArray, 100));
            Console.WriteLine("Average Case (Random Element Match): " + BinarySearch(sortedArray, searchValue));
        }

        static int Min(int[] arr)
        {
            int control = 1;
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                control++;
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return control;
        }
        static int Max(int[] arr)
        {
            int control = 1;
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                control++;
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return control;
        }
        static int LinearSearch(int[] arr, int value)
        {
            int control = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                control++;
                if (arr[i] == value)
                {
                    break;
                }
            }
            return control;
        }

        static int BinarySearch(int[] arr, int value)
        {
            int n = arr.Length;
            int[] arrCpy = new int[n];
            Array.Copy(arr, arrCpy, n);
            Array.Sort(arrCpy);

            int control = 0;

            int left = 0;
            int right = n - 1;

            while (left <= right)
            {
                control++;
                int mid = (left + right) / 2;
                if (value > arrCpy[mid])
                    left = mid + 1;
                else if (value < arrCpy[mid])
                    right = mid - 1;
                else
                    break;
            }

            return control;
        }
    }
}
