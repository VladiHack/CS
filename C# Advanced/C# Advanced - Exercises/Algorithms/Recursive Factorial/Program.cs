public class Program
{
    static long fact = 1;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Factorial(n);
        Console.WriteLine(fact);
    }
    public static void Factorial(int n)
    {
        if(n==1)
        {
            return;
        }
        fact *= n;
        Factorial(n - 1);
    }
}