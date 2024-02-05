public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> participants = new Dictionary<string, Dictionary<string, int>>();
        Dictionary<string,int> languages= new Dictionary<string,int>();
        Dictionary<string,int> orderedParticipants= new Dictionary<string,int>();
        List<string> banned= new List<string>();
        while(true)
        {
            string read = Console.ReadLine();
            if(read=="exam finished")
            {
                foreach(var participant in participants)
                {
                    if(!banned.Contains(participant.Key))
                    {
                        orderedParticipants.Add(participant.Key, 0);
                        foreach(var contest in participant.Value)
                        {
                            orderedParticipants[participant.Key] += contest.Value;
                        }
                    }
                }
                 orderedParticipants = orderedParticipants.OrderByDescending(x => x.Value).ThenBy(x=>x.Key).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("Results:");
                foreach (var participant in orderedParticipants)
                {
                    Console.WriteLine(participant.Key+" | "+participant.Value);
                }
                Console.WriteLine("Submissions:");
                languages=languages.OrderByDescending(x=>x.Value).ThenBy(x => x.Key).ToDictionary(x=>x.Key,x=>x.Value);
                foreach(var language in languages)
                {
                    Console.WriteLine(language.Key+" - "+language.Value);
                }


                break;
            }
            string[] split = read.Split('-').ToArray();
            if (split[1]=="banned")
            {
                banned.Add(split[0]);
            }
            else
            {
                string name = split[0]; string language= split[1]; int points = int.Parse(split[2]);
                if(!banned.Contains(name))
                {
                    if (!participants.ContainsKey(name))
                    {

                        Dictionary<string, int> newParticipant = new Dictionary<string, int>();
                        participants.Add(name, newParticipant);

                    }
                    Dictionary<string, int> currentParticipant = participants[name];
                    if(!currentParticipant.ContainsKey(language))
                    {
                        currentParticipant.Add(language, points);
                    }
                    else if (currentParticipant[language]<points)
                    {
                        currentParticipant[language] = points;
                    }
                    participants[name]= currentParticipant;
                }
                if(languages.ContainsKey(language))
                {
                    languages[language]++;
                }
                else
                {
                    languages.Add(language, 1);
                }
                
                
            }

        }
    }
}
