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

namespace Ktypton_Bank
{
    public partial class transaction : Form
    {
        public transaction()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_transactionDate_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False"))
            {
                string query = "SELECT * FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    

        private void btn_add_Click(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-I86I3TI;Initial Catalog=bank;Integrated Security=True;Encrypt=False";

            // AccountID to search for
            int accountId = int.Parse(textbox_search.Text);

            // SQL query to fetch transaction details based on AccountID
            string query = "SELECT * FROM Transactions WHERE AccountID = @AccountID";

            // Use SqlConnection and SqlCommand to fetch data
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountID", accountId);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate text boxes with transaction details
                            textbottun_TID.Text = reader["TransactionID"].ToString();
                            textbox_transactionType.Text = reader["TransactionType"].ToString();
                            txtAmount.Text = reader["Amount"].ToString();
                            txtTransactionDate.Text = reader["TransactionDate"].ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("No transaction found for the given Account ID.");
                        }
                    }
                }
            }
        }
    }
}
