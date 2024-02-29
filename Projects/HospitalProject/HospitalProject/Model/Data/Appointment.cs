using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Model
{
    public class Appointment
    {
        private int patientId;
        private int doctorId;
        public DateTime Date;

        public Appointment(int patientId,int doctorId,DateTime date) 
        {
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.Date = date;
        }


        public int PatientId
        {
            get { return patientId; }
            set
            {
                if (value < 1) throw new ArgumentException("Въведете правилен номер на пациент!");
                else this.patientId = value;
            }
        }

        public int DoctorId
        {
            get
            {
                return doctorId;
            }
            set
            {
                if (value < 1) throw new ArgumentException("Въведете правилен номер на доктор!");
                else this.doctorId= value;
            }
        }
    }
}
