using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        int[] param = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = param[0];int cols= param[1];
        string[,] matrix = new string[rows, cols];
        for (int i=0;i<rows;i++)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            for (int s = 0; s < cols; s++)
            {
                matrix[i, s] = arr[s];
            }
        }
        while(true)
        {
            string line= Console.ReadLine();
            if (line=="END")
            {
                break;
            }
            string[] split = line.Split().ToArray();
            if (split[0]=="swap"&&split.Length==5)
            {
                int x1 = int.Parse(split[1]);
                int y1= int.Parse(split[2]);
                int x2= int.Parse(split[3]);
                int y2= int.Parse(split[4]);
                if ((x1>=0&&x1<rows)&&(x2>=0&&x2<rows)&&(y1>=0&&y1<cols)&&(y2>=0&&y2<cols))
                {
                   string temp = matrix[x1, y1];
                   string temp2 = matrix[x2, y2];
                    matrix[x1, y1] = temp2;
                    matrix[x2, y2] = temp;
                    for(int i=0;i<rows;i++)
                    {
                        for(int k=0;k<cols;k++)
                        {
                            Console.Write(matrix[i, k] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}