public class Program
{
    public static void Main(string[] args)
    {
        SortedDictionary<char,int> timesMetSymbol = new SortedDictionary<char,int>();
        string read = Console.ReadLine();
        for(int i=0;i<read.Length;i++)
        {
            if (timesMetSymbol.ContainsKey(read[i]))
            {
                timesMetSymbol[read[i]]++;
            }
            else
            {
                timesMetSymbol.Add(read[i], 1);
            }
        }
        foreach (var item in timesMetSymbol)
        {
            Console.WriteLine(item.Key+": "+item.Value+" time/s");
        }
    }
}