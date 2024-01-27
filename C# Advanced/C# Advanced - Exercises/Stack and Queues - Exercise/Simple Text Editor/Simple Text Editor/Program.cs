public class Program
{
    public static void Main(string[] args)
    {
        Stack<string> textConditions=new Stack<string>();
        int commands = int.Parse(Console.ReadLine());
        for (int i = 0; i < commands; i++)
        {
            string[] cmds = Console.ReadLine().Split().ToArray();
            if (cmds[0] == "1")
            {
                if(textConditions.Count > 0)
                textConditions.Push(textConditions.Peek()+cmds[1]);
                else textConditions.Push(cmds[1]);
            }
            else if (cmds[0]=="2")
            {
                string newMsg = textConditions.Peek();
                newMsg = newMsg.Substring(0, newMsg.Length - int.Parse(cmds[1]));
                textConditions.Push(newMsg);
            }
            else if (cmds[0] == "3")
            {
                string msg=textConditions.Peek();
                Console.WriteLine(msg[int.Parse(cmds[1])-1]);
            }
            else
            {
                textConditions.Pop();
            }
        }
    }
}