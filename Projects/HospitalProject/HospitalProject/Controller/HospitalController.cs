using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalProject.Model;

namespace HospitalProject.Controller
{
    public static class HospitalController
    {
        public static void AddHospital(Hospital hospital)
        {
                SqlConnection connection=Database.GetConnection();
                connection.Open();
                string query = $"INSERT INTO Hospital (Hospital_Name,Hospital_Address,Hospital_Phone_Number,State) VALUES (@name,@address,@phoneNum,@state)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name",hospital.Name);
                    command.Parameters.AddWithValue("@address", hospital.Address);
                    command.Parameters.AddWithValue("@phoneNum", hospital.PhoneNumber);
                    command.Parameters.AddWithValue("@state",hospital.State);
                    command.ExecuteNonQuery();
               } 
        }
        public static bool HospitalExists(Hospital hospital)
        {
            SqlConnection connection = Database.GetConnection();
            connection.Open();
            string query = $"Select * from Hospital where Hospital_Name='{hospital.Name}' AND Hospital_Address='{hospital.Address}' AND Hospital_Phone_Number='{hospital.PhoneNumber}' AND State='{hospital.State}' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if(count!=1)
            {
                return false;
            }
            return true;
        }
        public static void RemoveHospital(Hospital hospital)
        {
            SqlConnection connection = Database.GetConnection();
            connection.Open();
            string query = $"DELETE FROM Hospital WHERE Hospital_Name='{hospital.Name}' AND Hospital_Address='{hospital.Address}' AND Hospital_Phone_Number='{hospital.PhoneNumber}' AND State='{hospital.State}'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
