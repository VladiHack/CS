public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Stack<int> stack= new Stack<int>();
        for(int i=0;i<arr.Length; i++)
        {
            stack.Push(arr[i]);
        }
        while (true)
        {
            string msg = Console.ReadLine();
            msg = msg.ToLower();
            if (msg == "end")
            {
                int sum = 0;
                while (stack.Count != 0)
                {
                    sum+= stack.Pop();
                }
                Console.WriteLine("Sum: "+sum);
                break;
            }
            string[] split = msg.Split().ToArray();
            if (split[0] == "add") 
            {
                stack.Push(int.Parse(split[1]));
                stack.Push(int.Parse(split[2]));
            }
            else
            {
                int counter = int.Parse(split[1]);
                if(counter<=stack.Count())
                {
                    while (counter != 0)
                    {
                        counter--;
                        stack.Pop();
                    }
                }
              
            }
        }
        
    }
}