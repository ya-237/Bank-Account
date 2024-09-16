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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Ktypton_Bank
{
    public partial class transactionform : KryptonForm
    {
        public transactionform()
        {
            InitializeComponent();
        }

        private void statisticsform_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }
        public enum TransactionType
        {
            Deposit,
            Withdrawal,
            Transfer
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string selectedTransactionType = PopulateTransactionTypeComboBox.SelectedItem.ToString();
            string accountNumber = txtAccountNumber.Text;
            decimal amount;

            if (!decimal.TryParse(txtAmount.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            switch (selectedTransactionType)
            {
                case "Deposit":
                    ProcessTransaction(TransactionType.Deposit, amount, accountNumber);
                    break;
                case "Withdraw":
                    ProcessTransaction(TransactionType.Withdrawal, amount, accountNumber);
                    break;
                case "Transfer":
                    string destinationAccountNumber = txtDestinationAccountNumber.Text;
                    if (string.IsNullOrEmpty(destinationAccountNumber))
                    {
                        MessageBox.Show("Please enter a destination account number.");
                        return;
                    }
                    ProcessTransaction(TransactionType.Transfer, amount, accountNumber, destinationAccountNumber);
                    break;
                default:
                    MessageBox.Show("Invalid transaction type selected.");
                    break;
            }
        }

        public void ProcessTransaction(TransactionType transactionType, decimal amount, string accountNumber, string destinationAccountNumber = null)
        {
            switch (transactionType)
            {
                case TransactionType.Deposit:
                    Deposit(amount, accountNumber);
                    break;
                case TransactionType.Withdrawal:
                    Withdraw(amount, accountNumber);
                    break;
                case TransactionType.Transfer:
                    Transfer(amount, accountNumber, destinationAccountNumber);
                    break;
            }
        }

        private async void Deposit(decimal amount, string accountNumber)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    bool transactionCommitted = false;
                    try
                    {
                        
                        // Check if the account exists
                        string checkAccountQuery = "SELECT account_id, customer_ID FROM Account WHERE AccountNumber = @AccountNumber";
                        int accountId;
                        int customerId;
                        using (SqlCommand checkAccountCommand = new SqlCommand(checkAccountQuery, connection, transaction))
                        {
                            checkAccountCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                            using (SqlDataReader reader = checkAccountCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show("Account does not exist.");
                                    return;
                                }
                                accountId = reader.GetInt32(0);
                                customerId = reader.GetInt32(1);
                            }
                        }
                        MessageBox.Show($"Account ID: {accountId}, Customer ID: {customerId}");

                        string getCustomerQuery = "SELECT email, name FROM Customer WHERE customer_ID = @CustomerId";
                        string customerEmail = string.Empty;
                        string customerName = string.Empty;
                        using (SqlCommand getCustomerCommand = new SqlCommand(getCustomerQuery, connection, transaction))
                        {
                            getCustomerCommand.Parameters.AddWithValue("@CustomerId", customerId);
                            using (SqlDataReader reader = getCustomerCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    customerEmail = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                    customerName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                }
                            }
                        }
                        MessageBox.Show($"Customer Email: {customerEmail}, Customer Name: {customerName}");
                        // Update the account balance
                        string updateBalanceQuery = "UPDATE Account SET balance = balance + @Amount WHERE AccountNumber = @AccountNumber";
                        using (SqlCommand updateBalanceCommand = new SqlCommand(updateBalanceQuery, connection, transaction))
                        {
                            updateBalanceCommand.Parameters.AddWithValue("@Amount", amount);
                            updateBalanceCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                            updateBalanceCommand.ExecuteNonQuery();
                        }

                        // Insert transaction record
                        string insertTransactionQuery = "INSERT INTO Transactions (AccountID, TransactionType, Amount) VALUES (@AccountID, @TransactionType, @Amount)";
                        int transactionId;
                        using (SqlCommand insertTransactionCommand = new SqlCommand(insertTransactionQuery, connection, transaction))
                        {
                            insertTransactionCommand.Parameters.AddWithValue("@AccountID", accountId);
                            insertTransactionCommand.Parameters.AddWithValue("@TransactionType", "Deposit");
                            insertTransactionCommand.Parameters.AddWithValue("@Amount", amount);
                            insertTransactionCommand.ExecuteNonQuery();
                            transactionId = Convert.ToInt32(insertTransactionCommand.ExecuteScalar());
                        }

                        // Commit transaction
                        transaction.Commit();
                        transactionCommitted = true;
                        MessageBox.Show("Deposit successful.");
                        await SendEmailConfirmation(customerEmail, customerName, amount);
                        var transactionDetails = GetTransactionDetails(transactionId);
                        GenerateTextReceipt(transactionDetails);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if any error occurs
                        if (!transactionCommitted)
                        {
                            transaction.Rollback();
                        }
                        MessageBox.Show("Deposit failed: " + ex.Message);
                    }
                }
            }
        }
        public async Task SendEmailConfirmation(string customerEmail, string customerName, decimal amount)
        {
            MailjetClient client = new MailjetClient("5b7bd7049212278211eb78f051291f47", "4ddc31eada863ee14fd9e4fe391c99e2");

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Deposit Confirmation")
            .Property(Send.TextPart, $"Dear {customerName},\n\nWe are pleased to inform you that an amount of {amount:C} has been successfully deposited into your account.\n\nThank you for banking with us.\n\nBest regards,\nYour Bank Name")
            .Property(Send.HtmlPart, $"<h3>Dear {customerName},</h3><p>We are pleased to inform you that an amount of <strong>{amount}</strong> has been successfully deposited into your account.</p><p>Thank you for banking with us.</p><p>Best regards,<br>Your Bank Name</p>")
            .Property(Send.Recipients, new JArray {
        new JObject {
            {"Email", customerEmail}
        }
            });

            MailjetResponse response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Email sent successfully to {customerEmail}");
            }
            else
            {
                MessageBox.Show($"Failed to send email. Status: {response.StatusCode}\n{response.GetErrorMessage()}");
            }
        }


        private async void Withdraw(decimal amount, string accountNumber)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    bool transactionCommitted = false;
                    try
                    {
                        string checkAccountQuery = "SELECT account_id, customer_ID, balance FROM Account WHERE AccountNumber = @AccountNumber";
                        int accountId;
                        int customerId;
                        int balance;

                        using (SqlCommand checkAccountCommand = new SqlCommand(checkAccountQuery, connection, transaction))
                        {
                            checkAccountCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                            using (SqlDataReader reader = checkAccountCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show("Account does not exist.");
                                    return;
                                }
                                accountId = reader.GetInt32(0);
                                customerId = reader.GetInt32(1);
                                balance = reader.GetInt32(reader.GetOrdinal("balance"));
                            }
                        }

                        // Retrieve customer email and name
                        string getCustomerQuery = "SELECT email, name FROM Customer WHERE customer_ID = @CustomerId";
                        string customerEmail = string.Empty;
                        string customerName = string.Empty;
                        using (SqlCommand getCustomerCommand = new SqlCommand(getCustomerQuery, connection, transaction))
                        {
                            getCustomerCommand.Parameters.AddWithValue("@CustomerId", customerId);
                            using (SqlDataReader reader = getCustomerCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    customerEmail = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                                    customerName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                                }
                            }
                        }

                        // Check if there are sufficient funds
                        if (balance < (int)amount)
                        {
                            MessageBox.Show("Insufficient funds.");
                            return;
                        }

                        // Update the account balance
                        string updateBalanceQuery = "UPDATE Account SET balance = balance - @Amount WHERE AccountNumber = @AccountNumber";
                        using (SqlCommand updateBalanceCommand = new SqlCommand(updateBalanceQuery, connection, transaction))
                        {
                            updateBalanceCommand.Parameters.AddWithValue("@Amount", (int)amount);
                            updateBalanceCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                            updateBalanceCommand.ExecuteNonQuery();
                        }

                        // Insert transaction record
                        string insertTransactionQuery = "INSERT INTO Transactions (AccountID, TransactionType, Amount) VALUES (@AccountID, @TransactionType, @Amount); SELECT SCOPE_IDENTITY();";
                        int transactionId;
                        using (SqlCommand insertTransactionCommand = new SqlCommand(insertTransactionQuery, connection, transaction))
                        {
                            insertTransactionCommand.Parameters.AddWithValue("@AccountID", accountId);
                            insertTransactionCommand.Parameters.AddWithValue("@TransactionType", "Withdraw");
                            insertTransactionCommand.Parameters.AddWithValue("@Amount",(int)amount);
                            transactionId = Convert.ToInt32(insertTransactionCommand.ExecuteScalar());
                        }

                        // Commit transaction
                        transaction.Commit();
                        transactionCommitted = true;
                        MessageBox.Show("Withdrawal successful.");
                        await SendEmailConfirmation(customerEmail, customerName, amount,"Withdraw");
                        var transactionDetails = GetTransactionDetails(transactionId);
                        GenerateTextReceipt(transactionDetails);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if any error occurs
                        if (!transactionCommitted)
                        {
                            transaction.Rollback();
                        }
                        MessageBox.Show("Withdrawal failed: " + ex.Message);
                    }
                }
            }
        }
        public async Task SendEmailConfirmation(string customerEmail, string customerName, decimal amount, string transactionType)
        {
            MailjetClient client = new MailjetClient("5b7bd7049212278211eb78f051291f47", "4ddc31eada863ee14fd9e4fe391c99e2");

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, $"{transactionType} Confirmation")
            .Property(Send.TextPart, $"Dear {customerName},\n\nWe are pleased to inform you that an amount of {amount} has been successfully {transactionType.ToLower()}ed from your account.\n\nThank you for banking with us.\n\nBest regards,\n Krypton Bank")
            .Property(Send.HtmlPart, $"<h3>Dear {customerName},</h3><p>We are pleased to inform you that an amount of <strong>{amount}</strong> has been successfully {transactionType.ToLower()}ed from your account.</p><p>Thank you for banking with us.</p><p>Best regards,<br>Krypton Bank</p>")
            .Property(Send.Recipients, new JArray {
        new JObject {
            {"Email", customerEmail}
        }
            });

            MailjetResponse response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Email sent successfully to {customerEmail}");
            }
            else
            {
                MessageBox.Show($"Failed to send email. Status: {response.StatusCode}\n{response.GetErrorMessage()}");
            }
        }

        private void Transfer(decimal amount, string sourceAccountNumber, string destinationAccountNumber)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Retrieve source and destination account details, including email addresses
                        string accountQuery = @"
                    SELECT
                        s.account_id AS SourceAccountID, s.balance AS SourceBalance, c1.email AS SourceEmail,
                        d.account_id AS DestinationAccountID, c2.email AS DestinationEmail
                    FROM Account s
                    JOIN Customer c1 ON s.Customer_ID = c1.Customer_ID
                    JOIN Account d ON d.AccountNumber = @DestinationAccountNumber
                    JOIN Customer c2 ON d.Customer_ID = c2.Customer_ID
                    WHERE s.AccountNumber = @SourceAccountNumber";

                        int sourceAccountId;
                        int sourceBalance;
                        string sourceEmail;
                        int destinationAccountId;
                        string destinationEmail;

                        using (SqlCommand accountCommand = new SqlCommand(accountQuery, connection, transaction))
                        {
                            accountCommand.Parameters.AddWithValue("@SourceAccountNumber", sourceAccountNumber);
                            accountCommand.Parameters.AddWithValue("@DestinationAccountNumber", destinationAccountNumber);

                            using (SqlDataReader reader = accountCommand.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show("Source or Destination account does not exist.");
                                    return;
                                }

                                sourceAccountId = reader.GetInt32(reader.GetOrdinal("SourceAccountID"));
                                sourceBalance = reader.GetInt32(reader.GetOrdinal("SourceBalance"));
                                sourceEmail = reader.GetString(reader.GetOrdinal("SourceEmail"));
                                destinationAccountId = reader.GetInt32(reader.GetOrdinal("DestinationAccountID"));
                                destinationEmail = reader.GetString(reader.GetOrdinal("DestinationEmail"));
                            }
                        }

                        // Check if there are sufficient funds
                        if (sourceBalance < amount)
                        {
                            MessageBox.Show("Insufficient funds.");
                            return;
                        }

                        // Update source account balance
                        string updateSourceBalanceQuery = "UPDATE Account SET balance = balance - @Amount WHERE AccountNumber = @SourceAccountNumber";
                        using (SqlCommand updateSourceBalanceCommand = new SqlCommand(updateSourceBalanceQuery, connection, transaction))
                        {
                            updateSourceBalanceCommand.Parameters.AddWithValue("@Amount", amount);
                            updateSourceBalanceCommand.Parameters.AddWithValue("@SourceAccountNumber", sourceAccountNumber);
                            updateSourceBalanceCommand.ExecuteNonQuery();
                        }

                        // Update destination account balance
                        string updateDestinationBalanceQuery = "UPDATE Account SET balance = balance + @Amount WHERE AccountNumber = @DestinationAccountNumber";
                        using (SqlCommand updateDestinationBalanceCommand = new SqlCommand(updateDestinationBalanceQuery, connection, transaction))
                        {
                            updateDestinationBalanceCommand.Parameters.AddWithValue("@Amount", amount);
                            updateDestinationBalanceCommand.Parameters.AddWithValue("@DestinationAccountNumber", destinationAccountNumber);
                            updateDestinationBalanceCommand.ExecuteNonQuery();
                        }

                        int transactionId;
                        // Insert transaction record
                        string insertTransactionQuery = "INSERT INTO Transactions (AccountID, TransactionType, Amount, SourceAccountID, DestinationAccountID) VALUES (@AccountID, @TransactionType, @Amount, @SourceAccountID, @DestinationAccountID); SELECT SCOPE_IDENTITY();";
                        using (SqlCommand insertTransactionCommand = new SqlCommand(insertTransactionQuery, connection, transaction))
                        {
                            insertTransactionCommand.Parameters.AddWithValue("@AccountID", sourceAccountId);
                            insertTransactionCommand.Parameters.AddWithValue("@TransactionType", "Transfer");
                            insertTransactionCommand.Parameters.AddWithValue("@Amount", amount);
                            insertTransactionCommand.Parameters.AddWithValue("@SourceAccountID", sourceAccountId);
                            insertTransactionCommand.Parameters.AddWithValue("@DestinationAccountID", destinationAccountId);
                            transactionId = Convert.ToInt32(insertTransactionCommand.ExecuteScalar());
                        }

                        // Commit transaction
                        transaction.Commit();
                        MessageBox.Show("Transfer successful.");

                        // Send email notification
                        SendEmailNotification(amount, sourceAccountNumber, destinationAccountNumber, transactionId, sourceEmail, destinationEmail);

                        // Generate receipt
                        var transactionDetails = GetTransactionDetails(transactionId);
                        GenerateTextReceipt(transactionDetails);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction if any error occurs
                        transaction.Rollback();
                        MessageBox.Show("Transfer failed: " + ex.Message);
                    }
                }
            }
        }

        private void SendEmailNotification(decimal amount, string sourceAccountNumber, string destinationAccountNumber, int transactionId, string sourceEmail, string destinationEmail)
        {
            // Get the details of the transaction
            var transactionDetails = GetTransactionDetails(transactionId);

            // Create the HTML email content
            string htmlContent = $@"
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; }}
        table {{ width: 100%; border-collapse: collapse; }}
        th, td {{ border: 1px solid #ddd; padding: 8px; }}
        th {{ background-color: #f2f2f2; }}
        h2 {{ color: #333; }}
    </style>
</head>
<body>
    <h2>Transaction Notification</h2>
    <p>Hello,</p>
    <p>A transfer has been successfully processed. Below are the details of the transaction:</p>
    <table>
        <tr>
            <th>Transaction ID</th>
            <td>{transactionId}</td>
        </tr>
        <tr>
            <th>Amount</th>
            <td>{amount:C}</td>
        </tr>
        <tr>
            <th>Source Account Number</th>
            <td>{sourceAccountNumber}</td>
        </tr>
        <tr>
            <th>Destination Account Number</th>
            <td>{destinationAccountNumber}</td>
        </tr>
        <tr>
            <th>Transaction Date</th>
            <td>{DateTime.Now.ToString("f")}</td>
        </tr>
        <tr>
            <th>Details</th>
            <td>{transactionDetails}</td>
        </tr>
    </table>
    <p>Thank you for banking with us.</p>
    <p>Best regards,<br>Your Bank</p>
</body>
</html>";

            // Configure Mailjet client
            var client = new MailjetClient("5b7bd7049212278211eb78f051291f47", "4ddc31eada863ee14fd9e4fe391c99e2");

            // Send email to source account holder
            var sourceEmailRequest = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Transfer Notification")
            .Property(Send.HtmlPart, htmlContent)
            .Property(Send.Recipients, new JArray
            {
        new JObject
        {
            { "Email", sourceEmail }
        }
            });

            var sourceEmailResponse = client.PostAsync(sourceEmailRequest).Result;
            if (!sourceEmailResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Failed to send email notification to source account holder.");
            }

            // Send email to destination account holder
            var destinationEmailRequest = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "kuateabdel.yaniv@ictuniversity.edu.cm")
            .Property(Send.FromName, "Krypton Bank")
            .Property(Send.Subject, "Transfer Notification")
            .Property(Send.HtmlPart, htmlContent)
            .Property(Send.Recipients, new JArray
            {
        new JObject
        {
            { "Email", destinationEmail }
        }
            });

            var destinationEmailResponse = client.PostAsync(destinationEmailRequest).Result;
            if (!destinationEmailResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("Failed to send email notification to destination account holder.");
            }
        }

        public void GenerateTextReceipt(TransactionDetails details)
        {
            if (details == null) return;

            // Generate a receipt as a string
            string receiptContent = $@"
    ----------------------------------------
    Krypton Bank - Transaction Receipt
    ----------------------------------------
    Transaction ID: {details.TransactionId}
    Account ID: {details.AccountId}
    Account Number: {details.AccountNumber}
    Transaction Type: {details.TransactionType}
    Amount: {details.Amount}
    Transaction Date: {details.TransactionDate}
    
    ";

            if (details.TransactionType == "Transfer")
            {
                receiptContent += $@"
        Source Account ID: {details.SourceAccountId}
        Destination Account ID: {details.DestinationAccountId}
        ";
            }

            receiptContent += "----------------------------------------";

            // Use SaveFileDialog to let the user choose where to save the receipt
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                saveFileDialog.FileName = $"TransactionReceipt_{details.TransactionId}.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, receiptContent);
                    MessageBox.Show($"Receipt saved to {saveFileDialog.FileName}");
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }
        public TransactionDetails GetTransactionDetails(int transactionId)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                string query = @"
            SELECT t.TransactionID, t.AccountID, a.AccountNumber, t.TransactionType, t.Amount, t.TransactionDate, 
                   t.SourceAccountID, t.DestinationAccountID
            FROM Transactions t
            INNER JOIN Account a ON t.AccountID = a.account_id
            WHERE t.TransactionID = @TransactionID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionID", transactionId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TransactionDetails
                            {
                                TransactionId = reader.GetInt32(reader.GetOrdinal("TransactionID")),
                                AccountId = reader.GetInt32(reader.GetOrdinal("AccountID")),
                                AccountNumber = reader.GetString(reader.GetOrdinal("AccountNumber")),  // Retrieve AccountNumber
                                TransactionType = reader.GetString(reader.GetOrdinal("TransactionType")),
                                Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                                TransactionDate = reader.GetDateTime(reader.GetOrdinal("TransactionDate")),
                                SourceAccountId = reader.IsDBNull(reader.GetOrdinal("SourceAccountID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("SourceAccountID")),
                                DestinationAccountId = reader.IsDBNull(reader.GetOrdinal("DestinationAccountID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("DestinationAccountID"))
                            };
                        }
                    }
                }
            }
            return null;
        }

    }
    public class TransactionDetails
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? SourceAccountId { get; set; }
        public int? DestinationAccountId { get; set; }
    }

   
}
