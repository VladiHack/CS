public class Program
{
    public static void Main(string[] args)
    {
        int food = int.Parse(Console.ReadLine());
        int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Queue<int> queue = new Queue<int>();
        int biggest = -1;
        for(int i=0; i<orders.Length; i++)
        {
            if (food>=orders[i])
            {
                biggest = Math.Max(orders[i], biggest);
                food -= orders[i];
            }
            else
            {
                queue.Enqueue(orders[i]);
            }
        }
        Console.WriteLine(biggest);
        if (queue.Count ==0)
        {
            Console.WriteLine("Orders complete");
        }
        else
        {
            Console.WriteLine($"Orders left: {String.Join(" ",queue)}");
        }
    }
}