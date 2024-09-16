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
using ComponentFactory.Krypton.Toolkit;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;

namespace Ktypton_Bank
{
    public partial class walletform : KryptonForm
    {
        public walletform()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void walletform_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text; // Assuming you have a TextBox for username
            string email = txtEmail.Text; // Assuming you have a TextBox for email
            string password = GeneratePassword();

            RegisterAdmin(username, password);
            if (IsUsernameUnique(username))
            {
                SendEmailNotification(username, email, password);
            }
        }

        private string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder password = new StringBuilder("@");

            Random random = new Random();
            for (int i = 0; i < 7; i++) // Generate 7 random characters
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }

        private void RegisterAdmin(string username, string password)
        {
            string connectionString = "Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"; // Update with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); // Ensure the connection is open before executing any commands

                // Check if the username already exists
                string checkQuery = "SELECT COUNT(*) FROM logintab WHERE username = @username";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.");
                        return; // Exit the method if the username is not unique
                    }
                }

                // Insert the new admin if the username is unique
                string query = "INSERT INTO logintab (username, password) VALUES (@username, @password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                }

                connection.Close(); // Close the connection after the operations are completed
            }

            MessageBox.Show("Admin registered successfully!");
        }
        private bool IsUsernameUnique(string username)
        {
            string connectionString = "Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"; // Update with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM logintab WHERE username = @username";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);
                    int count = (int)checkCommand.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        private async void SendEmailNotification(string username, string email, string password)
        {
            MailjetClient client = new MailjetClient("5b7bd7049212278211eb78f051291f47", "4ddc31eada863ee14fd9e4fe391c99e2");

            string htmlContent = $@"
        <html>
        <body>
            <h1>Welcome to Krypton Bank</h1>
            <p>Dear {username},</p>
            <p>You are now an administrator of Krypton Bank.</p>
            <p>Your login password is: <strong>{password}</strong></p>
            <p>Best regards,<br/>Krypton Bank Team</p>
        </body>
        </html>";

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Welcome to Krypton Bank")
            .Property(Send.HtmlPart, htmlContent)
            .Property(Send.Recipients, new JArray {
            new JObject {
                {"Email", email}
            }
            });

            MailjetResponse response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Email sent successfully!");
            }
            else
            {
                MessageBox.Show($"Failed to send email. Status: {response.StatusCode}\n{response.GetErrorMessage()}");
            }
        }
    }
}
