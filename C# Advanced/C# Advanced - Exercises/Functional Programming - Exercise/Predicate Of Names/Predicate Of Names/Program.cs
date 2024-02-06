using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
         int length=int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split().ToArray();
        for(int i=0;i<names.Length; i++)
        {
            if (names[i].Length<=length)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}