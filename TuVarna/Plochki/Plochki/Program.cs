    public class Program
    {
        static int DesiredX = 0;static int DesiredY = 0;
        static int n;static int m;
        static string res = "NO";
        static void Recursion(int x,int y,char[,] arr, bool[,] metEver)
        {
            if (res == "YES"  || metEver[x,y])
            {
               return;
            }
            metEver[x, y] = true;

        if (x == DesiredX && y == DesiredY)
            {
                res = "YES";
                return;
            }
            if (x > 0)
            {
                if (arr[x - 1, y] != '*')
                Recursion(x - 1, y,arr,metEver);
            }
            if (y > 0)
            {
                if (arr[x,y-1]!='*')
                Recursion(x, y - 1, arr, metEver);
            }
            if (x < n - 1)
            {
                if (arr[x+1,y]!='*')
                Recursion(x + 1, y, arr, metEver);
            }
            if (y < m - 1)
            {
                if (arr[x,y+1]!='*')
                Recursion(x, y + 1, arr, metEver);
            }
        }
        public static void Main(string[] args)
        {
            int tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                 n = parameters[0];
                 m = parameters[1];
                res = "NO";
                char[,] array = new char[n+2, m+2];
                for(int j = 0; j < n; j++)
                {
                    string read = Console.ReadLine();
                    for(int k = 0; k < m; k++)
                    {
                        array[j,k]=read[k];
                    }
                }
                int[] coordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                bool[,] met = new bool[n+2, m+2 ];
                bool[,] metEver = new bool[n + 2, m + 2];
                DesiredX = coordinates[2]-1;
                DesiredY = coordinates[3]-1;
                Recursion(coordinates[0]-1, coordinates[1]-1, array,metEver);
                Console.WriteLine(res);

            }
        }
    }
