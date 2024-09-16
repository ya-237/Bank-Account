using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using iTextSharp.text.pdf;
using System.Web;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace Ktypton_Bank
{
    public partial class CreateAccount : KryptonForm
    {
        public CreateAccount()
        {
            InitializeComponent();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void  kryptonButton1_ClickAsync(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string prename = txtPrename.Text;

            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Please enter a valid age.");
                return;
            }
            string occupation = txtOccupation.Text;
            string phone = txtPhone.Text; 
            string city = txtCity.Text;
            if (!DateTime.TryParse(txtDateOfBirth.Text, out DateTime dateOfBirth))
            {
                MessageBox.Show("Please enter a valid date of birth.");
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.");
                txtEmail.Clear();
                return;
            }
            string password = GenerateStrongPassword();



            // Register the member (you can add your database registration logic here)
            RegisterMember(name, email,prename,age,dateOfBirth,occupation,phone,city,password);

            
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private async void RegisterMember(string name, string email, string prename, int age, DateTime dateOfBirth,string occupation, string mobilenumber, string city,string password)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                string checkQuery = "SELECT COUNT(*) FROM Customer WHERE name = @Name";
                string query = "INSERT INTO Customer (name, prename, age, dob, email, occupation, mobilenumber, city, RegistrationDate, password) VALUES (@Name,@Prename, @Age, @DateOfBirth, @Email, @Occupation, @mobilenumber, @city, @RegistrationDate,@Password)";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    
                        checkCommand.Parameters.AddWithValue("@Name", name);
                        connection.Open();
                        int count = (int)checkCommand.ExecuteScalar();
                        connection.Close();

                        if (count > 0)
                        {
                            MessageBox.Show("A member with this name already exists.");
                            txtName.Clear();    
                     
                        }
                        else {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Name", name);
                            command.Parameters.AddWithValue("@Prename", prename);
                            command.Parameters.AddWithValue("@Age", age);
                            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@Occupation", occupation);
                            command.Parameters.AddWithValue("@mobilenumber", mobilenumber);
                            command.Parameters.AddWithValue("@city", city);
                            command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                            command.Parameters.AddWithValue("@Password", password);

                            connection.Open();
                            command.ExecuteNonQuery();

                            // Send welcome email
                            await SendWelcomeEmail(email, name, password);

                            MessageBox.Show("Registration successful! A welcome email has been sent.");
                            this.
                            Hide();
                            UserLogin userLogin = new UserLogin();

                            userLogin.Show();
                        }
                    }
                }

                
            }
        }
       
        private string GenerateStrongPassword(int length = 12)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder result = new StringBuilder();
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    result.Append(validChars[(int)(num % (uint)validChars.Length)]);
                }
            }
            return result.ToString();
        }


        private async Task SendWelcomeEmail(string email, string name,string password)
        {
            var apiKey = "5b7bd7049212278211eb78f051291f47"; // Use environment variable for API key
            var apiSecret = "4ddc31eada863ee14fd9e4fe391c99e2"; // Use environment variable for API secret

            MailjetClient client = new MailjetClient(apiKey, apiSecret);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Welcome to Our Bank!")
            .Property(Send.TextPart, $"Hello {name}, welcome to our bank! Your password is {password}")
            .Property(Send.HtmlPart, $"<strong>Hello {name}, welcome to Krypton bank!</strong><br>Your password is: <strong>{password}</strong>")
            .Property(Send.Recipients, new JArray {
        new JObject {
            {"Email", email}
        }
            });

            try
            {
                MailjetResponse response = await client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Welcome email sent successfully!");
                }
                else
                {
                    MessageBox.Show($"Failed to send email: {response.StatusCode}");
                }
                await client.PostAsync(request);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Exception caught: {ex.Message}");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

