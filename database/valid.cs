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
    public partial class valid : Form
    {
        Class1 fn = new Class1();
        string query;
        string currentuser = "";
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");

        public valid()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtcheck.SelectedIndex == 0)
            {
                query = "select * from medic_ ";
                DataSet ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
              

            }
            else if(txtcheck.SelectedIndex == 1)
            {
                query = "select * from medic_ where expdate <= TRUNC(SYSDATE)";
                DataSet ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (txtcheck.SelectedIndex == 2)
            {
                query = "select * bfrom medic_ where expdate >= TRUNC(SYSDATE)";
                DataSet ds = fn.getdata(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
