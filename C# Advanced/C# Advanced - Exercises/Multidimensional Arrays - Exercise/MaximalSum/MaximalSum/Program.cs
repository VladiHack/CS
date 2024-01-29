using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = parameters[0]; int cols = parameters[1];
            long[,] matrix = new long[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                long[] row = Console.ReadLine().Split().Select(long.Parse).ToArray();
                for (int s = 0; s < row.Length; s++)
                {
                    matrix[i, s] = row[s];
                }
            }
            long maxSum = 0;
            string res = "";
            for (int i = 0; i < rows - 2; i++)
            {

                for (int s = 0; s < cols - 2; s++)
                {
                    long sum = matrix[i, s] + matrix[i + 1, s] + matrix[i + 2, s] + matrix[i, s + 1] + matrix[i, s + 2] + matrix[i + 1, s + 1] + matrix[i + 1, s + 2] + matrix[i + 2, s + 1] + matrix[i + 2, s + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        res = matrix[i, s] + " " + matrix[i, s + 1] + " " + matrix[i, s + 2] + "\n" + matrix[i + 1, s] + " " + matrix[i + 1, s + 1] + " " + matrix[i + 1, s + 2] + "\n" + matrix[i + 2, s] + " " + matrix[i + 2, s + 1] + " " + matrix[i + 2, s + 2];
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            Console.WriteLine(res);


        }
    }
}