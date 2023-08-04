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
    public partial class update : Form
    {
        Class1 fn = new Class1();
        string query;
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");
        public update()
        {
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtusername.Text;
            string email = txtmail.Text;
            string pass = txtpass.Text;
            Int64 mob = Int64.Parse(txtphone.Text);
            Int64 id = Int64.Parse(txtid.Text);
            query = "update admin_ set  email = '" + email + "',username ='" + name + "',password='" + pass + "',mobile='" + mob + "'where adminid ='" + id + "'";
            fn.setdata(query, "Profile updated successfully");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            information fm = new information();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtid.Clear();
            txtmail.Clear();
            txtpass.Clear();
            txtphone.Clear();
            txtusername.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                query = "select * from admin_ where adminid = '" + txtid.Text + "'";
                DataSet ds = fn.getdata(query);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No user   exist", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtname.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtmail.Text = ds.Tables[0].Rows[0][7].ToString();
                    txtpass.Text= ds.Tables[0].Rows[0][9].ToString();
                   txtphone.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtusername.Text = ds.Tables[0].Rows[0][8].ToString();
                  
                    MessageBox.Show("    Medicine  user  exist", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
