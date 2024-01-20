using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t;i++)
        {
            long[] parameters = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long n = parameters[0];long h = parameters[1];
            long[] arr = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long v = 0;
            for(int s=0;s<arr.Length;s++)
            {
                v += arr[s];
                if (s != 0 && s != arr.Length - 1 && arr[s]<h && arr[s] < arr[s-1] && arr[s] < arr[s+1])
                {
                    long minH = Math.Min(arr[s - 1], arr[s + 1]);
                    minH=Math.Min(minH, h);
                    v += minH - arr[s];
                }
            }
            Console.WriteLine(v*100);
        }
     }
}