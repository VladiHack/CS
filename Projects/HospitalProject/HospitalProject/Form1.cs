﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalProject
{
    public partial class Form1 : Form
    {
        static int CurrentHospitalID = -1;
        static string UsedHospitalName = "";
        static string connectionString = @"Server = .\SQLEXPRESS; DATABASE = HospitalDB;Integrated Security = True";
        static SqlConnection connection = new SqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
            UpdateHospitalNames();
        }
        private void UpdateHospitalNames()
        {
            connection.Open();
            string query = $"SELECT Hospital.Hospital_Name FROM Hospital";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string nameHospital = reader[0].ToString();
                txtUseHospital.Items.Add(nameHospital);
            }
            reader.Close();
            connection.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (btnRegister.Checked==true)
            {
                btnActionHospital.Visible = true;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            btnActionHospital.Text = "Register";
            btnActionAppointment.Text = "Register";
            btnActionDepartment.Text = "Register";
            btnActionDoctor.Text = "Register";
            btnActionPatient.Text = "Register";
            btnActionStaff.Text = "Register";
            lblDepartmentID.Visible = false;
            lblDoctorID.Visible=false;
            lblHospitalID.Visible = false;
            lblIDPatient.Visible = false;
            lblStaffID.Visible = false;
            txtHospital_ID.Visible = false;
            txtDoctor_ID.Visible = false;
            txtPatient_ID.Visible = false;
            txtStaff_ID.Visible = false;
            txtDepartment_ID.Visible = false;
        }

        private void btnSelect_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            btnActionHospital.Text = "Select";
            btnActionAppointment.Text = "Select";
            btnActionDepartment.Text = "Select";
            btnActionDoctor.Text = "Select";
            btnActionPatient.Text = "Select";
            btnActionStaff.Text = "Select";
        }
        private void RemoveOrSelectHider()
        { 

        }
        private void btnRemove_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            btnActionHospital.Text = "Remove";
            btnActionAppointment.Text = "Remove";
            btnActionDepartment.Text = "Remove";
            btnActionDoctor.Text = "Remove";
            btnActionPatient.Text = "Remove";
            btnActionStaff.Text = "Remove";
        }

        private void btnUseHospital_Click(object sender, EventArgs e)
        {
            string dbName = txtUseHospital.Text;
            bool foundHospital = false;
            connection.Open();
                string query = $"SELECT * FROM Hospital";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string nameHospital = reader[1].ToString();
                    if(nameHospital==dbName)
                    {
                        foundHospital = true;
                        CurrentHospitalID = int.Parse(reader[0].ToString());
                        break;
                    }
                }
                reader.Close();
              connection.Close();
                if(foundHospital)
                {
                    MessageBox.Show($"Вече използвате болницата : {txtUseHospital.Text}");
                    lblUsedDB.Text = dbName;
                    UsedHospitalName = lblUsedDB.Text;
                txtAppointment_Patient_Full_Name.Items.Clear();
                txtAppointment_Doctor_Full_Name.Items.Clear();
                //Fill appointment's 2 fields with data
                connection.Open();
                string queryPatientFullName = $"select * from Patient\r\ninner join Appointment on Appointment.Patient_ID=Patient.Patient_ID\r\ninner join Department on Appointment.Doctor_ID=Department.Department_ID\r\nwhere Hospital_ID={CurrentHospitalID}\r\norder by Patient_First_Name,Patient_Last_Name ";
                SqlCommand commandPatient = new SqlCommand(queryPatientFullName, connection);
                SqlDataReader readerPatient = commandPatient.ExecuteReader();
                while (readerPatient.Read())
                {
                   string firstName = readerPatient[1].ToString();
                   string lastName = readerPatient[2].ToString();
                    txtAppointment_Patient_Full_Name.Items.Add(firstName+" "+lastName);
                }
                readerPatient.Close();
                string queryDoctor = $"select * from Doctor\r\ninner join Department on Doctor.Department_ID=Department.Department_ID\r\nwhere Hospital_ID={CurrentHospitalID}\r\norder by Doctor_First_Name,Doctor_Last_Name";
                SqlCommand commandDoctor = new SqlCommand(queryDoctor, connection);
                SqlDataReader readerDoctor = commandDoctor.ExecuteReader();
                while (readerDoctor.Read())
                {
                    string firstName = readerDoctor[1].ToString();
                    string lastName = readerDoctor[2].ToString();
                    txtAppointment_Doctor_Full_Name.Items.Add(firstName + " " + lastName);
                }
                readerDoctor.Close();
                connection.Close();


               }
                else
                {
                    MessageBox.Show($"Болница с име : {txtUseHospital.Text} не е намерена");
                }
                txtUseHospital.Text = "";

            
        }

        private void btnActionHospital_Click(object sender, EventArgs e)
        {
               if(btnRegister.Checked)
               {
                connection.Open();
                string query = $"INSERT INTO Hospital (Hospital_Name,Hospital_Address,Hospital_Phone_Number,State) VALUES (@name,@address,@phoneNum,@state)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", txtHospital_Name.Text);
                    command.Parameters.AddWithValue("@address", txtHospital_Address.Text);
                    command.Parameters.AddWithValue("@phoneNum", txtHospital_Phone_Number.Text);
                    command.Parameters.AddWithValue("@state", txtState.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавена болница.");
                    txtUseHospital.Items.Clear();
                    connection.Close();
                    UpdateHospitalNames();
                }
              }
                

            
        }

        private void btnActionDoctor_Click(object sender, EventArgs e)
        {
            if(btnRegister.Checked)
            {
                connection.Open();
                string query = $"INSERT INTO Doctor (Doctor_First_Name, Doctor_Last_Name,Department_ID,Doctor_Phone_Number) VALUES (@first_name,@last_name,@department_id,@doctor_phone_number)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@first_name", txtDoctor_First_Name.Text);
                    command.Parameters.AddWithValue("@last_name", txt_Doctor_Last_Name.Text);
                    command.Parameters.AddWithValue("@department_id", int.Parse(txt_Doctor_Department_ID.Text));
                    command.Parameters.AddWithValue("@doctor_phone_number", txt_Doctor_Phone_Number.Text);

                    command.ExecuteNonQuery();
                    txtDoctor_First_Name.Text = "";
                    txt_Doctor_Department_ID.Text = "";
                    txt_Doctor_Phone_Number.Text = "";
                    txt_Doctor_Last_Name.Text = "";
                    MessageBox.Show("Успешно добавен лекар.");

                }
            }
           
        }

        private void btnActionDepartment_Click(object sender, EventArgs e)
        {
            if (btnRegister.Checked)
            {
                if(CurrentHospitalID==-1)
                {
                    MessageBox.Show("Моля, изберете болница!");
                    return;
                }
                if(String.IsNullOrWhiteSpace(txtDepartment_Name.Text))
                {
                    MessageBox.Show("Моля, въведете име на отдел!");
                    return;
                }
                connection.Open();
                string query = $"INSERT INTO Department (Hospital_ID,Department_Name) VALUES (@hospital_id,@department_name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hospital_id", CurrentHospitalID);
                    command.Parameters.AddWithValue("@department_name", txtDepartment_Name.Text);


                    command.ExecuteNonQuery();
                    txtDepartment_Name.Text = "";
                    MessageBox.Show("Успешно добавен отдел!");

                }
                connection.Close();
            }
        }

        private void btnActionStaff_Click(object sender, EventArgs e)
        {
            if(btnRegister.Checked)
            {
                if (CurrentHospitalID == -1)
                {
                    MessageBox.Show("Моля, изберете болница!");
                    return;
                }
                if (String.IsNullOrEmpty(txtStaff_Address.Text)||String.IsNullOrEmpty(txtStaff_Department_ID.Text)||String.IsNullOrEmpty(txtStaff_Last_Name.Text)||String.IsNullOrEmpty(txtStaff_Phone_Number.Text))
                {
                    MessageBox.Show("Моля, въведете всички данни!");
                    return;
                }
                connection.Open();
                string query = $"INSERT INTO Staff (Department_ID,Staff_First_Name,Staff_Last_Name,Staff_Address,Staff_Phone_Number) VALUES (@department_id,@first_name,@last_name,@address,@phone_num)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@department_id",int.Parse(txtStaff_Department_ID.Text));
                    command.Parameters.AddWithValue("@first_name", txtStaff_First_Name.Text);
                    command.Parameters.AddWithValue("@last_name", txtStaff_Last_Name.Text);
                    command.Parameters.AddWithValue("@address", txtStaff_Address.Text);
                    command.Parameters.AddWithValue("@phone_num", txtStaff_Phone_Number.Text);
                    command.ExecuteNonQuery();
                    txtStaff_Department_ID.Text = "";
                    txtStaff_First_Name.Text = "";
                    txtStaff_Last_Name.Text = "";
                    txtStaff_Address.Text = "";
                    txtStaff_Address.Text = "";
                    txtStaff_Phone_Number.Text = "";
                    MessageBox.Show("Успешно добавен служител!");

                }
                connection.Close();
            }
        }

        private void btnActionAppointment_Click(object sender, EventArgs e)
        {
            if(btnRegister.Checked)
            {
                if (CurrentHospitalID == -1)
                {
                    MessageBox.Show("Моля, изберете болница!");
                    return;
                }
                if (txtAppointment_Doctor_Full_Name.Text==""||txtAppointment_Patient_Full_Name.Text==""||AppointmentDate.Checked==false)
                {
                    MessageBox.Show("Моля, въведете всички данни!");
                    return;
                }
                //Checking if the name of the patient exists
                bool nameIsCorrect = false;
                for (int i = 0; i < txtAppointment_Patient_Full_Name.Items.Count; i++)
                {
                    if (txtAppointment_Patient_Full_Name.Text .CompareTo(txtAppointment_Patient_Full_Name.Items[i].ToString())==0)
                    {
                        nameIsCorrect = true;
                        break;
                    }
                }
                if(nameIsCorrect==false)
                {
                    MessageBox.Show("Името на пациента не отговаря на нито едно име в болницата!");
                    return;
                }
                bool doctorName = false;
                for (int i = 0; i < txtAppointment_Doctor_Full_Name.Items.Count; i++)
                {
                    if (txtAppointment_Doctor_Full_Name.Text.CompareTo(txtAppointment_Doctor_Full_Name.Items[i].ToString()) == 0)
                    {
                        doctorName = true;
                        break;
                    }
                }
                if (doctorName == false)
                {
                    MessageBox.Show("Името на доктора не отговаря на нито едно име в болницата!");
                    return;
                }

                string[] patientFullName = txtAppointment_Patient_Full_Name.Text.Split().ToArray();
                int idPatient = -1;
                connection.Open();
                string query = $"SELECT * FROM Patient where Patient_First_Name='{patientFullName[0]}' AND Patient_Last_Name='{patientFullName[1]}'";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    idPatient = int.Parse(reader[0].ToString());
                    break;
                }
                reader.Close();
                connection.Close();
                string[] doctorFullName = txtAppointment_Doctor_Full_Name.Text.Split().ToArray();
                int idDoctor = -1;
                connection.Open();
                string queryDoc = $"SELECT * FROM Doctor where Doctor_First_Name='{doctorFullName[0]}' AND Doctor_Last_Name='{doctorFullName[1]}'";
                SqlCommand commandDoc = new SqlCommand(query, connection);
                SqlDataReader readerDoc = commandDoc.ExecuteReader();
                while (readerDoc.Read())
                {
                    idDoctor = int.Parse(readerDoc[0].ToString());
                    break;
                }
                readerDoc.Close();
                connection.Close();

                connection.Open();
                string queryAdd = $"INSERT INTO Appointment (Patient_ID,Doctor_ID,Date) VALUES (@patient_id,@doctor_id,@date)";
                using (SqlCommand commandAdd = new SqlCommand(queryAdd, connection))
                {
                    commandAdd.Parameters.AddWithValue("@patient_id", idPatient);
                    commandAdd.Parameters.AddWithValue("@doctor_id", idDoctor);
                    commandAdd.Parameters.AddWithValue("@date",DateTime.Parse(AppointmentDate.Text));
                    commandAdd.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавено посещение!");
                    txtAppointment_Patient_Full_Name.Text = "";
                    txtAppointment_Doctor_Full_Name.Text = "";
                    AppointmentDate.Text = "";

                }
                connection.Close();
            }
        }
     }
    }

