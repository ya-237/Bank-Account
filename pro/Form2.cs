using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ktypton_Bank
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            form3 form3 = new form3();
            form3.Show();
        }

        private void btnemp_Click(object sender, EventArgs e)
        {
            loadform(new customer());
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            loadform(new account());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.MaximizeBox= true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new transaction());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void AddAdmin_Click(object sender, EventArgs e)
        {
            walletform walletform = new walletform();
            walletform.ShowDialog();

        }
    }
}
