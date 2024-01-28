public class Program
{
    public static void Main(string[] args)
    {
        int bulletPrice = int.Parse(Console.ReadLine());
        int bulletCapacity=int.Parse(Console.ReadLine());
        int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] locksArr= Console.ReadLine().Split().Select(int.Parse).ToArray();
        int intelligence=int.Parse(Console.ReadLine());

        Stack<int> bullets=new Stack<int>();
        for(int i = 0; i < bulletsArr.Length; i++)
        {
            bullets.Push(bulletsArr[i]);
        }

        Queue<int> locks=new Queue<int>();
        for (int i = 0; i < locksArr.Length; i++)
        {
            locks.Enqueue(locksArr[i]);
        }

        while (locks.Count > 0 && bullets.Count > 0)
        {   
            if(bullets.Peek()<=locks.Peek())
            {
                Console.WriteLine("Bang!");
                locks.Dequeue();
            }
            else
            {
                Console.WriteLine("Ping!");
            }
            bullets.Pop();
            if((bulletsArr.Length-bullets.Count)%bulletCapacity==0&&bullets.Count!=0)
            {
                Console.WriteLine("Reloading!");
            }
        }
        if(locks.Count==0)
        {
            Console.WriteLine($"{bullets.Count} bullets left. Earned "+"$"+(intelligence-(bulletsArr.Length-bullets.Count)*bulletPrice));
        }
        else
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
        }
    }
}