public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();
        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split().ToArray();
            if (dict.ContainsKey(split[0]))
            {
                dict[split[0]].Add(decimal.Parse(split[1]));
            }
            else
            {
                List<decimal> list = new List<decimal>();
                list.Add(decimal.Parse(split[1]));
                dict.Add(split[0], list);
            }
        }
        foreach (var item in dict)
        {
            string name = item.Key;
            List<decimal> list = item.Value;
            Console.Write($"{name} -> ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write($"{list[i]:F2} ");
            }
            Console.WriteLine($"(avg: {list.Average():F2})");
        }
    }
}