public class Program
{
    public static void Main(string[] args)
    {
        Stack<string> reverseString=new Stack<string>();
        string msg = Console.ReadLine();
        for (int i = 0; i < msg.Length; i++)
        {
            reverseString.Push(msg[i].ToString());
        }
        while(reverseString.Count!=0)
        {
            Console.Write(reverseString.Pop());
        }
    }
}