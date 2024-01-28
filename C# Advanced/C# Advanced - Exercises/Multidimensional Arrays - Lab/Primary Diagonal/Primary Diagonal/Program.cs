public class Program
{
    public static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        int sum = 0;
        for(int i=0; i < rows; i++)
        {
            int[] row = Console.ReadLine().Split().Select(int.Parse).ToArray();
            sum += row[i];
        }
        Console.WriteLine(sum);
    }
}