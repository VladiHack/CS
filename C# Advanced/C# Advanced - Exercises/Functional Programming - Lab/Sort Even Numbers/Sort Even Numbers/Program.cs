public class Program
{
    public static void Main(string[] args)
    {
        int[] read = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Console.WriteLine(string.Join(", ", read.OrderBy(e=>e).Where(p => p % 2 == 0)));
    }
}