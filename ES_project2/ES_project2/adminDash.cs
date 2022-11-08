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
    public partial class adminDash : Form
    {
        public adminDash()
        {
           
            InitializeComponent();
            Pstaff.Visible = false;
            PanAdmin.Visible = true;    
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");


        private void regi_tab_Click(object sender, EventArgs e)
        {
            line1.Left = regi_tab.Left;
            line1.Width = regi_tab.Width;
            Pstaff.Visible = false;
            PanAdmin.Visible = true;

            //SlideA.Visible = false;
        }

        private void log_tab_Click(object sender, EventArgs e)
        {
            line1.Left = log_tab.Left;
            line1.Width = log_tab.Width;
            PanAdmin.Visible = false;
            Pstaff.Visible = true;  

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
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from admin", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AdminShow.DataSource = dt;
            conn.Close();

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            String AdminID = Aid.Text;
            String NPass = Npass.Text;
            String CPass = cPass.Text;

            if(NPass == CPass)
            {
              
               
                String insert = "UPDATE admin SET pass='"+NPass+"' WHERE id='"+AdminID+"'";
                SqlCommand cmd = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Password is Set !");
                    conn.Close();
                }

                catch (SqlException se)
                {
                    MessageBox.Show("Try Again !" + se);
                }

            }
            else
            {
                MessageBox.Show("Check Passwords Again !");
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            // delete staff
            String id = Sid.Text;

          

            String insert = "DELETE FROM staff WHERE id = '"+id+"'";
            SqlCommand cmd = new SqlCommand(insert, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Member Has been removed!");
                conn.Close();
            }

            catch (SqlException se)
            {
                MessageBox.Show("Try Again!" + se);
            }

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           // SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");

            String id = Sid.Text;
            // chk staff
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM staff WHERE id = '"+id+"'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            StaffShow.DataSource = dt;
            conn.Close();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            //update staff

            String id = Sid.Text;
            String name = fname.Text;
            String Pass = pass.Text;
            String Email = mail.Text;
            String Address = adres.Text;


            String insert = "UPDATE staff SET fname = '"+name+"', Email = '"+Email+"' , Password = '"+Pass+"' , Address = '"+Address+"'  WHERE id = '"+id+"' ";
            SqlCommand cmd = new SqlCommand(insert, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Staff Member Has been removed!");
                conn.Close();
            }

            catch (SqlException se)
            {
                MessageBox.Show("Try Again!" + se);
            }

        }

        private void StaffShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
