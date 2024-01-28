using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int row = int.Parse(Console.ReadLine());
        char[,] matrix=new char[row,row];
        for(int i=0; i < row; i++)
        {
            string symbol = Console.ReadLine();
            for(int s=0;s<row; s++)
            {
                matrix[i, s] = symbol[s];
            }
        }
        string read = Console.ReadLine();
        char searchedSymbol = read[0];
        for (int i = 0; i < row; i++)
        {
            for (int k = 0; k < row; k++)
            { 
               
                if (searchedSymbol == matrix[i,k])
                {
                    Console.WriteLine($"({i}, {k})");
                    return;
                }
               
            }
        }
        Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
    }
}