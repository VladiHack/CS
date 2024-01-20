public class Program
{
    static int n;static int m;
    static long[,] dp = new long[21, 21];
    static long minSteps = 0;
    static void Recursion(int x,int y,long steps, long[,] arr)
    {
         if(x==n-1)
        {
            if (arr[x, y] == 0 || arr[x, y] == 2)
            {
                if (dp[x, y] == 0 || dp[x,y]>=steps)
                {
                    dp[x, y] = steps;
                }
            }
            else if (arr[x,y]==1)
            {
                if(y-1!=0)
                {
                    Recursion(x,y-1,steps+1,arr);
                }
                if(y+1<m)
                {
                    Recursion(x, y + 1, steps + 1, arr);
                }
            }
            return;
        }
        if (arr[x,y]==3)
        {
            return;
        }
        if (steps < dp[x, y] || dp[x,y]==0)
        {
            dp[x, y] = steps;
        }
        else
        {
            return;
        }
        if (arr[x,y]==0)
        {
            Recursion(x + 1, y, steps + 1, arr);
        }
        else if (arr[x,y]==1)
        {
            if(y>0)
            {
                Recursion(x,y-1, steps+1, arr);
            }
            if(y+1<m)
            {
                Recursion(x,y+1, steps+1, arr);
            }
        }
        else if (arr[x,y]==2)
        {
            Recursion(x + 1, y, steps + 1, arr);
            if (y > 0)
            {
                Recursion(x, y - 1, steps + 1, arr);
            }
            if (y + 1 < m)
            {
                Recursion(x, y + 1, steps + 1, arr);
            }
        }
    }
    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());
        long[,] arr = new long[n, m];
        for (int i = 0; i < n; i++)
        {
            int[] parameters = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            for (int s = 0; s < m; s++)
            {
                arr[i, s] = parameters[s];
            }
        }
        for (int i = 0; i < m; i++)
        {
            Recursion(0, i, 1, arr);
        }
        long minSteps = 0;
        for(int i=0;i<m;i++)
        {
            if (dp[n-1,i]!=0)
            {
                if (minSteps == 0 || minSteps > dp[n-1,i])
                {
                    minSteps = dp[n-1, i];
                }
            }
        }
        Console.WriteLine(minSteps);
    }

}