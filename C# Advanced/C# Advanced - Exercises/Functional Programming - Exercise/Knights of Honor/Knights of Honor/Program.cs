public class Program
{
    public static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split().ToArray();
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Sir {names[i]}");
        }
    }
}