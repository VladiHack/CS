public class Program
{
    public static void Main(string[] args)
    {
        string[] names = Console.ReadLine().Split().ToArray();
        int jump = int.Parse(Console.ReadLine());
        int lastIndex = 0;
        int namesRemaining = names.Length;
        bool[] metIndex = new bool[names.Length];
        while (namesRemaining!=1)
        {
            int counter = jump;
            while (counter > 0)
            {
                if (lastIndex == names.Length)
                {
                    lastIndex = 0;
                }
                counter--;
                lastIndex++;
                if (metIndex[counter-1])
                {
                    counter++;
                }
            }
        }
    }
}