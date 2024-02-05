public class Porgram
{
    public static void Main(string[] args)
    {
        string[] read = Console.ReadLine().Split().ToArray();
        Console.WriteLine(String.Join("\n", read.Where(p => p[0] >= 'A' && p[0]<='Z')));
    }
}