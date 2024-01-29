public class Program
{
    public static void Main(string[] args)
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = parameters[0];int cols= parameters[1];
        string snakeSize = Console.ReadLine();
        int counter = -1;
        for(int i=0;i<rows; i++)
        {
            if(i%2==0)
            {
                for(int k=0;k<cols;k++)
                {
                    counter++;
                    if(counter==snakeSize.Length)
                    {
                        counter = 0;
                    }
                    Console.Write(snakeSize[counter]);
                }
            }
            else
            {
                string line = "";
                for (int k=cols-1;k>=0;k--)
                {
                    counter++;
                    if(counter==snakeSize.Length)
                    {
                        counter = 0;
                    }
                    line += snakeSize[counter];
                }
                for(int  j=line.Length-1;j>=0;j--)
                Console.Write(line[j]);
            }
            Console.WriteLine();
        }
    }
}