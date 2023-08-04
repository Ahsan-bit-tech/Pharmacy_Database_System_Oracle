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
    public partial class updatemed : Form
    {
        Class1 fn = new Class1();
        DataSet ds;
        string query;
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");

        public updatemed()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pharma fm = new pharma();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtexp.ResetText();
            txtid.Clear();
            txtmsg.ResetText();
            txtname.Clear();
            txtprice.Clear();
            txtquant.Clear();
            if(txtadd.Text!="0")
            {
                txtadd.Text = "0";
            }
            else
            {
                txtadd.Text = "0";
            }
        }
        Int64 total;
        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from  medic_ where medid='" + txtid.Text + "'";
            ds = fn.getdata(query);
            if (ds.Tables[0].Rows.Count != 0)
            {
                string name = txtname.Text;
                string exp = txtexp.Text;
                string msg = txtmsg.Text;
                Int64 quant = Int64.Parse(txtquant.Text);
                Int64 price = Int64.Parse(txtprice.Text);
                Int64 id = Int64.Parse(txtid.Text);
                Int64 add_ = Int64.Parse(txtadd.Text);
                total = quant + add_;
                query = "update medic_ set  medname= '" + name + "',expdate='" + exp + "',megdate='" + msg + "',quantity='" + total + "',price_per_unit='" + price + "'where medid ='" + id + "'";
                fn.setdata(query, "Profile updated successfully");
            }
            else
            { MessageBox.Show("user not exits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void updatemed_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                query = "select * from medic_ where medid = '" + txtid.Text + "'";
                DataSet ds = fn.getdata(query);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No Medicine  with ID " + txtid.Text + " exist", "information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtname.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtprice.Text = ds.Tables[0].Rows[0][6].ToString();
                    txtquant.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtmsg.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtexp.Text = ds.Tables[0].Rows[0][4].ToString();
                    MessageBox.Show("    Medicine  with ID " + txtid.Text + " exist", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
