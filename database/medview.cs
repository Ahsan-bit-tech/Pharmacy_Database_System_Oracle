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
    public partial class medview : Form
    {
        Class1 fn = new Class1();
        string query;
        string currentuser = "";
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");

        public medview()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pharma fm = new pharma();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              conn.Open();
                OleDbDataAdapter data = new OleDbDataAdapter("Select * from medic_", conn);
                DataTable dt = new DataTable();
                data.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();

            
        }

        private void medview_Load(object sender, EventArgs e)
        {
            query = "select * from medic_";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtb_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic_ where medname like '" + txtb.Text + "%'";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        string userName;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
                try
                {
                    userName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
                catch { }

            
        }

        private void delete_Click(object sender, EventArgs e)
        {
             query= "delete  from  medic_ where medid like '" + txtid.Text + "%'";
            fn.setdata(query, "deleted successfully");
        
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            query = "select * from medic_ where medid like '" + txtid.Text + "%'";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
