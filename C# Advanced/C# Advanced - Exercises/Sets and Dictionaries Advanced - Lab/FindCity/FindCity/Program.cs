public class Program
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, List<string>>> map = new Dictionary<string, Dictionary<string, List<string>>>();
        for(int i=0; i<lines; i++)
        {
            string[] read = Console.ReadLine().Split().ToArray();
            if (!map.ContainsKey(read[0]))
            {
                 Dictionary<string,List<string>> keyValueP= new Dictionary<string, List<string>>();
                 map.Add(read[0], keyValueP);
            }
            Dictionary<string, List<string>> current = map[read[0]];
            if (!current.ContainsKey(read[1]))
            {
                List<string> list = new List<string>();
                current.Add(read[1], list);
            }
            current[read[1]].Add(read[2]);
            map[read[0]] = current;
        }
        foreach (var continent in map)
        {
            Console.WriteLine(continent.Key+":");
            foreach (var country in continent.Value)
            {
                Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
            }
        }
    }
}