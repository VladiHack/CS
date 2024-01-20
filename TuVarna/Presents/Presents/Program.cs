public class Program
{
    
        public static long nCr(int n, int r)
        {
            // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
            return nPr(n, r) / Factorial(r);
        }

        public static long nPr(int n, int r)
        {
            // naive: return Factorial(n) / Factorial(n - r);
            return FactorialDivision(n, n - r);
        }

        private static long FactorialDivision(int topFactorial, int divisorFactorial)
        {
            long result = 1;
            for (int i = topFactorial; i > divisorFactorial; i--)
                result *= i;
            return result;
        }

        private static long Factorial(int i)
        {
            if (i <= 1)
                return 1;
            return i * Factorial(i - 1);
        }
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for(int i=0;i<n;i++)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k1 = parameters[0];int k2 = parameters[1];int n1 = parameters[2];int n2= parameters[3];
            Console.WriteLine(nCr(n1, k1) * nCr(n2, k2));
        }
    }
}