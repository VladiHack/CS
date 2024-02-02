public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = parameters[0];int cols= parameters[1];
        char[,] matrix = new char[rows, cols];
        List<List<int>> list= new List<List<int>>();
        int x=0;int y=0;
        for(int i=0; i < rows;i++)
        {
            string line=Console.ReadLine();
            for(int s=0;s < cols;s++)
            {
                matrix[i, s] = line[s];
                if (line[s]=='B')
                {
                    List<int> coordinates= new List<int>();
                    coordinates.Add(i);
                    coordinates.Add(s);
                    list.Add(coordinates);
                }
                else if (line[s]=='P')
                {
                    x = i;y = s;
                }
            }
        }
        string commands = Console.ReadLine();
        for(int i=0;i<commands.Length;i++)
        {
            List<List<int>> newBunnies= new List<List<int>>();
            foreach(List<int> coordinates in list)
            {
                int rabbitX = coordinates[0];int rabbitY = coordinates[1];
                if(rabbitX>0)
                {
                    if (matrix[rabbitX-1,rabbitY]!='B')
                    {
                        matrix[rabbitX - 1, rabbitY] = 'B';
                        newBunnies.Add(new List<int> { rabbitX - 1, rabbitY });
                    }

                }
                if(rabbitY>0)
                {
                    if (matrix[rabbitX, rabbitY-1] != 'B')
                    {
                        matrix[rabbitX, rabbitY-1] = 'B';
                        newBunnies.Add(new List<int> { rabbitX, rabbitY-1 });
                    }
                }

                if(rabbitX+1<rows)
                {
                    if (matrix[rabbitX + 1, rabbitY] != 'B')
                    {
                        matrix[rabbitX + 1, rabbitY] = 'B';
                        newBunnies.Add(new List<int> { rabbitX + 1, rabbitY });
                    }
                }

                if(rabbitY+1<cols)
                {
                    if (matrix[rabbitX, rabbitY + 1] != 'B')
                    {
                        matrix[rabbitX, rabbitY + 1] = 'B';
                        newBunnies.Add(new List<int> { rabbitX, rabbitY + 1 });
                    }
                }
               
            }
            list = newBunnies;
            if (commands[i]=='U')
            {
                if(x==0)
                {
                    PrintMatrix(rows,cols,matrix);
                    Console.WriteLine($"won: {x} {y}");
                    return;
                }
                if (matrix[x,y]=='P')
                matrix[x, y] = '.';
                x--;
                if (matrix[x,y]=='B')
                {
                    PrintMatrix(rows,cols,matrix );
                    Console.WriteLine($"dead: {x} {y}");
                    return;
                }
            }
            else if (commands[i]=='D')
            {
                if (x == rows - 1)
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"won: {x} {y}");
                    return;
                }
                if (matrix[x,y]=='P')
                matrix[x, y] = '.';
                x++;
                if (matrix[x, y] == 'B')
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"dead: {x} {y}");
                    return;
                }
            }
            else if (commands[i]=='L')
            {
                if(y==0)
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"won: {x} {y}");
                    return;
                }
                if (matrix[x,y]=='P')
                matrix[x, y] = '.';
                y--;
                if (matrix[x, y] == 'B')
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"dead: {x} {y}");
                    return;
                }
            }
            else
            {
                if(y==cols-1)
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"won: {x} {y}");
                    return;
                }
                if (matrix[x,y]=='P')
                matrix[x, y] = '.';
                y++;
                if (matrix[x,y]=='B')
                {
                    PrintMatrix(rows, cols, matrix);
                    Console.WriteLine($"dead: {x} {y}");
                    return;
                }
            }
        }
        
    }
    public static void PrintMatrix(int  rows, int cols, char[,] matrix)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int s = 0; s < cols; s++)
            {
                Console.Write(matrix[i, s]);
            }
            Console.WriteLine();
        }
    }
}