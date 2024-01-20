public class Program
{
    static long smallestSteps = 0;
    static int rows;static int cols;static int houses;
    static void Recursion(char[,] arr,int x,int y,long steps,string housesVisited)
    {
        if (steps >= smallestSteps || arr[x, y] == 'X')
        {
            return;
        }
        if (arr[x,y]=='T'&&housesVisited.Length==houses)
        {
           smallestSteps=Math.Min(steps, smallestSteps);
            return;
        }

        if (arr[x, y] != '*' && arr[x, y] != 'P' && arr[x,y]!='T')
        {
            if (!housesVisited.Contains(arr[x,y]))
            {
                housesVisited += arr[x, y];
            }
        }
        if(x>0)
        {
            Recursion(arr,x-1,y,steps+1,housesVisited);
        }
        if (y > 0)
        {
            Recursion(arr,x,y-1,steps+1,housesVisited);
        }
        if(y <cols-1)
        {
            Recursion(arr,x,y+1,steps+1,housesVisited);
        }
        if(x<rows-1)
        {
            Recursion(arr,x+1,y,steps+1,housesVisited);
        }
    }
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
         rows = parameters[1]; cols = parameters[0]; houses = parameters[2];
        char[,] arr= new char[rows, cols];
        smallestSteps = 30;
        int startX = 0;int startY = 0;
        for(int i=0;i<rows;i++)
        {
            string read= Console.ReadLine();
            for(int s=0;s<cols;s++)
            {
                arr[i, s] = read[s];
                if (read[s]=='P')
                {
                    startX = i; startY=s;
                }
            }
        }
        bool[,] met=new bool[rows, cols];
        Recursion(arr, startX, startY, 0, "");
        Console.WriteLine(smallestSteps*10);
    }
}