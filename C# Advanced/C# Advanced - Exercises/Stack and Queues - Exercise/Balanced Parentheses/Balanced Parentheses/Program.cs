public class Program
{
    public static void Main(string[] args)
    {
        string expression = Console.ReadLine();
        Stack<char> open=new Stack<char>();
        string ans = "YES";
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '(' || expression[i] == '[' || expression[i]=='{')
            {
                open.Push(expression[i]);
            }
            else if (expression[i]==')')
            {
                if(open.Count > 0 && open.Peek()=='(')
                {
                    open.Pop();
                }
                else
                {
                    ans = "NO";
                    break;
                }
            }
            else if (expression[i]==']')
            {
                if(open.Count>0 && open.Peek()=='[')
                {
                    open.Pop();
                }
                else
                {
                    ans = "NO";
                    break;
                }
            }
            else if (expression[i]=='}')
            {
                if(open.Count>0 && open.Peek() =='{')
                {
                    open.Pop();
                }
                else
                {
                    ans = "NO";
                    break;
                }
            }
        }
        if(open.Count==0&&ans=="YES")
        {
            Console.WriteLine(ans);
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}