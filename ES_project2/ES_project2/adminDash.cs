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

namespace ES_project2
{
    public partial class adminDash : Form
    {
        public adminDash()
        {
            InitializeComponent();
            PanAdmin.Visible = true;    
        }

        private void regi_tab_Click(object sender, EventArgs e)
        {
            line1.Left = regi_tab.Left;
            line1.Width = regi_tab.Width;
            PanAdmin.Visible = true;

            //SlideA.Visible = false;
        }

        private void log_tab_Click(object sender, EventArgs e)
        {
            line1.Left = log_tab.Left;
            line1.Width = log_tab.Width;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            line1.Left = del.Left;
            line1.Width = log_tab.Width;
        }

        private void chkData_Click(object sender, EventArgs e)
        {
            line1.Left = regi.Left;
            line1.Width = log_tab.Width;
            // chkData
        }

        private void chkData_Click_1(object sender, EventArgs e)
        {
            line1.Left = chkData.Left;
            line1.Width = log_tab.Width;
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from admin", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AdminShow.DataSource = dt;
            conn.Close();

        }
    }
}
