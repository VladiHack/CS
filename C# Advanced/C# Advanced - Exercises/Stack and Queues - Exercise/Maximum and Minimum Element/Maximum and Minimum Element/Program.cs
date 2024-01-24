public class Program
{
    public static void Main(string[] args)
    {
        int commands = int.Parse(Console.ReadLine());
        Stack<int> stack = new Stack<int>();
        for(int i=0;i<commands; i++)
        {
            int[] line=Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (line[0] == 1)
            {
                stack.Push(line[1]);
            }
            else if (line[0] == 2)
            {
                stack.Pop();
            }
            else if (line[0] == 3&&stack.Count()!=0)
            {
                Console.WriteLine(stack.Max());
            }
            else if (line[0]==4&&stack.Count()!=0) 
            {
                Console.WriteLine(stack.Min());
            }
        }
        Console.WriteLine(String.Join(", ",stack));

    }
}