public class Program
{
    public static void Main(string[] args)
    {
        int rows = int.Parse(Console.ReadLine());
        List<List<int>> list= new List<List<int>>();
        for(int i=0; i<rows; i++)
        {
            List<int> ints=Console.ReadLine().Split().Select(int.Parse).ToList();
            list.Add(ints);
        }
        while (true)
        {
            string line=Console.ReadLine();
            if (line == "END")
            {
                foreach (var item in list)
                {
                    Console.WriteLine(String.Join(" ", item));
                }
                break;
            }
            string[] split = line.Split().ToArray();
            int x = int.Parse(split[1]);int y = int.Parse(split[2]); int operat = int.Parse(split[3]);
            if(x<0||x>=list.Count)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }
            else if (list[x].Count<=y||y<0)
            {
                Console.WriteLine("Invalid coordinates");
                continue;
            }
            if (split[0]=="Add")
            {
                list[x][y] += operat;
            }
            else if (split[0]=="Subtract")
            {
                list[x][y] -= operat;
            }
        }
    }
}