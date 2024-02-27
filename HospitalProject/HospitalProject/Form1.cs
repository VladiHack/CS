using System;
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
    }
}
