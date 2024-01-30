public class Program
{
    public static void Main(string[] args)
    {
        int rows=int.Parse(Console.ReadLine());
        List<List<int>> list= new List<List<int>>();
        for(int i=0;i<rows; i++)
        {
            List<int> currentRow = Console.ReadLine().Split().Select(int.Parse).ToList();
            list.Add(currentRow);
        }
        for(int i=0;i<rows-1;i++)
        {
            if (list[i].Count == list[i+1].Count)
            {
                for(int s = 0; s < list[i].Count;s++)
                {
                    list[i][s] *= 2;
                    list[i + 1][s] *= 2;
                }
            }
            else
            {
                for(int s=0;s< list[i].Count; s++)
                {
                    list[i][s] /= 2;
                }
                for(int k = 0; k < list[i+1].Count;k++)
                {
                    list[i+1][k] /= 2;
                }
            }
        }
        while(true)
        {
            string line = Console.ReadLine();
            if(line=="End")
            {
                foreach (List<int> item in list)
                {
                    Console.WriteLine(String.Join(" ",item));
                }
                break;
            }
            string[] split = line.Split().ToArray();
            int x = int.Parse(split[1]);
            int y= int.Parse(split[2]);
            int val= int.Parse(split[3]);
            if (split[0] == "Add")
            {
                if (x >= 0 && x < rows && y<list[x].Count&& y>=0)
                {
                    list[x][y] += val;
                }
            }
            else if (split[0]=="Subtract")
            {
                if (x >= 0 && x < rows && y < list[x].Count && y >= 0)
                {
                    list[x][y] -= val;
                }
            }
        }

    }
}