public class Program
{
    public static void Main(string[] args)
    {
        string equation = Console.ReadLine();
        Stack<int> openBrackets = new Stack<int>();

        for (int i = 0; i < equation.Length; i++)
        {
            if (equation[i] == '(')
            {
                openBrackets.Push(i);
            }
            else if (equation[i] == ')')
            {
                Console.WriteLine(equation.Substring(openBrackets.Peek(), i - openBrackets.Peek()+1));
                openBrackets.Pop();
            }
        }
   
    }
}