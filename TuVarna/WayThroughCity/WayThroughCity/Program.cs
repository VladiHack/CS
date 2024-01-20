public class Program
{
    static int n; static int m;
    static long[,] dp = new long[21, 21];
    static long minSteps = 0;
    static void Recursion(int x, int y, long steps, long[,] arr,char direction)
    {
        if (x == n||y==m||x<0||y<0)
        {
            return;
        }
        if (x == n - 1)
        {
            if (arr[x, y] == 0 || arr[x, y] == 2)
            {
                if (dp[x, y] == 0 || dp[x, y] >= steps)
                {
                    dp[x, y] = steps;
                }
            }
            else if (arr[x, y] == 1)
            {
                if (direction == 'd'||direction=='u')
                {
                    if (y - 1 != 0)
                    {
                        Recursion(x, y - 1, steps + 1, arr,'l');
                    }
                    if (y + 1 < m)
                    {
                        Recursion(x, y + 1, steps + 1, arr,'r');
                    }
                }
                else if(direction=='l'||direction=='r')
                {
                    if (dp[x, y] == 0 || dp[x, y] >= steps)
                    {
                        dp[x, y] = steps;
                    }
                }
               
            }
            return;
        }
        if (arr[x, y] == 3)
        {
            return;
        }
        if (steps < dp[x, y] || dp[x, y] == 0)
        {
            dp[x, y] = steps;
        }
        else
        {
            return;
        }
        if (arr[x, y] == 0)
        {
            if(direction=='d')
            {
                Recursion(x + 1, y, steps + 1, arr,'d');
            }
            else if(direction=='u')
            {
                Recursion(x - 1, y, steps + 1, arr, 'u');
            }
            else if(direction=='l')
            {
                Recursion(x,y-1, steps + 1, arr,'l');
            }
            else if(direction=='r')
            {
                Recursion(x,y+1,steps+1, arr,'r');
            }
        }
        else if (arr[x, y] == 1)
        {
            if(direction=='d'||direction=='u')
            {
                Recursion(x, y - 1, steps + 1, arr, 'l');
                Recursion(x,y+1,steps+1,arr,'r');
            }
            else
            {
                Recursion(x-1,y,steps+1, arr, 'u');
                Recursion(x + 1, y, steps + 1, arr, 'd');
            }
        }
        else if (arr[x, y] == 2)
        {
           if(direction=='l')
            {
                Recursion(x+1,y, steps+1, arr, 'd');
                Recursion(x - 1, y, steps + 1, arr, 'u');
                Recursion(x, y - 1, steps + 1, arr, 'l');
            }
           if(direction=='r')
            {
                Recursion(x + 1, y, steps + 1, arr, 'd');
                Recursion(x - 1, y, steps + 1, arr, 'u');
                Recursion(x, y + 1, steps + 1, arr, 'r');
            }
           if(direction=='d')
            {
                Recursion(x + 1, y, steps + 1, arr, 'd');
                Recursion(x, y - 1, steps + 1, arr, 'l');
                Recursion(x, y + 1, steps + 1, arr, 'r');
            }
           if(direction=='u')
            {
                Recursion(x - 1, y, steps + 1, arr, 'u');
                Recursion(x, y - 1, steps + 1, arr, 'l');
                Recursion(x, y + 1, steps + 1, arr, 'r');
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
            Recursion(0, i, 1, arr,'d');
        }
        long minSteps = 0;
        for (int i = 0; i < m; i++)
        {
            if (dp[n - 1, i] != 0)
            {
                if (minSteps == 0 || minSteps > dp[n - 1, i])
                {
                    minSteps = dp[n - 1, i];
                }
            }
        }
        Console.WriteLine(minSteps);
    }

}