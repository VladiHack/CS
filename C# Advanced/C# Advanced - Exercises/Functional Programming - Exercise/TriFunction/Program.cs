public class Program
{
    public static void Main(string[] args)
    {
        int pointsToCover = int.Parse(Console.ReadLine());
        string[] names = Console.ReadLine().Split().ToArray();
        for (int i = 0; i < names.Length; i++)
        {
            int points = 0;
            for(int s = 0; s < names[i].Length; s++)
            {
                points += names[i][s];
            }
            if(points>=pointsToCover)
            {
                Console.WriteLine(names[i]);
                return;
            }
        }
    }
}