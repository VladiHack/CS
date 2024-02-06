public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int divisors = int.Parse(Console.ReadLine());
        for(int i=arr.Length-1; i>=0; i--)
        {
            if (arr[i] % divisors !=0)
                Console.Write(arr[i]+" ");
        }
    }
}