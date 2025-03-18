using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestSubsum
{
    internal class Program
    {

        static void Main()
        {
            int n = 100000; // Change n for different array sizes
            int[] testArray = GenerateRandomArray(n);

            MeasureTime("Kadane’s Algorithm (O(n))", () => Kadane(testArray));
            MeasureTime("Divide and Conquer (O(n log n))", () => DivideAndConquer(testArray));
            MeasureTime("Second Brute Force (O(n²))", () => SecondBruteForce(testArray));
            MeasureTime("First Brute Force (O(n³))", () => FirstBruteForce(testArray));

        }
        // Function to generate an array of n random elements between -100 and 100
        static int[] GenerateRandomArray(int n)
        {
            Random rand = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(-100, 101); // Random values from -100 to 100
            }
            return arr;
        }

        // Function to measure execution time
        static void MeasureTime(string methodName, Func<int> method)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = method(); // Run the method
            stopwatch.Stop();
            Console.WriteLine($"{methodName}: {result} (Time: {stopwatch.ElapsedMilliseconds} ms)");
        }
        // n^3
        public static int FirstBruteForce(int[] s)
        {
            int n = s.Length;
            int maxSum = int.MinValue;  // Initialize maxSum to a very small value

            // Brute-force approach with O(n^3) complexity
            for (int start = 0; start < n; start++)  // First loop to select starting index
            {
                for (int end = start; end < n; end++)  // Second loop to select ending index
                {
                    int sum = 0;
                    for (int k = start; k <= end; k++)  // Third loop to calculate the sum of subarray
                    {
                        sum += s[k];
                    }
                    maxSum = Math.Max(maxSum, sum);  // Update maxSum if a larger sum is found
                }
            }

            return maxSum;  // Return the largest subarray sum
        }
        // n^2
        public static int SecondBruteForce(int[] s)
        {
            int n = s.Length;
            int maxSum = int.MinValue;  // Initialize maxSum to a very small value

            // Brute-force approach with O(n^2) complexity
            for (int start = 0; start < n; start++)  // First loop to select starting index
            {
                int sum = 0;
                for (int end = start; end < n; end++)  // Second loop to select ending index
                {
                    sum += s[end];
                    maxSum = Math.Max(maxSum, sum);  // Update maxSum if a larger sum is found
                }
            }

            return maxSum;  // Return the largest subarray sum
        }
        static int Max(int a, int b) { return (a > b) ? a : b; }
        static int Max(int a, int b, int c)
        {
            return Max(Max(a, b), c);
        }
        static int MaxCrossingSum(int[] arr, int l, int m,
                               int h)
        {
            int sum = 0;

            // Calculate maximum sum on the left side of the
            // midpoint
            int leftSum = int.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum += arr[i];
                leftSum = Math.Max(leftSum, sum);
            }

            // Calculate maximum sum on the right side of the
            // midpoint
            sum = 0;
            int rightSum = int.MinValue;
            for (int i = m; i <= h; i++)
            {
                sum += arr[i];
                rightSum = Math.Max(rightSum, sum);
            }

            // Return the maximum combined sum, or either left
            // or right sum
            return Max(leftSum + rightSum - arr[m], leftSum,
                       rightSum);
        }

        static int MaxSum(int[] arr, int l, int h)
        {
            // Base case: invalid range
            if (l > h)
                return int.MinValue;

            // Base case: single element
            if (l == h)
                return arr[l];

            int m = l + (h - l) / 2;

            return Max(MaxSum(arr, l, m),
                       MaxSum(arr, m + 1, h),
                       MaxCrossingSum(arr, l, m, h));
        }

        // nlogn
        static int DivideAndConquer(int[] arr)
        {
            return MaxSum(arr, 0, arr.Length - 1);
        }

        // n
        static int Kadane(int[] arr)
        {
            int maxSum = int.MinValue;
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                if (sum < 0)
                {
                    sum = 0;
                }
            }

            return maxSum;
        }
    }
}
