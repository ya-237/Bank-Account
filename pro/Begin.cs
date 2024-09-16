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
namespace Ktypton_Bank
{
    public partial class Begin : KryptonForm
    {
        public Begin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            label1.BackColor = Color.Transparent;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            AdminAndUser adminAndUser = new AdminAndUser();
            adminAndUser.ShowDialog();
     
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.ShowDialog();
        }
    }
}
