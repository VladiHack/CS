public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] divisors=Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = divisors.Max(); i <= n; i++)
        {
            if (i >= divisors.Max())
            {
                bool pass = true;
                for(int s=0;s < divisors.Length;s++)
                {
                    if (i % divisors[s] != 0)
                    {
                        pass = false;
                        break;
                    }
                }
                if(pass)
                    Console.Write(i+" ");
            }
        }
    }
}