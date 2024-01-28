public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long[,] matrix=new long[n,n];
        for(int i=0;i<n;i++)
        {
            matrix[i, 0] = 1;
        }
        for (int i = 1; i < n; i++)
        {
            for(int s=1;s<=i;s++)
            {
                matrix[i, s] = matrix[i-1, s ] + matrix[i - 1, s - 1];
            }
        }
        for(int i=0;i<n;i++)
        {
            for(int k=0;k<=i;k++)
            {
                Console.Write(matrix[i,k]+" ");
            }
            Console.WriteLine();
        }
    }
}