using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowFunction
{
    internal class Program
    {
        static int callCount = 0;  // Static counter to count function calls
        static void Main()
        {
            // Testing PowFunctionLinear
            Console.WriteLine("Testing PowFunctionLinear:");
            callCount = 0;
            int resultLinear = PowFunctionLinear(2, 16);
            Console.WriteLine($"Result of PowFunctionLinear: {resultLinear}");
            Console.WriteLine($"Function calls in PowFunctionLinear: {callCount}");

            Console.WriteLine();  // Separate tests for clarity

            // Testing PowFunctionRecursive
            Console.WriteLine("Testing PowFunctionRecursive:");
            callCount = 0;  // Reset counter before each test
            int resultRecursive = PowFunctionRecursive(2, 16);
            Console.WriteLine($"Result of PowFunctionRecursive: {resultRecursive}");
            Console.WriteLine($"Function calls in PowFunctionRecursive: {callCount}");
        }

        static int PowFunctionLinear(int x, int y)
        {
            int result = 1;

            for (int i = 0; i < y; i++)
            {
                callCount++;
                result *= x;
            }

            return result;
        }

        static int PowFunctionRecursive(int x, int y)
        {
            callCount++;  // Increment counter each time the function is called
            int m;
            if (y == 0)
                return 1;

            if (y % 2 == 1)
                return x * PowFunctionRecursive(x, y - 1);

            m = PowFunctionRecursive(x, y / 2);
            return m * m;
        }
    }
}
