public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t;i++)
        {
            int ovce=int.Parse(Console.ReadLine());
            int agneta = (ovce / 3) * 2 + (ovce / 2);
            Console.WriteLine(agneta/2+ovce);
        }
    }
}