public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string,string> people=new Dictionary<string,string>();
        Dictionary<string,List<string>> sidesMembers = new Dictionary<string, List<string>>();
        while(true)
        {
            string read = Console.ReadLine();
            if(read== "Lumpawaroo")
            {
                foreach(var jedi in  people)
                {
                    if(!sidesMembers.ContainsKey(jedi.Value))
                    {
                        List<string> jediList=new List<string>();
                        sidesMembers.Add(jedi.Value, jediList);
                    }
                    sidesMembers[jedi.Value].Add(jedi.Key);
                }
                var newOrder=sidesMembers.OrderByDescending(x => x.Value.Count).ThenBy(p=>p.Key).ToList();
                foreach(var side in newOrder)
                {
                    if (side.Value.Count != 0)
                    {
                        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                        List<string> currentSide = side.Value;
                        currentSide.Sort();
                        for(int i=0;i<currentSide.Count;i++)
                        {
                            Console.WriteLine("! " + currentSide[i]);
                        }
                    }

                }
                break;
            }
            string name = "";string force = "";
            read = read.Trim();
            if (read.Contains("|"))
            {
                string[] split = read.Split("|").ToArray();
                name = split[1].Trim(); force = split[0].Trim(); 
            }
            else
            {
                string[] split = read.Split("->").ToArray();
                 name = split[0].Trim();  force= split[1].Trim();
                Console.WriteLine($"{name} joins the {force} side!");

            }
            if (!people.ContainsKey(name))
            {
                people.Add(name, force);
           
            }
            else
            {
                people[name] = force;
            }
        }
    }
}