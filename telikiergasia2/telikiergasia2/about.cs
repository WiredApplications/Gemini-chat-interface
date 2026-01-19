using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace telikiergasia2
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(916, 530);
            this.MinimumSize = new System.Drawing.Size(916, 530);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
