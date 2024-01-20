using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        while(true)
        {
            string read =Console.ReadLine();
            if(string.IsNullOrEmpty(read))
            {
                break;
            }
            StringBuilder current =new StringBuilder();
            current.Append("MI");
            for(int i=0;i<read.Length; i++)
            {
                if (read[i]=='A')
                {
                    if (current[current.Length-1]=='I')
                    {
                        current.Append("U");
                    }
                }
                else if (read[i]=='B')
                {
                    current.Append(current[current.Length-1]);
                }
                else if (read[i]=='C')
                {
                    StringBuilder copy = new StringBuilder();
                    copy.Append(current.ToString());
                    while(true)
                    {
                        int index = copy.ToString().IndexOf("III");
                        if(index==-1)
                        {
                            break;
                        }
                        current.Clear();
                        current.Append(copy.ToString());
                        copy.Remove(index, 3);
                        copy.Insert(index, "U");
                    }
                    current = copy;
                }
                else
                {
                    StringBuilder copy = new StringBuilder();
                    copy.Append(current.ToString());
                    while (true)
                    {
                        int index = copy.ToString().IndexOf("UU");
                        if (index == -1)
                        {
                            break;
                        }
                        current.Clear();
                        current.Append(copy.ToString());
                        copy.Remove(index, 2);
                    }
                    current = copy;
                }
            }
            Console.WriteLine(current);
        }
    }
}