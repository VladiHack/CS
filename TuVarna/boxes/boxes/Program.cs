using System.Runtime.CompilerServices;

public class Program
{
    static bool yes = false;
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        long k = 1;
        while(true)
        {
            int size = n * 2;
            long pos = k%size;
            while(true)
            {
                if(size==n)
                {
                    Console.WriteLine(k);
                    return;
                }
                if(pos<=n&&pos!=0)
                {
                    break;
                }
                if(pos!=0)
                {
                    pos--;
                }
                pos += k;
                size-=1;
                pos %= size;
            }
            k++;
        }
    }
}