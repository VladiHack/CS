public class Program
{
    public static void Main(string[] args)
    {
        while(true)
        {
            string[] parameters = Console.ReadLine().Split().ToArray();
            if (parameters[0]=="exit")
            {
                break;
            }
            int n = int.Parse(parameters[0]); int q =int.Parse(parameters[1]);
            List<string> arr = new List<string>();
            List<string> original = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                arr.Add(text);
                original.Add(text);
            }
            arr.Sort();
            for (int i = 0; i < q; i++)
            {
                string[] parm = Console.ReadLine().Split(" ").ToArray();
                int number = int.Parse(parm[0]);
                string start = parm[1];
                int index = 0; bool met = false; int repeatedLast = 0; string last = "";
                for (int s = 0; s < arr.Count; s++)
                {
                    string current = arr[s].Substring(0, start.Length);
                    if (current == start)
                    {
                        index++;
                        if (last == arr[s])
                        {
                            repeatedLast++;
                        }
                        else
                        {
                            last = arr[s];
                            repeatedLast = 1;
                        }
                        if (index == number)
                        {
                            met = true;
                            for (int l = 0; l < arr.Count; l++)
                            {
                                if (original[l] == last)
                                {
                                    repeatedLast--;
                                    if (repeatedLast == 0)
                                    {
                                        Console.WriteLine(l + 1);
                                    }
                                }
                            }
                            break;
                        }
                    }
                }
                if (!met)
                {
                    Console.WriteLine(-1);
                }
            }
        }
       
    }
}