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
    public partial class Form1 : Form
    {
        public Form2()
        {
            InitializeComponent();
            box_log_pass.isPassword = true;         
        }

        
