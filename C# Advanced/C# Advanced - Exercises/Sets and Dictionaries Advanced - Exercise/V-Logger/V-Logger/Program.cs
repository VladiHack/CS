using System.Collections.Immutable;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> V_Loggers=new List<string>();
        Dictionary<string,SortedSet<string>> followers=new Dictionary<string, SortedSet<string>>();
        Dictionary<string, SortedSet<string>> following=new Dictionary<string, SortedSet<string>>();
        Dictionary<string, long> specialArrengement = new Dictionary<string, long>();

        while (true)
        {
            string[] line = Console.ReadLine().Split().ToArray();
            if (line[0] =="Statistics")
            {
                
                int counter = 1;
                Console.WriteLine($"The V-Logger has a total of {V_Loggers.Count} vloggers in its logs.");
                foreach(var vlogger in followers)
                {
                    string vloggerName=vlogger.Key;
                    specialArrengement[vloggerName] = followers[vloggerName].Count * 10000 - following[vloggerName].Count;
                }
                specialArrengement=specialArrengement.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
                 
                foreach (var vlogger in specialArrengement)
                {
                    string vloggerName = vlogger.Key;
                    Console.WriteLine($"{counter}. {vloggerName} : {followers[vloggerName].Count} followers, {following[vloggerName].Count} following");
                    if (counter == 1)
                    {
                        foreach(var follower in followers[vloggerName])
                        {
                            Console.WriteLine("*  "+follower);
                        }
                    }

                    counter++;
                }
                break;
            }
            if (line[1] == "joined" && line[2]=="The" && line[3]=="V-Logger")
            {
                if (!V_Loggers.Contains(line[0]))                              
                {
                    SortedSet<string> newHas=new SortedSet<string>();
                    SortedSet<string> otherHash=new SortedSet<string>();
                    V_Loggers.Add(line[0]);
                    followers.Add(line[0], newHas);
                    following.Add(line[0], otherHash);
                    specialArrengement.Add(line[0], 0);
                }
            }
            else if (line[1]=="followed")
            {
                if (V_Loggers.Contains(line[0]) && V_Loggers.Contains(line[2]) && line[0] != line[2])
                {
                    followers[line[2]].Add(line[0]);
                    following[line[0]].Add(line[2]);
                }
            }
        }

    }
}