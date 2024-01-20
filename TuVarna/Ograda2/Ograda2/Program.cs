public class Program
{
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t; i++)
        {
            int n=int.Parse(Console.ReadLine());
            int leftX = 1000;int rightX = -1000;int downY = 1000;int upY = -1000;
            for(int s=0;s<n; s++)
            {
                int[] param = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (param[0]<leftX)
                {
                    leftX = param[0];
                }
                if (param[0]>rightX)
                {
                    rightX = param[0];
                }
                if (param[0]>upY)
                {
                    upY = param[0];
                }
                if (param[0]<downY)
                {
                    downY = param[0];
                }
            }
            int xRes = rightX - leftX;
            int yRes= upY - downY;
            int res=Math.Max(xRes,yRes);
            Console.WriteLine((res+2)*4);

        }
    }
}