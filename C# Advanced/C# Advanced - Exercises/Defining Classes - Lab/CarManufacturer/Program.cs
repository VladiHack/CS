using CarManufacturer;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter car parameters in the format : Make, Model, Year");
        string[] parameters = Console.ReadLine().Split(", ").ToArray();
        Car car= new Car(parameters[0], parameters[1], int.Parse(parameters[2]));

    }
}