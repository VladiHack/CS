public class Program
{
    public static void Main(string[] args)
    {
        int names = int.Parse(Console.ReadLine());
        HashSet<string> uniqueNames=new HashSet<string>();
        for (int i = 0; i < names; i++)
        {
            string readName=Console.ReadLine();
            uniqueNames.Add(readName);
        }
        foreach (var item in uniqueNames)
        {
            Console.WriteLine(item);
        }
    }
}