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
    public partial class addmedicine : Form
    {
        Class1 fn = new Class1();
        string query;
        public addmedicine()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");

        private void button2_Click(object sender, EventArgs e)
        {
           pharma fm = new pharma();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            txtname.Clear();
            txtnumber.Clear();
            txtprice.Clear();
            txtquantity.Clear();
            txtmegdate.ResetText();
            txtexpdate.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( txtname.Text !="" && txtnumber.Text!="" && txtprice.Text!=""&&txtquantity.Text!=""  )
            {
                OleDbCommand cmd;
                

                String medname = txtname.Text;
                String megdate = txtmegdate.Text;
               Int64 mednumber = Int64.Parse (txtnumber.Text);
                Int64 quantity = Int64.Parse(txtquantity.Text);
                Int64 price_ = Int64.Parse(txtprice.Text);
                String expdate = txtexpdate.Text;
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    cmd = new OleDbCommand("insert into medic_ (medname,mednumber,megdate,expdate,quantity,price_per_unit) values('" + medname + "','" + mednumber + "','" + megdate + "','" + expdate + "','" + quantity + "','" + price_ + "')", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Enter all the values!", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
