public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] dp=new int[arr.Length];
        dp[0] = arr[0];
        dp[1] = arr[1];
        for(int i=2;i<arr.Length; i++)
        {
            dp[i] = Math.Min(dp[i - 1], dp[i - 2]) + arr[i];
        }
        Console.WriteLine(Math.Min(dp[arr.Length - 1], dp[arr.Length-2]));
    }
}