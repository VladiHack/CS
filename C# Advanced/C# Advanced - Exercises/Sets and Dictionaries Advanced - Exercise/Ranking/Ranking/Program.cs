public class Program
{
    public static void Main(string[] args)
    {
        List<string> contests=new List<string>();
        Dictionary<string,string> contestsPass=new Dictionary<string,string>();
        SortedDictionary<string, Dictionary<string, int>> contestants = new SortedDictionary<string, Dictionary<string, int>>();
        Dictionary<string, int> pointsTotal = new Dictionary<string, int>();

        bool readingContests = true;
        while(true)
        {
            string read = Console.ReadLine();
            string ranking = "";
            if(read=="end of submissions")
            {
                foreach(var contestant in contestants)
                {
                    ranking += contestant.Key + "\n";
                    Dictionary<string, int> order = contestant.Value;
                    order = order.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var contest in order)
                    {
                        ranking += $"#  {contest.Key} -> {contest.Value}\n";
                        pointsTotal[contestant.Key] += contest.Value;
                    }
                }
                string bestContestant = "";int mostPoints = 0;
                foreach (var contestant in pointsTotal)
                {
                    if(contestant.Value>mostPoints)
                    {
                        mostPoints=contestant.Value;
                        bestContestant=contestant.Key;
                    }
                }
                Console.WriteLine($"Best candidate is {bestContestant} with total {mostPoints} points.");
                Console.WriteLine("Ranking:");
                Console.WriteLine(ranking);
                break;
            }
            else if(read=="end of contests")
            {
                readingContests = false;
                continue;
            }
            if(readingContests)
            {
                string[] split = read.Split(":").ToArray();
                if (!contestsPass.ContainsKey(split[0]) )
                {
                    contestsPass.Add(split[0], split[1]);   
                }
            }
            else
            {
                string[] split = read.Split("=>").ToArray();
                string contestName = split[0];string password = split[1];string contestantName = split[2];
                int points = int.Parse(split[3]);
                if (contestsPass.ContainsKey(contestName))
                {
                    if (contestsPass[contestName] == password)
                    {
                        if (!contestants.ContainsKey(contestantName))
                        {
                            Dictionary<string, int> newDict = new Dictionary<string, int>();
                            contestants.Add(contestantName, newDict);
                            pointsTotal.Add(contestantName, 0);
                        }
                        
                            Dictionary<string, int> currentContestant = contestants[split[2]];
                            if (currentContestant.ContainsKey(contestName))
                            {
                                if (currentContestant[contestName] < points)
                                {
                                    currentContestant[contestName] = points;
                                }
                            }
                            else
                            {
                                currentContestant.Add(contestName,points);
                            }
                            contestants[contestantName] = currentContestant;
                        
                       
                    }
                  
                }
            }

        }
    }
}