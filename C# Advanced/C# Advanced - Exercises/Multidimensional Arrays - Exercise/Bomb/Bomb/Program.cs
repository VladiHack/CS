public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        for(int i=0;i<n;i++)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for(int s=0;s<arr.Length;s++)
            {
                matrix[i, s] = arr[s];
            }
        }
        string[] bombs = Console.ReadLine().Split().ToArray();
        for(int i=0;i<bombs.Length;i++)
        {
            int[] split = bombs[i].Split(",").Select(int.Parse).ToArray();
            int x = split[0];int y = split[1];
            if (matrix[x,y]>0)
            {
                if(x>0&&y>0)
                {
                    if (matrix[x-1,y-1]>0)
                    {
                        matrix[x - 1, y - 1] -= matrix[x, y];
                    }
                }
                if(x>0)
                {
                    if (matrix[x-1,y]>0)
                    {
                        matrix[x - 1, y] -= matrix[x, y];
                    }
                }
                if (y > 0)
                {
                    if (matrix[x,y-1]>0)
                    {
                        matrix[x, y - 1] -= matrix[x, y];
                    }
                }
                if(x+1<n)
                {
                    if (matrix[x+1,y]>0)
                    {
                        matrix[x+1,y]-= matrix[x, y];
                    }
                }
                if(y+1<n)
                {
                    if (matrix[x,y+1]>0)
                    {
                        matrix[x, y + 1] -= matrix[x, y ];
                    }
                }
                if(x+1<n&&y+1<n)
                {
                    if (matrix[x+1,y+1]>0)
                    {
                        matrix[x + 1, y + 1] -= matrix[x , y ];
                    }
                }
                if(x>0&&y+1<n)
                {
                    if (matrix[x-1,y+1]>0)
                    {
                        matrix[x - 1, y + 1] -= matrix[x, y];
                    }
                }
                if(y>0&&x+1<n)
                {
                    if (matrix[x+1,y-1]>0)
                    {
                        matrix[x + 1, y - 1] -= matrix[x, y];
                    }
                }
            }
            matrix[x, y] = 0;

        }
        string output = "";int activeCells = 0;int sum = 0;
        for(int i=0;i<n;i++)
        {
            for(int s=0;s<n;s++)
            {
                output += matrix[i, s] + " ";
                if (matrix[i, s] > 0)
                {
                    activeCells++;
                    sum += matrix[i, s];
                }
            }
            output += "\n";
        }
        Console.WriteLine("Alive cells: "+activeCells);
        Console.WriteLine("Sum: "+sum);
        Console.WriteLine(output);
    }
}