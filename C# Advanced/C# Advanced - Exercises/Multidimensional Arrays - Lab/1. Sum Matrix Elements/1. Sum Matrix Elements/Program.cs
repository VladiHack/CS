public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int rows = parameters[0];int cols= parameters[1];
        int sum = 0;
        for(int i=0;i<rows; i++)
        {
            int[] rowElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            sum += rowElements.Sum();
        }
        Console.WriteLine(rows);
        Console.WriteLine(cols);
        Console.WriteLine(sum);
    }
}