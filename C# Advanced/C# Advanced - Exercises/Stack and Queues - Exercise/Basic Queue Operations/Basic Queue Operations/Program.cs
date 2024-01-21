public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            queue.Enqueue(numbers[i]);
        }
        for (int i = 0; i < parameters[1]; i++)
        {
            queue.Dequeue();
        }
        int smallest = 0;
        while (queue.Count != 0)
        {
            if (queue.Peek() == parameters[2])
            {
                Console.WriteLine("true");
                return;
            }
            if (smallest > queue.Peek() || smallest == 0)
            {
                smallest = queue.Peek();
            }
            queue.Dequeue();
        }
        Console.WriteLine(smallest);
    }
}