using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class claim : Form
    {
        public claim()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");

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
            String id = staffDash.send_id;  
            String reason = "";
            String ispub = "";
            String Date = date.Value.ToString();
            String mileage = mile.Text; 
            String where = wh.Text;
            String d_age = dAge.Text;
            string people = how_many.Text;
            //.........................................
            if (r1.Checked)
            {
                reason = "Reckless Driving";
            }

            else if (r2.Checked)
            {
                reason = "Natural Disaster";
            }

            else if (r3.Checked)
            {
                reason = "By other driver";
            }

            else if (r4.Checked)
            {
                reason = "Thief";
            }

            else if (r5.Checked)
            {
                reason = "Any Other";
            }

            else
            {
                MessageBox.Show("please Check reason");
            }
            //..........................................
            if (y.Checked)
            {
                ispub = "yes";
            }

            else if (n.Checked)
            {
                ispub = "no";
            }

            else
            {
                MessageBox.Show("Please check is it public or not");
            }
            //...........................................
            // MessageBox.Show(""+reason);

            //.............................................................delete last report.............
            String insert = "DELETE FROM claim WHERE cid = '"+id+"'";
            SqlCommand cmd = new SqlCommand(insert, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            catch(Exception)
            {
                MessageBox.Show("old report delete failed! try again!");
            }


            //..........................................................insert new report..............

            String insert2 = "INSERT INTO claim VALUES('"+id+"' , '"+reason+"' , '"+ispub+"' , '"+Date+"' , '"+mileage+"' , '"+where+"' , '"+d_age+"' , '"+people+"')";
            SqlCommand cmd2 = new SqlCommand(insert2, conn);

            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Report Saved!");
              
                conn.Close();
                this.Hide();


            }

            catch (SqlException)
            {
                MessageBox.Show("Data can not be saved & try again!");
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report printing started!");
        }
    }
}
