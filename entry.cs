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
    public partial class entry : Form
    {
        Class1 fn = new Class1();
        string query;
        public entry()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");
     


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            information fm = new information(txtusername.Text);
            fm.Show();
            this.Hide();
        }
      
        private void txtmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtaddress.Text == "" && txtcnic.Text == "" && txtname.Text == ""  && txtmail.Text == "" && txtpassw.Text == "" && txtphone.Text == "" && txtrole.Text == "" && txtusername.Text == "") { MessageBox.Show("fill all the boxes ", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                OleDbCommand cmd;
                String role = txtrole.Text;
                String name = txtname.Text;
                String Dob_ = txtdob.Text;
                String cnic = txtcnic.Text;
                String address = txtaddress.Text;
                Int64 mobile = Int64.Parse(txtphone.Text);
                String email = txtmail.Text;
                String username = txtusername.Text;
                String pass = txtpassw.Text;
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    cmd = new OleDbCommand("insert into admin_ (userrole,name,CNIC,dob,mobile,address,email,username,password) values('" + role + "','" + name + "','" + cnic + "','" + Dob_ + "','" + mobile + "','" + address + "','" + email + "','" + username + "','" + pass + "')", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                }
                conn.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtcnic.Clear();
           
            txtmail.Clear();
            txtname.Clear();
            txtpassw.Clear();
            txtphone.Clear();
            txtusername.Clear();
            
        }

        private void entry_Load(object sender, EventArgs e)
        {

        }
    }
}
