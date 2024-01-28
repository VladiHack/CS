using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int[] par = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int rows = par[0]; int cols = par[1];
        int[,] matrix= new int[rows, cols];
        for(int i=0; i < rows; i++)
        {
            int[] row= Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            for (int s = 0;s < cols; s++)
            {
                matrix[i,s]= row[s];
            }
        }
        int maxSum = 0;
        string res = "";
        for(int i=0;i<rows-1; i++)
        {
            for(int k=0;k<cols-1; k++)
            {
                if (matrix[i, k] + matrix[i + 1, k] + matrix[i, k + 1] + matrix[i + 1, k + 1] > maxSum)
                {
                    maxSum = matrix[i, k] + matrix[i + 1, k] + matrix[i, k + 1] + matrix[i + 1, k + 1];
                    res = matrix[i,k]+" " + matrix[i, k+1] + "\n" + matrix[i+1,k]+ " " + matrix[i+1, k+1];
                }
            }
        }
        Console.WriteLine(res+"\n"+maxSum);
    }
   
}