public class Program
{
    static int n; static int r; static int c;
    static int[] arr = new int[1000005];
    public static void SieveOfEratosthenes(int n)
    {
        bool[] prime = new bool[n + 1];
        for (int p = 2; p * p <= n; p++)
        {
            if (prime[p] == false)
            {
                arr[p]++;
                for (int i = 2 * p; i <= n; i += p)
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
        while (true)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (parameters[0] == 0)
            {
                break;
            }
            n = parameters[0]; r = parameters[1]; c = parameters[2];
            List<List<int>> list = new List<List<int>>();
            int pr = n * n;
            for(int i=1;i<=pr;i++)
            {
                List<int> current = new List<int>();
                current.Add(arr[i]);current.Add(i);
                list.Add(current);
            }
            list.Sort();
            for(int i=0;i<list.Count;i++)
            {
                Console.WriteLine(list[i][0]+" " + list[i][1]);
            }
        }


    }
}