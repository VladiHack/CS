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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalProject
{
    public partial class Menu : Form
    {
        static int CurrentHospitalID = -1;
        static string UsedHospitalName = "";
        static string connectionString = @"Server = .\SQLEXPRESS; DATABASE = HospitalDB;Integrated Security = True";
        static SqlConnection connection = new SqlConnection(connectionString);
        public Menu()
        {
            InitializeComponent();
            FillAllData();
        }
        //Adding info to the hospital comboboxes
        private void FillHospitalParams()
        {
            connection.Open();
            string query = $"SELECT * FROM Hospital";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            string nameHospital = ""; string hospitalAddress = ""; string hospitalPhoneNum = ""; string state = "";
            txtHospital_Address.Items.Clear(); txtState.Items.Clear(); txtHospital_Name.Items.Clear(); txtHospital_Phone_Number.Items.Clear(); txtUseHospital.Items.Clear();
            while (reader.Read())
            {
                nameHospital = reader[1].ToString();
                hospitalAddress = reader[2].ToString();
                hospitalPhoneNum = reader[3].ToString();
                state = reader[4].ToString();
                txtHospital_Name.Items.Add(nameHospital);
                txtHospital_Address.Items.Add(hospitalAddress);
                txtState.Items.Add(state);
                txtHospital_Phone_Number.Items.Add(hospitalPhoneNum);
                txtUseHospital.Items.Add(nameHospital);
            }
            reader.Close();
            connection.Close();
        }
        //Adding info to the doctor comboboxes
        private void FillDoctorParams()
        {
            connection.Open();
            string query = "";
            if(CurrentHospitalID==-1)
            {
                query = $"select * from Doctor";
            }
            else
            {
                query = $"select * from Doctor\r\ninner join Department on Doctor.Department_ID=Department.Department_ID\r\nwhere Hospital_ID={CurrentHospitalID}";
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            string firstName = ""; string lastName = ""; int departmentId = 0; string phoneNum = "";
            txtDoctor_First_Name.Items.Clear();txt_Doctor_Last_Name.Items.Clear();txt_Doctor_Phone_Number.Items.Clear();txt_Doctor_Department_ID.Items.Clear();
            while (reader.Read())
            {
                firstName = reader[1].ToString();
                lastName = reader[2].ToString();
                departmentId = int.Parse(reader[3].ToString());
                phoneNum = reader[4].ToString();
                txtDoctor_First_Name.Items.Add(firstName);
                txt_Doctor_Last_Name.Items.Add(lastName);
                txt_Doctor_Department_ID.Items.Add(departmentId);
                txt_Doctor_Phone_Number.Items.Add(phoneNum);
            }
            reader.Close();
            connection.Close();
        }
        //Adding info to the Department comboboxes
        private void FillDepartmentParams()
        {
            connection.Open();
            string query = "";
            if (CurrentHospitalID == -1)
            {
                query = $"select * from Department order by Department_Name";
            }
            else
            {
                query = $"select * from Department where Hospital_ID={CurrentHospitalID} order by Department_Name";
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            string name = "";
            txtDepartment_Name.Items.Clear();
            while (reader.Read())
            {
                name = reader[2].ToString();
                txtDepartment_Name.Items.Add(name);
            }
            reader.Close();
            connection.Close();
        }

        private void FillStaffParams()
        {
            connection.Open();
            string query = "";
            if (CurrentHospitalID == -1)
            {
                query = $"select * from Staff order by Department_ID";
            }
            else
            {
                query = $"select * from Staff\r\ninner join Department on Department.Department_ID=Staff.Department_ID\r\nwhere Hospital_ID={CurrentHospitalID} order by Staff.Department_ID";
            }
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            int departmentId = 0; string firstName = "";string lastName = "";string address = "";string phoneNum = "";
            txtStaff_Department_ID.Items.Clear();txtStaff_Address.Items.Clear();txtStaff_First_Name.Items.Clear();txtStaff_Last_Name.Items.Clear();txtStaff_Phone_Number.Items.Clear();
            while (reader.Read())
            {
                departmentId = int.Parse(reader[1].ToString());
                firstName = reader[2].ToString();
                lastName = reader[3].ToString();
                address = reader[4].ToString();
                phoneNum = reader[5].ToString();
                txtStaff_Department_ID.Items.Add(departmentId);
                txtStaff_First_Name.Items.Add(firstName);
                txtStaff_Last_Name.Items.Add(lastName);
                txtStaff_Address.Items.Add(address);
                txtStaff_Phone_Number.Items.Add(phoneNum);
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





        private void FillAllData()
        {
            FillHospitalParams();
            FillDoctorParams();
            FillDepartmentParams();
            FillStaffParams();
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
                FillAllData();

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
                    FillAllData();
                }
              }
            else if(btnRemove.Checked)
            {
                if(String.IsNullOrWhiteSpace(txtHospital_Address.Text)&&String.IsNullOrWhiteSpace(txtHospital_Name.Text)&&String.IsNullOrWhiteSpace(txtHospital_Phone_Number.Text)&&String.IsNullOrWhiteSpace(txtState.Text))
                {
                    MessageBox.Show("Въведете поне една стойност!");
                    return;
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

        private void btnActionPatient_Click(object sender, EventArgs e)
        {
            if(btnRegister.Checked)
            {
                if (String.IsNullOrWhiteSpace(txtPatient_First_Name.Text) || String.IsNullOrWhiteSpace(txtPatient_Last_Name.Text) || String.IsNullOrWhiteSpace(txtPatient_Address.Text) || String.IsNullOrWhiteSpace(txtPatient_Phone_Number.Text))
                {
                    MessageBox.Show("Моля, въведете всички данни!");
                    return;
                }
                connection.Open();
                string queryAdd = $"INSERT INTO Patient (Patient_First_Name,Patient_Last_Name,Patient_Address,Patient_Phone_Number) VALUES (@first_name,@last_name,@address,@phone_num)";
                using (SqlCommand command = new SqlCommand(queryAdd, connection))
                {
                    command.Parameters.AddWithValue("@first_name", txtPatient_First_Name.Text);
                    command.Parameters.AddWithValue("@last_name", txtPatient_Last_Name.Text);
                    command.Parameters.AddWithValue("@address", txtPatient_Address.Text);
                    command.Parameters.AddWithValue("@phone_num", txtPatient_Phone_Number.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавен пациент!");
                    txtPatient_First_Name.Text = "";
                    txtPatient_Last_Name.Text = "";
                    txtPatient_Address.Text = "";
                    txtPatient_Phone_Number.Text = "";
                }
                connection.Close();
            }
        }
    }
    }

