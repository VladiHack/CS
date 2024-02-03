using System.ComponentModel;

public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = parameters[0];int m = parameters[1];
        Dictionary<int, int> timesMetFirst=new Dictionary<int, int>();
        Dictionary<int, int> timesMetSecond= new Dictionary<int, int>();

        for (int i=0;i<n;i++)
        {
            int num = int.Parse(Console.ReadLine());
            if(timesMetFirst.ContainsKey(num))
            {
                timesMetFirst[num]++;
            }
            else
            {
                timesMetFirst.Add(num, 1);
            }

        }
        for (int i = 0; i < m; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (timesMetSecond.ContainsKey(num))
            {
                timesMetSecond[num]++;
            }
            else
            {
                timesMetSecond.Add(num, 1);
            }

        }
        foreach(var item in timesMetFirst)
        {
            if(timesMetSecond.ContainsKey(item.Key))
            {
                
                    Console.Write(item.Key+" ");
                
            }    
        }
    }
}