public class Program
{
    static int n; static int r; static int c;
    static int[] arr = new int[1000005];
    static Dictionary<int, int> timesMetCounter = new Dictionary<int, int>();
    public static void SieveOfEratosthenes(int n)
    {


        bool[] prime = new bool[n + 1];
        for (int p = 2; p * p <= n; p++)
        {
            if (prime[p] == false)
            {
                arr[p]++;
                for (long i = 2 * p; i <= n; i += p)
                {
                    prime[i] = true;
                    arr[i]++;
                }

            }
        }

    }
    public static void Main(string[] args)
    {
        int calc = 1000 * 1000;
        arr[1] = 1;
        SieveOfEratosthenes(calc);
        Console.WriteLine(String.Join(",", arr)); 
        while (true)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (parameters[0] == 0)
            {
                break;
            }
            n = parameters[0]; r = parameters[1]; c = parameters[2];
            int constanta = (r - 1) * n + c;
            int count = 1;
            for (int i = 1; i <= n * n; i++)
            {
                if (timesMetCounter.ContainsKey(arr[i]))
                {
                    timesMetCounter[arr[i]]++;
                }
                else
                {
                    timesMetCounter.Add(arr[i], 1);
                }
            }
            List<int> finalArrangement = new List<int>();
            while (true)
            {
                if (timesMetCounter.ContainsKey(count))
                {
                    if (constanta - timesMetCounter[count] > 0)
                    {
                        constanta -= timesMetCounter[count];
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
               
            }
                for (int i = 1; i <= n * n; i++)
                {
                    if (arr[i] == count)
                    {
                        constanta--;
                        if (finalArrangement.Count == constanta)
                        {
                        Console.WriteLine(i);
                        break;
                        }
                    }
                }
           
        }


    }
}