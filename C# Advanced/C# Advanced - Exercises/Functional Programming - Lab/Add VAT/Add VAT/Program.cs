public class Program
{
    public static void Main(string[] args)
    {
        double[] arr = Console.ReadLine().Split(", ").Select(double.Parse).ToArray();
        for (int i=0;i<arr.Length; i++)
        {
            double num = arr[i]*1.2;
            Console.WriteLine($"{num:F2}");
        }
    }
}