using CarManufacturer;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter car parameters in the format : Make, Model, Year\nor : Make, Model, Year, FuelQuantity, FuelConsumption");
            string[] parameters = Console.ReadLine().Split(", ").ToArray();
            if (parameters.Length >= 3)
            {
                Car car = new Car(parameters[0], parameters[1], int.Parse(parameters[2]));
                if (parameters.Length == 5)
                {
                    double fuelQuantity = double.Parse(parameters[3]);
                    double fuelConsumption = double.Parse(parameters[4]);
                    car.FuelConsumption = fuelConsumption;
                    car.FuelQuantity = fuelQuantity;
                }
                Console.WriteLine(car);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
       
       

    }
}