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
    public partial class VIEW : Form
    {
        Class1 fn = new Class1();
        string query;
        string currentuser = ""; 
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");
        public VIEW()
        {
            InitializeComponent();
        }
        public string ID
        {
            set { currentuser = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            information fm = new information();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbDataAdapter data = new OleDbDataAdapter("Select * from admin_", conn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            update fm = new update();
            fm.Show();
            this.Hide();
        }
        private void VIEW_Load(object sender, EventArgs e)
        {
            query = "select * from admin_";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select * from admin_ where username like '" + txtb.Text + "%'";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Delete confirmeation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentuser != userName)
                {
                    query = "delete from admin_ where  username = '" + userName + "'";
                    fn.setdata(query, "User Record Deleted");
                    VIEW_Load(this, null);
                }
                else
                {
                    MessageBox.Show("you are trying to delete \n your own profile.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

       
        string userName;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            update fm = new update();
            fm.Show();
            this.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            query=  "delete  from admin_ where adminid like '" + txtid.Text + "%'";
            fn.setdata(query, "deleted successfully");
            VIEW_Load(this, null);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
             query = "select * from admin_ where adminid like '" + txtid.Text + "%'";
            DataSet ds = fn.getdata(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
