using System.ComponentModel;

public class Program
{
    static int coalRemaining = 0;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string[] commands = Console.ReadLine().Split().ToArray();
        char[,] matrix = new char[n, n];
        int x=0;int y=0;
        for(int i=0;i<n; i++)
        {
            char[] arr = Console.ReadLine().Split().Select(char.Parse).ToArray();
            for(int s=0;s<n;s++)
            {
                matrix[i, s] = arr[s];
                if (matrix[i,s]=='s')
                {
                    x= i;
                    y= s;
                }
                else if (matrix[i,s]=='c')
                {
                    coalRemaining++;
                }
            }
        }
        for(int i=0;i<commands.Length;i++)
        {
            if (commands[i]=="up")
            {
                if(x==0)
                {
                    continue;
                }
                x--;
               if(CheckProgramEnds(matrix,x,y))
                {
                    return;
                }
            }
            else if (commands[i]=="right")
            {
                if(y+1==n)
                {
                    continue;
                }
                y++;
                if(CheckProgramEnds(matrix,x,y))
                {
                    return;
                }
            }
            else if (commands[i]=="left")
            {
                if(y-1==-1)
                {
                    continue;
                }
                y--;
                if(CheckProgramEnds(matrix,x,y))
                {
                    return;
                }
            }
            else if (commands[i]=="down")
            {
                if(x+1==n)
                {
                    continue;
                }
                x++;
                if(CheckProgramEnds(matrix,x,y))
                {
                    return;
                }
            }
        }
        Console.WriteLine($"{coalRemaining} coals left. ({x}, {y})");

    }
    public static bool CheckProgramEnds(char[,] matrix,int x,int y)
    {
        if (matrix[x, y] == 'e')
        {
            Console.WriteLine($"Game over! ({x}, {y})");
            return true;
        }
        else if (matrix[x, y] == 'c')
        {
            matrix[x, y] = '*';
            coalRemaining--;
            if (coalRemaining == 0)
            {
                Console.WriteLine($"You collected all coals! ({x}, {y})");
                return true;
            }
        }
        return false;
    }
}