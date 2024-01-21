public class Program
{
    public static void Main(string[] args)
    {
        int carsToPass = int.Parse(Console.ReadLine());
        Queue<string> cars=new Queue<string>();
        int carsPassed = 0;
        while (true)
        {
            string cmd=Console.ReadLine();
            if (cmd == "end")
            {
                Console.WriteLine($"{carsPassed} cars passed the crossroads.");
                break;
            }
            if(cmd=="green")
            {
                int countRemoved = 0;
                while(countRemoved!=carsToPass&&cars.Count()!=0)
                {
                    Console.WriteLine(cars.Peek()+" passed!");
                    cars.Dequeue();
                    countRemoved++;
                    carsPassed++;
                }
            }
            else
            {
                cars.Enqueue(cmd);
            }
        }
    }
}