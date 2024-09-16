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
    public partial class Customervw : KryptonForm
    {
        public Customervw()
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

        public void SetCustomerName(string name)
        {
            lblCustomerName.Text = $"Welcome, {name}!";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            loadform(new Customerdashboard());
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            loadform(new settingsform());

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            loadform(new aboutusform());
        }
    }
}
