public class Program
{
    static int sum = 0;
   public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Recursion(arr, 0);
        Console.WriteLine(sum);
    }
    public static void Recursion(int[] arr,int index)
    {
       
        if(index==arr.Length)
        {
            return;
        }
        sum += arr[index];
        Recursion(arr, index + 1);
    }
}