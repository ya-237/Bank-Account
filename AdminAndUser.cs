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
using Ktypton_Bank;

namespace Ktypton_Bank
{
    public partial class AdminAndUser : KryptonForm
    {
        public AdminAndUser()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin();
            this.Hide();
            userLogin.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Login_Admin login_Admin = new Login_Admin();
            this.Hide();
            login_Admin.ShowDialog();
        }
    }
}
