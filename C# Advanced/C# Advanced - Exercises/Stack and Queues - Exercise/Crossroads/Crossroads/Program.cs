public class Program
{
    public static void Main(string[] args)
    {
        bool CarCrash = false;
        int carsPassed = 0;
        int green = int.Parse(Console.ReadLine());
        int freeLight=int.Parse(Console.ReadLine());
        Queue<string> queue = new Queue<string>();
        while(true)
        {
            string read=Console.ReadLine();
            if (read == "END")
            {
                break;
            }
            if(read=="green")
            {
                int currentGreen = green;
                int currentFreeLight = freeLight;
                while(queue.Count > 0 && currentGreen>0)
                {
                    string car = queue.Peek();
                    if (car.Length <= currentGreen)
                    {
                        currentGreen-=car.Length;
                        carsPassed++;
                    }
                    else if(car.Length <= currentFreeLight+currentGreen)
                    {
                        currentGreen = 0;
                        carsPassed++;
                    }
                    else if(CarCrash==false)
                    {
                        CarCrash = true;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine(car+" "+$"was hit at {car[currentGreen+currentFreeLight]}.");
                    }
                    queue.Dequeue();
                }
            }
            else
            {
                queue.Enqueue(read);
            }
        }
        if (CarCrash == false)
        {
            Console.WriteLine($"Everyone is safe.\n{carsPassed} total cars passed the crossroads.");
        }
    }
}