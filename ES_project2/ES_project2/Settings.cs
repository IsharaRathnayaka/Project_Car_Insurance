using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ES_project2
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Project_Insurance_C-\Car_Insurance_DB.mdf;Integrated Security=True;Connect Timeout=30");


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            String id = Login.main_id; // who use the system and new setting will save with his id
            String darkmode;
            String autoupdate;
            String startwithos;
            String passsave;

            string email = mail.Text;

            if (darkM.Checked)
            {
                darkmode = "Enabled";
            }
            else
            {
                darkmode = "Disabled";
            }

            if (update.Checked)
            {
                autoupdate = "Enabled";
            }

            else
            {
                autoupdate = "Disabled";
            }

            if (os.Checked)
            {
                startwithos = "Enabled";
            }
            else
            {
                startwithos = "Disabled";
            }
            if (pws.Checked)
            {
                passsave = "Enabled";
            }
            else
            {
                passsave = "Disabled";
            }
            
            String insert = "INSERT INTO settings VALUES ('" + id + "' ,'" + darkmode + "', '" + autoupdate + "', '" + startwithos + "' , '" + passsave + "' , '"+email+"')";
            SqlCommand cmd = new SqlCommand(insert, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("New settings has been saved!");

                conn.Close();
            }

            catch (SqlException)
            {
                MessageBox.Show("setting change failed! try restart");
            }



        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/KavinduLakmal2000/Project_Insurance_C-");
            Process.Start(sInfo);
        }
    }
}
