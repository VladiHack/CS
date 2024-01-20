public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t; i++)
        {
            int[] pars = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = pars[0];int m = pars[1];
            List<int> parameters = Console.ReadLine().Split().Select(int.Parse).ToList();
            parameters.Sort();
            int maxRobots = 0;
            int indexOfLastNum = 1;
           for(int s=0;s<parameters.Count;s++)
            {
                if(parameters.Count -s<=maxRobots)
                {
                    break;
                }
                for(int k=indexOfLastNum+1;k<parameters.Count;k++)
                {
                    if (parameters[k]-parameters[s]<=m)
                    {
                        maxRobots=Math.Max(k-s+1,maxRobots);
                    }
                    else
                    {
                        indexOfLastNum = k - 1;
                        break;
                    }
                }
            }
            Console.WriteLine(maxRobots);
        }
    }
}