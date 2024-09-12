using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lmitp
{
    public partial class aboutusform : Form
    {
        public aboutusform()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            aboutusform aboutusform = new aboutusform();
            aboutusform.Show();
        }

        private void aboutusform_Load(object sender, EventArgs e)
        {

        }
    }
}
