using System;
using System.Collections;
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
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using System.Net;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Ktypton_Bank
{
    public partial class accountform : KryptonForm
    {
        public accountform()
        {
            InitializeComponent();
        }

        private void accountform_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void kryptonButton4_Click(object sender, EventArgs e)
        {
            decimal maintenanceFee = 2000;
            txtMaintenanceFee.Text = maintenanceFee.ToString();

            // Provide options for account type
            string accountType = cmbAccountType.SelectedItem.ToString(); // Assuming you have a ComboBox for account type with options "Savings" and "Checking"

            // Other user inputs
            float balance = float.Parse(txtBalance.Text);
            string customerName = txtName.Text;
            DateTime dob = DateTime.Parse(txtDob.Text);

            // Generate account number and key
            string accountNumber = GenerateAccountNumber();
            string key = GenerateKey(); // Generate a unique key

            Account account;
            if (accountType == "Checking")
            {
                account = new CheckingAccount();
            }
            else if (accountType == "Savings")
            {
                account = new SavingsAccount();
            }
            else
            {
                MessageBox.Show("Invalid account type selected.");
                return;
            }

            account.AccountNumber = accountNumber;
            account.CustomerName = customerName;
            account.Balance = balance;
            account.RegistrationDate = DateTime.Now;
            account.MaintenanceFee = maintenanceFee;
            account.Key = key;

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                string getCustomerIdQuery = "SELECT customer_ID FROM Customer WHERE name = @CustomerName";
                string query = "INSERT INTO Account (account_Type, balance, customer_ID, RegistrationDate, maintenanceFee, KeyColumn, AccountNumber) VALUES (@AccountType, @Balance, @CustomerId, @RegistrationDate, @MaintenanceFee, @Key, @AccountNumber)";

                try
                {
                    connection.Open();

                    int customerId;
                    using (SqlCommand checkCommand = new SqlCommand(getCustomerIdQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@CustomerName", customerName);
                        
                        object result = checkCommand.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Customer does not exist.");
                            return;
                        }
                        customerId = (int)result;
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AccountType", accountType);
                        command.Parameters.AddWithValue("@Balance", account.Balance);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@RegistrationDate", account.RegistrationDate);
                        command.Parameters.AddWithValue("@MaintenanceFee", account.MaintenanceFee);
                        command.Parameters.AddWithValue("@Key", account.Key);
                        command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Account created successfully.");

                        // Retrieve customer email from database
                        string emailQuery = "SELECT email FROM Customer WHERE name = @CustomerName";
                        string customerEmail = "";

                        using (SqlCommand emailCommand = new SqlCommand(emailQuery, connection))
                        {
                            emailCommand.Parameters.AddWithValue("@CustomerName", customerName);
                            
                            object emailResult = emailCommand.ExecuteScalar();

                            if (emailResult != null)
                            {
                                customerEmail = (string)emailResult;
                            }
                            else
                            {
                                MessageBox.Show("Customer email not found.");
                                return;
                            }
                        }

                        // Send confirmation email
                        await SendConfirmationEmailAsync(customerName, accountNumber, key, customerEmail);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private async Task SendConfirmationEmailAsync(string name, string accountNumber, string key, string customerEmail)
        {
            var client = new MailjetClient("5b7bd7049212278211eb78f051291f47", "4ddc31eada863ee14fd9e4fe391c99e2");
            var request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Account Confirmation")
            .Property(Send.TextPart, $"Dear {name},\n\nYour account has been created successfully. Your account number is: {accountNumber} and your key is: {key}\n\nBest regards,\nBank")
            .Property(Send.HtmlPart, $@"
    <html>
    <body>
        <p>Dear {name},</p>
        <p>Your account has been created successfully.</p>
        <p>Your account number is: <strong>{accountNumber}</strong></p>
        <p>Your key is: <strong>{key}</strong></p>
        <p>Best regards,<br>Krypton Bank</p>
    </body>
    </html>")
            .Property(Send.Recipients, new JArray
            {
        new JObject
        {
            { "Email", customerEmail }
        }
            });

            var response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Confirmation email sent successfully.");
            }
            else
            {
                MessageBox.Show("Failed to send confirmation email.");
            }
        }

        // Method to generate a unique account number
        private string GenerateAccountNumber()
        {
            // Use a combination of a unique identifier and a timestamp
            return $"{DateTime.Now.Ticks}{Guid.NewGuid().ToString("N").Substring(0, 6)}";
        }

        // Method to generate a unique key
        private string GenerateKey()
        {
            // Use a combination of random characters and digits
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }


    public class Account
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public float Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal MaintenanceFee { get; set; }
        public string Key { get; set; }

        public virtual void Deposit(float amount)
        {
            Balance += amount;
        }

        public virtual bool Withdraw(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    public class CheckingAccount : Account
    {
        public bool OverdraftProtection { get; set; }
        public int FreeTransactions { get; set; }
        public int TransactionCount { get; private set; }

        public CheckingAccount()
        {
            OverdraftProtection = true; // Default value
            FreeTransactions = 10; // Default number of free transactions per month
            TransactionCount = 0;
        }

        public override bool Withdraw(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                IncrementTransactionCount();
                return true;
            }
            else if (OverdraftProtection)
            {
                Balance -= amount;
                IncrementTransactionCount();
                return true;
            }
            return false;
        }

        private void IncrementTransactionCount()
        {
            TransactionCount++;
            if (TransactionCount > FreeTransactions)
            {
                ApplyTransactionFee();
            }
        }

        private void ApplyTransactionFee()
        {
            float transactionFee = 5; // Example transaction fee
            Balance -= transactionFee;
        }
    }

    public class SavingsAccount : Account
    {
        public float InterestRate { get; set; }

        public SavingsAccount()
        {
           InterestRate = 0.03f; // Default interest rate
        }

        public void ApplyInterest() 
        {
            Balance += Balance * InterestRate;
        }
    }
}


