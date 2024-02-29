using HospitalProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject.Controller
{
    public static class DoctorController
    {
        public static void AddDoctor(Doctor doctor)
        {
            SqlConnection connection = Database.GetConnection();
            connection.Open();
            string query = $"INSERT INTO Doctor (Doctor_First_Name, Doctor_Last_Name,Department_ID,Doctor_Phone_Number) VALUES (@first_name,@last_name,@department_id,@doctor_phone_number)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@first_name", doctor.FirstName);
                command.Parameters.AddWithValue("@last_name", doctor.LastName);
                command.Parameters.AddWithValue("@department_id", doctor.DepartmentId);
                command.Parameters.AddWithValue("@doctor_phone_number", doctor.PhoneNumber);

                command.ExecuteNonQuery();

            }
        }
        public static bool DoctorExists(Doctor doctor)
        {
            SqlConnection connection = Database.GetConnection();
            connection.Open();
            string query = $"Select * from Doctor where Doctor_First_Name='{doctor.FirstName}' AND Doctor_Last_Name='{doctor.LastName}' AND Department_ID={doctor.DepartmentId} AND Doctor_Phone_Number='{doctor.PhoneNumber}' ";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count++;
            }
            if (count != 1)
            {
                return false;
            }
            return true;
        }
    }
}
