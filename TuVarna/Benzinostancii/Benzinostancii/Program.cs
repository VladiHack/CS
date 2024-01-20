using System.Text;

public class Program
{
    static int rows;
    static long lowestSum=long.MaxValue;

    static void Recursion(int[,] arr,string used,int collected,long sum,int indexFrom)
    {
        if (collected == rows + 1||sum>=lowestSum)
        {
            lowestSum = Math.Min(lowestSum, sum);
            return;
        }
        if(collected==rows)
        {
            Recursion(arr, used, collected + 1, sum + arr[indexFrom,0],indexFrom);
        }
        for(int i=1;i<=rows;i++)
        { 
            string convert =" "+i.ToString()+" ";
            if (!used.Contains(convert))
            {
                Recursion(arr, used +i+ " ", collected + 1, sum + arr[indexFrom, i], i);
            }
        }
    }
    public static void Main(string[] args)
    {
        int tests = int.Parse(Console.ReadLine());
        for(int t=0;t<tests;t++)
        {
            rows = int.Parse(Console.ReadLine());
            lowestSum = long.MaxValue;
            int[,] arr = new int[rows + 1, rows + 1];
            for (int i = 0; i < rows; i++)
            {
                int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int s = 0; s < parameters.Length; s++)
                {
                    arr[i, s + i + 1] = parameters[s];
                    arr[s + i + 1, i] = parameters[s];
                }
            }
        }
      
    }
}