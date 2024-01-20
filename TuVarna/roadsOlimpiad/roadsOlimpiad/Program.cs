public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string,int> metName = new Dictionary<string,int>();
        int n = int.Parse(Console.ReadLine());
        int counter = 1;
        for(int i=0;i<n;i++)
        {
            List<string> reader = Console.ReadLine().Split().ToList();
            reader.Sort();
            string combinedString = string.Join(" ", reader);
            if (metName.ContainsKey(combinedString))
            {
                metName[combinedString] = metName[combinedString]+1;
            }
            else
            {
                metName.Add(combinedString,1);
            }
            counter=Math.Max(counter, metName[combinedString]);
        }
        string zero=Console.ReadLine();
        Console.WriteLine(counter);
    }
}