public class Program
{
    public static void Main(string[] args)
    {
        List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
        list=list.OrderByDescending(x => x).ToList();
        for(int i=0;i<list.Count; i++)
        {
            if (i > 2)
                break;
            Console.Write(list[i]+" ");
        }
    }
}