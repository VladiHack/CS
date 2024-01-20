public class Program
{
    static int MOD;
    static long Power(long x, int n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n % 2 == 0)
        {
            var p = Power(x, n / 2)%MOD;
            return ((p%MOD) *(p%MOD))%MOD;
        }
        else
        {
            return ((x%MOD) * (Power(x, n - 1)%MOD))%MOD;
        }
    }
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = parameters[0]; int y = parameters[1]; int n = parameters[2];
            MOD = n;
            Console.WriteLine(Power(x,y));
        }
        string zero = Console.ReadLine();


    }
}

