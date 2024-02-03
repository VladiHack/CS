public class Program
{
    public static void Main(string[] args)
    {
        List<string> regular=new List<string>();
        List<string> vip=new List<string>();
        bool partyStarted = false;
        while(true)
        {
            string read = Console.ReadLine();
            if(read=="END")
            {
                Console.WriteLine(vip.Count+regular.Count);
                if (vip.Count>0)
                {
                    for(int i=0;i<vip.Count; i++)
                    {
                        Console.WriteLine(vip[i]);
                    }
                }
                if(regular.Count>0)
                {
                    for(int i=0;i<regular.Count; i++)
                        Console.WriteLine(regular[i]);
                }
                break;
            }
            else if(read=="PARTY")
            {
                partyStarted = true;
            }
            else
            {
                if (read[0] >= '0' && read[0]<='9')
                {
                    if(vip.Contains(read)==false && partyStarted==false)
                    {
                        vip.Add(read);
                    }
                    else if(vip.Contains(read)&&partyStarted)
                    {
                        vip.Remove(read);
                    }
                }
                else 
                {
                    if (regular.Contains(read) == false && partyStarted == false)
                        regular.Add(read);
                    else if (regular.Contains(read) && partyStarted)
                        regular.Remove(read);
                }
            }
        }
    }
}