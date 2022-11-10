using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES_project2
{
    public partial class claim : Form
    {
        public claim()
        {
            InitializeComponent();
        }

        private void claim_Load(object sender, EventArgs e)
        {
            lbl_id.Text = staffDash.send_id;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            String reason = "";
            String Date = date.Value.ToString();

            if (r1.Checked)
            {
                reason = "Reckless Driving";
            }

            if (r2.Checked)
            {
                reason = "Natural Disaster";
            }

            if (r3.Checked)
            {
                reason = "By other driver";
            }

            if (r4.Checked)
            {
                reason = "High Speed";
            }

            if (r5.Checked)
            {
                reason = "Any Other";
            }

           // MessageBox.Show(""+reason);
        }

        

    }
}
