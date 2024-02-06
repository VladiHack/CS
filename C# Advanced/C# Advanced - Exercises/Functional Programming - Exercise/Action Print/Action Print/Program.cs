public class Program
{
    public static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split().ToArray();
        Console.WriteLine(string.Join("\n",names));
    }
}