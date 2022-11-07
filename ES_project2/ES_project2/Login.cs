using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;



namespace ES_project2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            box_log_pass.isPassword = true;         
        }

        
        private void log_tab_Click(object sender, EventArgs e)
        {
            line1.Left = regi_tab.Left;
            line1.Width = regi_tab.Width;

            SlideA.Visible = false;
            //SlideB.Visible = false;
        }

        private void log_tab_Click_1(object sender, EventArgs e)
        {
            line1.Left = log_tab.Left;
            line1.Width = log_tab.Width;

            SlideA.Visible = true;
            //SlideB.Visible = false;
        }

        private void bt_login_Click(object sender, EventArgs e)
        {
            String userid = box_id.Text;
            String userpass = box_log_pass.Text;

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LUCKY\source\repos\KavinduLakmal2000\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");


            String res = userid.Substring(0, 1);
  
            if (res == "1")
            {

                /////////////////////////////////////////////for admin login ///////////////////////////////////////////
                MessageBox.Show("this is admin");

                String chkquery = "select * from admin where id = '" + box_id.Text.Trim() + "' and pass = '" + box_log_pass.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(chkquery, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login done !");
                }
                else
                {
                    MessageBox.Show("check your password and User name and try again !");
                }
               
            }
            else if (res == "2")
            {
                ///////////////////////////////////////////////for staf login ///////////////////////////////////////////////////
                MessageBox.Show("This is staff");
            }

            else
            {
                MessageBox.Show("Check your ID and try again !");
            }


            // after enter id and pass then press login
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkbox_OnChange(object sender, EventArgs e)
        {
            if (chkbox.Checked)
            {
                box_log_pass.isPassword = false;
            }
            else
            {
                box_log_pass.isPassword = true;
            }
        }

        private void box_id_OnValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
