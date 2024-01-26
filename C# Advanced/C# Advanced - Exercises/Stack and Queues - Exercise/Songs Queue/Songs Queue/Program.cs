public class Program
{
    public static void Main(string[] args)
    {
        string[] arr = Console.ReadLine().Split(", ").ToArray();
        Queue<string> queue = new Queue<string>();  
        for(int i=0;i<arr.Length; i++)
        {
            queue.Enqueue(arr[i]);
        }
        while (true)
        {
            string cmd = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(cmd))
            {
                break;
            }
            if (queue.Count() > 0)
            {
                if (cmd.Substring(0, 4) == "Play")
                {
                    queue.Dequeue();
                    if(queue.Count()==0)
                    {
                        Console.WriteLine("No more songs!");
                    }
                }
                else if (cmd.Substring(0, 3) == "Add")
                {
                    string remaining = "";
                    for (int i = 4; i < cmd.Length; i++)
                    {
                        remaining += cmd[i];
                    }
                    if (queue.Contains(remaining) == false)
                    {
                        queue.Enqueue(remaining);
                    }
                    else
                    {
                        Console.WriteLine($"{remaining} is already contained!");
                    }
                }
                else if (cmd.Substring(0, 4) == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
            }
        }
            
    }
}