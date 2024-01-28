public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int rows = parameters[0];int cols = parameters[1];
        int[,] matrix= new int[rows, cols];
        for(int i=0;i < rows;i++)
        {
            int[] row=Console.ReadLine().Split().Select(int.Parse).ToArray();
            for(int s=0;s<cols;s++)
            {
                matrix[i,s] = row[s];
            }
        }
        for(int i=0;i<cols;i++)
        {
            int sum = 0;
            for(int k=0;k<rows;k++)
            {
                sum += matrix[k,i];
            }
            Console.WriteLine(sum);
        }
    }
}