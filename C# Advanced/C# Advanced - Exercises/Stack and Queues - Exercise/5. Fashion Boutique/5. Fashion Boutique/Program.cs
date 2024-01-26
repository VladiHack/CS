public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> stack= new Stack<int>();
        int capacity = int.Parse(Console.ReadLine());
        for(int i=0;i<arr.Length; i++)
        {
            stack.Push(arr[i]);
        }
        int currentCapacity = capacity;
        int used = 1;
        while (stack.Count() != 0)
        {
            if(stack.Peek()<=currentCapacity)
            {
                currentCapacity -= stack.Pop();
            }
            else
            {
                used++;
                currentCapacity = capacity;
                currentCapacity-=stack.Pop();
            }
        }
        Console.WriteLine(used);
    }
}