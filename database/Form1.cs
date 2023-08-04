using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace database
{
    public partial class Form1 : Form
    {
        Class1 fn =new Class1();
        string query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");
        private void button2_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from admin_";
             ds = fn.getdata(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtuser.Text == "123" && txtpass.Text == "123")
                {
                    information am = new information();
                    am.Show();
                    this.Hide();
                }
            }
            else
            {
                query = "select * from  admin_ where username ='" + txtuser.Text + "'and password='" + txtpass.Text + "'";
                ds = fn.getdata(query);
                if(ds.Tables[0].Rows.Count!=0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if (role == "Administrator")
                    {
                        information am = new information(txtuser.Text);
                        am.Show();
                        this.Hide();
                    }
                    if(role == "Pharmacist")
                    {
                        pharma am = new pharma  ();
                        am.Show();
                        this.Hide();
                    }
                   
                 }
                else
                {
                    MessageBox.Show("incorrect password or useername", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
