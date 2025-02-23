using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortExample
{
    class Program
    {

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 10000); // Rastgele sayılar
            }
            return arr;
        }
        static void Main(string[] args)
        {
            int[] sizes = { 100, 500, 1000, 5000, 10000 }; // Farklı dizi boyutları

            foreach (int size in sizes)
            {
                int[] arr = GenerateRandomArray(size);
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                BubbleSort(arr);
                stopwatch.Stop();

                Console.WriteLine($"Dizi Boyutu: {size}, Geçen Süre: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}
