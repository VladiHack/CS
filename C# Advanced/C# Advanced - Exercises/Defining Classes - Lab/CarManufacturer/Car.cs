using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
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
                if(year>0)
                this.year=value;
                else
                {
                    throw new ArgumentException("Year can't be negative!");
                }
            }
        }
    }
}
