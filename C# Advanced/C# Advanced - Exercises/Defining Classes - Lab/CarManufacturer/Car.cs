using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year,double fuelQuantity,double fuelConsumption)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelConsumption = fuelConsumption;
           FuelQuantity = fuelQuantity;
        }

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                this.make= value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int Year
        {
            get
            {
                return this.year;
            }
            set 
            {
                if(value>0)
                this.year=value;
                else
                {
                    throw new ArgumentException("Year can't be negative!");
                }
            }
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > 0)
                    this.fuelQuantity = value;
                else
                    throw new ArgumentException("Fuel Quantity can't be negative!");
            }
        }
        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            set
            {
                if (value > 0)
                    this.fuelConsumption = value;
                else
                    throw new ArgumentException("Fuel Consumption can't be negative!");
            }
        }

        public override string ToString()
        {
            return $"Car make:{this.make}, Car model:{this.model}, Car Year:{this.Year}, Car FuelQuantity:{this.fuelQuantity:F2}, Car FuelConsumption: {this.FuelConsumption:F2}";
        }
    }
}
