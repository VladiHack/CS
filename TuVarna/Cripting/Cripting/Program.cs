public class Program
{
    public static void Main(string[] args)
    {
        string read = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        string newRead = read.Substring(read.Length - n , n);
        for(int i=0;i<newRead.Length;i++)
        {
            Console.Write((char)(newRead[i] + n));
        }
        for(int i=0;i<read.Length-n;i++)
        {
            Console.Write((char)(read[i] + n));
        }
    }
}