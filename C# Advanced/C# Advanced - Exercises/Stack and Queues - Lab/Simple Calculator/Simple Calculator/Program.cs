public class Program
{
    public static void Main(string[] args)
    {
        string[] equation = Console.ReadLine().Split().ToArray();
        Stack<int> nums= new Stack<int>();
        Stack<string> symbols= new Stack<string>();
        for(int i=0;i<equation.Length; i++)
        {
            if (equation[i] == "+" || equation[i]== "-")
            {
                symbols.Push(equation[i]);
            }
            else
            {
                nums.Push(int.Parse(equation[i]));
            }
        }
        int sum = 0;
        while(nums.Count != 0)
        {
            if(symbols.Count != 0)
            {
                if (symbols.Peek() == "-")
                {
                    sum -= nums.Peek();
                }
                else
                {
                    sum+= nums.Peek();
                }
                symbols.Pop();
            }
            else
            {
                sum += nums.Peek();
            }
            nums.Pop();
        }
        Console.WriteLine(sum);
    }
}