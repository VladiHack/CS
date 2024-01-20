public class Program
{
    public static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        for (int i = 0; i <arr.Length; i++)
        {
            queue.Enqueue(arr[i]);
        }
        bool first=true;
        while(queue.Count != 0)
        {
            if (queue.Peek() % 2 == 0)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    Console.Write(", ");
                }

                Console.Write(queue.Peek());
                
            }
            queue.Dequeue();

        }
    }
}