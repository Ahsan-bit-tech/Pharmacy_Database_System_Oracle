using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class dashboard : Form
    { 
        Class1 fn = new Class1();
        string query;
        DataSet ds;

        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            information fm = new information();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            query = "select count(userrole) from admin_ where userrole = 'Administrator'";
            ds = fn.getdata(query);
            setlabel(ds,adminlable);
        }

        private void setlabel(DataSet ds ,Label lbl)
        {
            if(ds.Tables[0].Rows.Count!=0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            query = "select count(userrole) from admin_ where  userrole = 'Pharmacist'";
            ds = fn.getdata(query);
            setlabel(ds, pahrmalable);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            query = "select count(medname) from medic_ ";
            ds = fn.getdata(query);
            setlabel(ds,customerlable);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
