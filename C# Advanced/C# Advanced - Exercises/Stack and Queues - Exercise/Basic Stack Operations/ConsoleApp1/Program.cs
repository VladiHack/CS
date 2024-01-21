public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters=Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> stack= new Stack<int>();
        for(int i=0;i<nums.Length; i++)
        {
            stack.Push(nums[i]);
        }
        for (int i = 0; i < parameters[1]; i++)
        {
            stack.Pop();
        }
        int smallest = 0;
        while(stack.Count!=0)
        {
            if (parameters[2]==stack.Peek())
            {
                Console.WriteLine("true");
                return;
            }
            if (stack.Peek() < smallest || smallest == 0)
            {
                smallest = stack.Peek();
            }
            stack.Pop();
        }
        Console.WriteLine(smallest);

    }
}