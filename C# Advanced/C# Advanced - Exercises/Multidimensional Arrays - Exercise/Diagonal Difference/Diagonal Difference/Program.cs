public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix=new int[n,n];
        int primary = 0;int secondary = 0;
        for(int i=0;i<n;i++)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            primary += arr[i];
            secondary += arr[n-i-1];
        }
        Console.WriteLine(Math.Abs(primary - secondary));
    }
}