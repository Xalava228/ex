using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoSam
{
    public partial class FormAutorization : Form
    {
        private string connectionString = @"Server = localhost; DataBase = shose_store_sam; Trusted_Connection = True;";
        public FormAutorization()
        {
            InitializeComponent();
        }

        private void linkLabelGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Session.Role = "Гость";
            Session.FullName = "Гость";

            MainForm newForm = new MainForm();
            newForm.Show();
            Hide();
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAutorization_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) || string.IsNullOrWhiteSpace(textBoxPass.Text)) //Проверка на пустое значени
            {
                MessageBox.Show("Заполните логин и пароль");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = @"Select r.RoleName, u.UserName, u.UserFam, u.UserOtch From Users u JOIN Roles r on u.RoleId = r.RoleId WHERE u.Login = @l and u.password = @p";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@l", textBoxLogin.Text);
                        cmd.Parameters.AddWithValue("@p", textBoxPass.Text);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Session.FullName = reader["UserFam"].ToString() + " " + reader["UserOtch"].ToString() + " " + reader["UserName"].ToString();
                            Session.Role = reader["RoleName"].ToString();
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль");
                        }
                    
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
