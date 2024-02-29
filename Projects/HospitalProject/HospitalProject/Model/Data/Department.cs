using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Model
{
    public class Department
    {


        private int id;
        private int hospitalId;
        private string name;

        public Department( int hospitalId, string name)
        {
            HospitalId = hospitalId;
            Name = name;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public int HospitalId
        {
            get
            {
                return this.hospitalId;
            }
            set
            {
                if(value<1)
                {
                    throw new ArgumentException("Въведете правилен номер на болница!");
                }
                else
                {
                    this.hospitalId = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Въведете име на отдел!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
    }
}
