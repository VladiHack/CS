public class Program
{
    public static void Main(string[] args)
    {
        int[] cupsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] bottlesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int wastedWater = 0;
        Queue<int> cups = new Queue<int>();
        for (int i = 0; i < cupsArr.Length; i++)
        {
            cups.Enqueue(cupsArr[i]);
        }
        Stack<int> bottles = new Stack<int>();
        for (int i = 0; i < bottlesArr.Length; i++)
        {
            bottles.Push(bottlesArr[i]);
        }
        int storage = 0;
        while (cups.Count > 0&& bottles.Count>0)
        {
            storage += bottles.Peek();
            int currentCup = cups.Peek();
            currentCup -= storage;
            if(currentCup <= 0)
            {
                wastedWater += currentCup*(-1);
                cups.Dequeue();
                storage = 0;
            }
            bottles.Pop();
        }
        if(bottles.Count > 0)
        {
            Console.WriteLine($"Bottles: {String.Join(" ",bottles)}");
        }
        else
        {
            Console.WriteLine($"Cups: {String.Join(" ", cups)}");
        }
        Console.WriteLine($"Wasted litters of water: {String.Join(" ",wastedWater)}");
    }
}