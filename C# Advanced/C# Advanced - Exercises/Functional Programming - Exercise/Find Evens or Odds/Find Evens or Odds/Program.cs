public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string oddOrEven=Console.ReadLine();
        for(int i = parameters[0]; i <= parameters[1];i++)
        {
            if (oddOrEven == "even")
            {
                if (i % 2 == 0)
                {
                    Console.Write(i+" ");
                }
            }
            else
            {
                if(i% 2 == 1)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}