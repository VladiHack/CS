public class Program
{
    public static void Main(string[] args)
    {
        int tests = int.Parse(Console.ReadLine());
        for(int i=0;i<tests;i++)
        {
            int recordings=int.Parse(Console.ReadLine());
            int counter = 0;
            for(int s=0;s<recordings;s++)
            {
                string egn=Console.ReadLine();
                if ((egn[egn.Length-2]-'0')%2==0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}