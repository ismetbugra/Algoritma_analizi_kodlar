using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortAnalysisNotation
{
    internal class Program
    {
        static void Main()
        {
            // Big O = worst case scenario
            // Big Delta = best case scenario
            // Big Theta = average case scenario

            int[] sortedArray = [3, 4, 5, 6, 10, 12, 15, 20, 23, 100];
            int[] unsortedArray = [12, 3, 6, 4, 10, 5, 11, 7, 9, 8];
            int n = sortedArray.Length;
            Console.WriteLine("Size n: " + n + "\n");

            Console.Write("Unoptimized Bubble Sort O value: ");
            int resOne = BubbleSortUnOptimized(unsortedArray);
            Console.WriteLine(resOne);

            Console.Write("Optimized Bubble Sort O value: ");
            int resTwo = BubbleSortOptimized(unsortedArray);
            Console.WriteLine(resTwo);

            Console.WriteLine();

            Console.Write("Unoptimized Bubble Sort Delta value: ");
            int resThree = BubbleSortUnOptimized(sortedArray);
            Console.WriteLine(resThree);

            Console.Write("Optimized Bubble Sort Delta value: ");
            int resFour = BubbleSortOptimized(sortedArray);
            Console.WriteLine(resFour);

            Console.WriteLine();

            Random rand = new();
            int trials = 100;
            int totalUnoptimized = 0, totalOptimized = 0;

            for (int t = 0; t < trials; t++)
            {
                int[] randomArray = new int[n];
                for (int i = 0; i < n; i++)
                {
                    randomArray[i] = rand.Next(1, 101); // Fill with random numbers from 1 to 100
                }

                totalUnoptimized += BubbleSortUnOptimized(randomArray);
                totalOptimized += BubbleSortOptimized(randomArray);
            }

            Console.WriteLine("Average comparisons (Unoptimized Bubble Sort): " + (totalUnoptimized / trials));
            Console.WriteLine("Average comparisons (Optimized Bubble Sort): " + (totalOptimized / trials));


            // For the unoptimized bubble sort, the best case scenario is the same as the worst case meaning n^2.
            // For the optimized bubble sort, the best case scenario is n. Worst case is n^2.
        }

        static int BubbleSortUnOptimized(int[] originalArr)
        {
            int n = originalArr.Length;

            int[] arr = new int[n];
            Array.Copy(originalArr, arr, n);

            int numberOfComparisons = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                    }
                    numberOfComparisons++;
                }
            }
            return numberOfComparisons;
        }

        static int BubbleSortOptimized(int[] originalArr)
        {
            int n = originalArr.Length;

            int[] arr = new int[n];
            Array.Copy(originalArr, arr, n);

            int numberOfComparisons = 0;
            for (int i = 0; i < n - 1; i++)
            {
                bool noSwap = true;
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j + 1], arr[j]) = (arr[j], arr[j + 1]);
                        noSwap = false;
                    }
                    numberOfComparisons++;
                }
                if (noSwap)
                {
                    break;
                }
            }
            return numberOfComparisons;
        }
    }
}
