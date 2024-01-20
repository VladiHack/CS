public class Program
{
    static List<List<int>> pairs=new List<List<int>>();
    static bool found = false;
    static int n;static int m;
    static void Recursion(int index,int end,int startedIndex,string res)
    {
        if (found) return;
        if (index == end)
        {
            found = true;
            return;
        }
        for(int i=0; i <m; i++)
        {
            if (pairs[i][0]==index)
            {
                if (pairs[i][1]==end&&index==startedIndex)
                {
                    continue;
                }
                if(!res.Contains($" {pairs[i][1]} "))
                {
                    Recursion(pairs[i][1],end,startedIndex,res+$" {pairs[i][1]} ");
                }
            }
            else if (pairs[i][1]==index)
            {
                if (pairs[i][0] == end && index == startedIndex)
                {
                    continue;
                }
                if (!res.Contains($" {pairs[i][0]} "))
                {
                    Recursion(pairs[i][0], end, startedIndex, res + $" {pairs[i][0]} ");
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t; i++)
        {
            pairs.Clear();
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
             n = parameters[0]; m = parameters[1];
            for(int s=0;s<m;s++)
            {
                List<int> read = Console.ReadLine().Split().Select(int.Parse).ToList();
                read.Sort();
                pairs.Add(read);
            }
            for(int s=0;s<m;s++)
            {
                found = false;
                int start = pairs[s][0];
                int end= pairs[s][1];
                Recursion(start,end,start,$" {pairs[s][0]} ");
                if (!found)
                {
                    Console.WriteLine(pairs[s][0]+" " + pairs[s][1]);
                }
            }
        }
    }
}