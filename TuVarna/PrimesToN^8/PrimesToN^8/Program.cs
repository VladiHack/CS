public class Program
{
    static List<long> primes=new List<long>();
    static long size = 100000000;
    public static void SieveOfEratosthenes(long n)
    {
        bool[] prime = new bool[n + 1];

        
        for (long p = 2; p * p <= n; p++)
        {
            if (prime[p] == false)
            {
                for (long i = p * p; i <= n; i += p)
                    prime[i] = true;
            }
        }

       
    }
    public static void Main(string[] args)
    {
        SieveOfEratosthenes(size);
        while(true) 
        {
            string[] parameters = Console.ReadLine().Split().ToArray();
            if (parameters[0]=="quit")
            {
                break;
            }
            if (parameters[0]=="A")
            {
                long left = long.Parse(parameters[1]);
                long right= long.Parse(parameters[2]);
                int counter = 0;
                for (int i = 0; i <primes.Count; i++)
                {
                    if (primes[i]>=left)
                    {
                        if (primes[i]>right)
                        {
                            break;
                        }
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
            else if (parameters[0]=="B")
            {
                long b= long.Parse(parameters[1]);
                for(int i=0;i<primes.Count;i++)
                {
                    if (b % primes[i]==0)
                    {
                        Console.WriteLine(primes[i]);
                        break;
                    }
                }
            }
            else if (parameters[0]=="C")
            {
                long c= long.Parse(parameters[1]);
                if(primes.Contains(c))
                {
                    Console.WriteLine(1);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else if (parameters[0]=="D")
            {
               
            }
        }
    }
}