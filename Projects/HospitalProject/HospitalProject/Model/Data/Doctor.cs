using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Model
{
    public class Doctor : Person
    {
        int id;
        int departmentId;

        public Doctor(string firstName, string lastName, string phoneNumber, int departmentId) : base(firstName,lastName,phoneNumber)
        {
            this.DepartmentId = departmentId;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int DepartmentId
        {
            get
            {
                return this.departmentId;
            }
            set
            {
                if(value<1)
                {
                    throw new ArgumentException("Невалиден номер на отдел!");
                }
                else
                {
                    this.departmentId = value;
                }
            }
        }
       
    }
}
