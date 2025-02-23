using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KthSelectionExample
{
    class Program
    {
        static int FindKthSmallest_Sort(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[k - 1];
        }

        static int FindKthSmallest_Insertion(int[] arr, int k)
        {
            int[] temp = new int[k];
            Array.Copy(arr, temp, k);
            Array.Sort(temp);

            for (int i = k; i < arr.Length; i++)
            {
                if (arr[i] < temp[k - 1])
                {
                    temp[k - 1] = arr[i];

                    int j = k - 2;
                    while (j >= 0 && temp[j] > temp[j + 1])
                    {
                        int tempVal = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tempVal;
                        j--;
                    }
                }
            }
            return temp[k - 1];
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 10000);
            }
            return arr;
        }

        static void Main()
        {
            int[] sizes = { 100, 500, 1000, 5000, 10000 };
            int k = 10;

            foreach (int size in sizes)
            {
                int[] arr1 = GenerateRandomArray(size);
                int[] arr2 = (int[])arr1.Clone();

                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                int result1 = FindKthSmallest_Sort(arr1, k);
                stopwatch.Stop();
                Console.WriteLine($"Dizi Boyutu: {size}, Sıralama Yöntemi Süre: {stopwatch.ElapsedMilliseconds} ms, Sonuç: {result1}");

                stopwatch.Restart();
                int result2 = FindKthSmallest_Insertion(arr2, k);
                stopwatch.Stop();
                Console.WriteLine($"Dizi Boyutu: {size}, Kademeli Sıralama Süre: {stopwatch.ElapsedMilliseconds} ms, Sonuç: {result2}");
            }
        }
    }
}
