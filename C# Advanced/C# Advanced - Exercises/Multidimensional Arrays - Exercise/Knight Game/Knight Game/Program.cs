public class Program
{
    static char[,] matrix = new char[200, 200];
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string read = Console.ReadLine();
            for (int s = 0; s < read.Length; s++)
            {
                matrix[i, s] = read[s];
            }
        }
        int counter = 0;
        while (true)
        {
            if (FindNeighbours(n) == 0)
            {
                Console.WriteLine(counter);
                break;
            }
            counter++;
        }


    }
    public static int FindNeighbours(int n)
    {
        int mostNeighbours = 0;
        int keepX = 0, keepY = 0;
        for (int i = 0; i < n; i++)
        {
            for (int s = 0; s < n; s++)
            {
                if (matrix[i, s] == 'K')
                {
                    int currentNeighbours = 0;
                    if (i > 0 && s > 2)
                    {
                        if (matrix[i - 1, s - 2] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }
                    if (i > 0)
                    {
                        if (matrix[i - 1, s + 2] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }
                    if (i > 1 && s > 0)
                    {
                        if (matrix[i - 2, s - 1] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }
                    if (i > 1)
                    {
                        if (matrix[i - 2, s + 1] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }
                    if (s > 1)
                    {
                        if (matrix[i + 1, s - 2] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }

                    if (matrix[i + 1, s + 2] == 'K')
                    {
                        currentNeighbours++;
                    }
                    if (s > 0)
                    {
                        if (matrix[i + 2, s - 1] == 'K')
                        {
                            currentNeighbours++;
                        }
                    }

                    if (matrix[i + 2, s + 1] == 'K')
                    {
                        currentNeighbours++;
                    }
                    if (currentNeighbours > mostNeighbours)
                    {
                        mostNeighbours = currentNeighbours;
                        keepX = i;
                        keepY = s;
                    }
                }
            }
        }
        if (mostNeighbours != 0)
        {
            matrix[keepX, keepY] = '0';
        }
        return mostNeighbours;
    }
}