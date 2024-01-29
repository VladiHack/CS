    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] param = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = param[0];int cols = param[1];
            char[,] matrix=new char[rows,cols];
            for(int i=0;i<rows; i++)
            {
                char[] symbols = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for(int s=0;s<cols;s++)
                {
                    matrix[i,s]= symbols[s];
                }
            }
            int squares = 0;
            for(int i=0;i<rows-1;i++) 
            {
                for(int s=0;s<cols-1;s++)
                {
                    if (matrix[i, s] == matrix[i,s+1] && matrix[i, s] == matrix[i+1,s] && matrix[i, s] == matrix[i+1,s+1])
                    {
                        squares++;
                    }
                }
            }
            Console.WriteLine(squares);
        }
    }