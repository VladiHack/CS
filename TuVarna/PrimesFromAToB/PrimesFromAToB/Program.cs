public class Program
{
    static HashSet<long> sums= new HashSet<long>();
    public static void SieveOfEratosthenes(long  n)
    {

        bool[] prime = new bool[n + 1];

        for (long i = 0; i <= n; i++)
            prime[i] = true;

        for (long p = 2; p * p <= n; p++)
        {
            if (prime[p] == true)
            {
                for (long i = p * p; i <= n; i += p)
                    prime[i] = false;
            }
        }
        for(long p=2;p<=n; p++)
        {
            if (prime[p] == true)
            {
                sums.Add(p);
            }
        }
    }
    public static void Main(string[] args)
    {
        long a;long b;
        long[] parameters = Console.ReadLine().Split().Select(long.Parse).ToArray();
        a = parameters[0]; b = parameters[1];
        SieveOfEratosthenes(b);
        foreach (var item in sums)
        {
            Console.WriteLine(item);
        }


    }
}