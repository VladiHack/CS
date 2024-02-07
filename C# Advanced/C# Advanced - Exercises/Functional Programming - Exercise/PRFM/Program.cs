public class Program
{
    public static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split().ToArray();
        bool[] filter = new bool[names.Length];
        while(true)
        {
            string command = Console.ReadLine();
            if(command =="Print")
            {
                for(int i=0;i<names.Length; i++)
                {
                    if (!filter[i])
                    {
                        Console.Write(names[i]+" ");
                    }             
                }
                break;
            }
            string[] split = command.Split(";").ToArray();
            if (split[0]=="Add filter")
            {
                if (split[1]=="Starts with")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].StartsWith(split[2]))
                            filter[i] = true;
                    }
                }
                else if (split[1]=="Ends with")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].EndsWith(split[2]))
                            filter[i] = true;
                    }
                }
                else if (split[1]=="Length")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].Length==int.Parse(split[2]))
                            filter[i] = true;
                    }
                }
                else if (split[1]=="Contains")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].Contains(split[2]))
                            filter[i] = true;
                    }
                }
            }
            else
            {
                if (split[1] == "Starts with")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].StartsWith(split[2]))
                            filter[i] = false;
                    }
                }
                else if (split[1] == "Ends with")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].EndsWith(split[2]))
                            filter[i] = false;
                    }
                }
                else if (split[1] == "Length")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].Length == int.Parse(split[2]))
                            filter[i] = false;
                    }
                }
                else if (split[1] == "Contains")
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (names[i].Contains(split[2]))
                            filter[i] = false;
                    }
                }
            }

        }
    }
}