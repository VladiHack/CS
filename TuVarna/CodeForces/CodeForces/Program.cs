public class Program
{
    public static void Main(string[] args)
    {
        int tests = int.Parse(Console.ReadLine());
        for(int i=0;i<tests;i++)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = arr[0];int k = arr[1];
            int[] readNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if(readNums.Contains(k))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}