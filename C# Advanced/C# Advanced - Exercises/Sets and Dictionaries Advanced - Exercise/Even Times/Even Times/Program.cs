public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<int,int> timesMet= new Dictionary<int,int>();
        for(int i=0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if(timesMet.ContainsKey(num))
            {
                timesMet[num]++;
            }
            else
            {
                timesMet.Add(num, 1);
            }
        }
        foreach (var item in timesMet)
        {
            if(item.Value%2==0)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}