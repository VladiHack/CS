public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        bool found=false;
        int[] liters=new int[n];
        int[] distance=new int[n];
        for (int i = 0; i < n; i++)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
            liters[i]= parameters[0];
            distance[i]= parameters[1];
        }
        for(int i=0;i<n;i++)
        {
            bool[] indexMet=new bool[n];
            int k = i;
            int currentFuel = 0;
            bool met=false;
            while (true)
            {
                currentFuel += liters[k];
                if (currentFuel < distance[k])
                {
                    break;
                }
                currentFuel -= distance[k];
                k++;
                if (k == n)
                {
                    k = 0;
                }
                if(k==i)
                {
                    met = true;
                    break;
                }
            }
            if(met)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}