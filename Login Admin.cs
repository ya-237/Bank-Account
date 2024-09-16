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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;

namespace Ktypton_Bank
{
    public partial class Login_Admin : Form
    {
        private int failedAttempts = 0;
        public Login_Admin()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Button Clicked");
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
                {
                    con.Open();
                    string username = txtUsername.Text.Trim();
                    string password = txtPassword.Text.Trim();

                    // Check if the password starts with '@'
                    if (!password.StartsWith("@"))
                    {
                        MessageBox.Show("Password must start with '@'");
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("SELECT username, password FROM logintab WHERE LOWER(username) = LOWER(@username) AND password = @password", con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    MessageBox.Show("Rows Count: " + dt.Rows.Count);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login success");
                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                        failedAttempts = 0; // Reset the counter on successful login
                    }
                    else
                    {
                        failedAttempts++;
                        MessageBox.Show("Password or username doesn't match. Attempt " + failedAttempts + " of 3.");
                        if (failedAttempts >= 3)
                        {
                            MessageBox.Show("Too many failed attempts. Logging out.");
                            this.Close(); // Close the form to log out the user
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Login_Admin_Load(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            AdminAndUser AF = new AdminAndUser();
            this.Hide();
            AF.ShowDialog();
        }
       
    }
}

