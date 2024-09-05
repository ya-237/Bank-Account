using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace lmitp
{
    public partial class dashboardform : KryptonForm
    {
        public dashboardform()
        {
            InitializeComponent();
        }
        private void btnclose_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            accountform accountform = new accountform();
            accountform.Show();
        }
        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            walletform walletform = new walletform();
            walletform.Show();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            customerformcs customerformcs = new customerformcs();
            customerformcs.Show();
        }

        private void kryptonButton3_Click_1(object sender, EventArgs e)
        {
            accountform accountform = new accountform();
            accountform.Show();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            transactionform transactionform = new transactionform();
            transactionform.Show();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            Loan loan = new Loan();
            loan.Show();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            statistics statistics = new statistics();
            statistics.Show();
        }
    }
}
