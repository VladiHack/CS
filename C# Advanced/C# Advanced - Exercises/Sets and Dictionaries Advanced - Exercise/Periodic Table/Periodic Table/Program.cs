public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> elements= new List<string>();
        for(int i=0; i<n; i++)
        {
            string[] read = Console.ReadLine().Split().ToArray();
            for(int s=0;s<read.Length; s++)
            {
                if (elements.Contains(read[s])==false)
                {
                    elements.Add(read[s]);
                }
            }
        }
        elements=elements.OrderBy(x => x).ToList();
        Console.WriteLine(String.Join(" ",elements));
    }
}
          
