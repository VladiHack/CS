public class Program
{
   // static Dictionary<int,List<int>> sumPresented=new Dictionary<int,List<int>>();
    static List<int> primes=new List<int>();
    static int longestSeq = 0;
    static string result = "no prime";
    public static void SieveOfEratosthenes(int n)
    {

        bool[] prime = new bool[n + 1];

        for (int i = 0; i <= n; i++)
            prime[i] = true;

        for (int p = 2; p * p <= n; p++)
        { 
            if (prime[p] == true)
            {
                for (int i = p * p; i <= n; i += p)
                    prime[i] = false;
            }
        }
        for(int p=2;p<=n; p++)
        {
            if (prime[p] == true)
            {
                primes.Add(p);
            }
        }
    }
    public static void Main(string[] args)
    {
        int[] parameters=Console.ReadLine().Split().Select(int.Parse).ToArray();
        int a = parameters[0];int b = parameters[1];
        SieveOfEratosthenes(b);
        for (int i=0;i<primes.Count;i++)
        {
            int suma = 0;string res = "";
            for(int s = i; s < primes.Count; s++)
            {
                suma += primes[s];
                res+= primes[s]+" ";
                if(suma>b)
                {
                    break;
                }
                if(s-i+1>longestSeq)
                {
                    if (suma >= a && primes.Contains(suma))
                    {
                        if (s - i + 1 > longestSeq)
                        {
                            longestSeq = s - i + 1;
                            result = $"{suma} {longestSeq}\n{res}";
                        }
                    }
                }
                 
            }
        }
        Console.WriteLine(result);
    }
}