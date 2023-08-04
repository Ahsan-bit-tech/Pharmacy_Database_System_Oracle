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
    public partial class sell : Form
    {
        Class1 fn = new Class1();
        string query;
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=XE;User ID=PROJECT;Password=PROJECT;Unicode=True");
        DataSet ds;
        public sell()
        {
            InitializeComponent();
        }

        private void sell_Load(object sender, EventArgs e)
        {
            listtxt.Items.Clear();
            query = "select medname from medic_ where  quantity > '0'";
            ds = fn.getdata(query);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                listtxt.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void backbut_Click(object sender, EventArgs e)
        {
           pharma fm = new pharma();
            fm.Show();
            this.Hide();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            listtxt.Items.Clear();
            query="select medname from medic_ where medname like'"+txtsearch.Text+"%' and quantity > '0'";
            ds = fn.getdata(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listtxt.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtname.Clear();

            String name = listtxt.GetItemText(listtxt.SelectedItem);
            txtname.Text = name;
            query = "select medid ,expdate,price_per_unit from medic_ where medname= '" + name + "'";
            ds = fn.getdata(query);
            txtid.Text = ds.Tables[0].Rows[0][0].ToString();
            txtexpdate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtprice.Text = ds.Tables[0].Rows[0][2].ToString();
        }

        private void txtquant_TextChanged(object sender, EventArgs e)
        {
            if (txtquant.Text != "")
            {
                Int64 price = Int64.Parse(txtprice.Text);
                Int64 quat = Int64.Parse(txtquant.Text);
                Int64 total = price * quat;
                txttotal.Text = total.ToString();
            }
            else
            {
                txttotal.Clear();
            }
        }
            protected int n, totalamount=0;
        protected Int64 quant, newquantity ;

        int valueM;
        String valueId;
        protected Int64 quantww;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                valueM = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                valueId =dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                quantww = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            }
            catch(Exception)
            { }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();
            txtid.Clear();
            txtname.Clear();
            txtprice.Clear();
            txtquant.Clear();
            txtsearch.Clear();
            txttotal.Clear();
            txtexpdate.ResetText();
            OleDbDataAdapter data = new OleDbDataAdapter("Select * from admin_", conn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
           
            e.Graphics.DrawString("Customer name : " + txtcus.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 330));
            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 360));
            e.Graphics.DrawString("Purchase Time : " + DateTime.Now.ToLongTimeString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 390));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 420));
            e.Graphics.DrawString("Item Name ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 450));
            e.Graphics.DrawString("Quantity ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(260, 450));
            e.Graphics.DrawString("Expire Date ", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, 450));
            e.Graphics.DrawString("Price", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(700, 450));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, 470));


            if (dataGridView1.Rows.Count > 0)
            {
                int gap = 500;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(30, gap));
                        gap += 30;
                    }
                    catch
                    {

                    }
                }
            }

            if (dataGridView1.Rows.Count > 0)
            {
                int gap = 500;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(260, gap));
                        gap += 30;
                    }
                    catch
                    {

                    }
                }

            }

            if (dataGridView1.Rows.Count > 0)
            {
                int gap = 500;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(450, gap));
                        gap += 30;
                    }
                    catch
                    {

                    }
                }
            }
            if (dataGridView1.Rows.Count > 0)
            {
                int gap = 500;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        e.Graphics.DrawString(dataGridView1.Rows[i].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(700, gap));
                        gap += 30;
                    }
                    catch
                    {

                    }
                }
            }

            e.Graphics.DrawString("-------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 880));
            int subCost = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                subCost = subCost + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            e.Graphics.DrawString("Sub Total:" + subCost.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 860));

           
           
            int totalCost = 0, dicount;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalCost = totalCost + Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            e.Graphics.DrawString("Total Amount:" + totalCost.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 900));
            dicount = (totalCost / 5);
            totalCost = totalCost - dicount;
           
            e.Graphics.DrawString("After 20 % dicount =" + totalCost.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 960));
            e.Graphics.DrawString("-------------------------------------------", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 1000));
            e.Graphics.DrawString("Amount Paid:" +totalCost.ToString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 1020));
           // e.Graphics.DrawString("Change:" + CHANGEtextBox.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(530, 1050));

        
    }

        private void btpurchase_Click(object sender, EventArgs e)
        {
            if (txtcus.Text == "" && txtid.Text == "" && txtname.Text == "" && txtprice.Text == "" && txtquant.Text == "" && txtcus.Text == "") { MessageBox.Show("fill all the boxes ", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }

        }

        private void btremove_Click(object sender, EventArgs e)
        {
            if (valueId != null)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                }
                catch
                {

                }
                finally
                {
                    query="select quantity from medic_ where medid ='"+valueId+"'";
                    ds = fn.getdata(query);
                    quantww = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                    newquantity = quantww + quant;

                    query="update medic_ set quantity ='"+newquantity+"'where medid='"+valueId+"'";
                    fn.setdata(query, "Medicine Removed");
                    totalamount = totalamount - valueM;
                    purchlabel.Text = "Rs. " + totalamount.ToString();

                }
                sell_Load(this, null);

            }
        }
        private void btadd_Click(object sender, EventArgs e)
        {
            if( txtid.Text=="" && txtname.Text=="" && txtprice.Text =="" &&txtquant.Text=="")
            { MessageBox.Show("fill all the boxes ", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            if(txtid.Text!="")
            {
                query = "select quantity  from medic_ where medid='" + txtid.Text + "'";
                ds = fn.getdata(query);

                quant = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                newquantity = quant - Int64.Parse(txtquant.Text);
                if(newquantity >= 0)
                {
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = txtid.Text;
                    dataGridView1.Rows[n].Cells[1].Value = txtname.Text;
                    dataGridView1.Rows[n].Cells[2].Value = txtexpdate.Text;
                    dataGridView1.Rows[n].Cells[3].Value = txtprice.Text;
                    dataGridView1.Rows[n].Cells[4].Value = txtquant.Text;
                    dataGridView1.Rows[n].Cells[5].Value = txttotal.Text;

                    totalamount = totalamount + int.Parse(txttotal.Text);
                    purchlabel.Text = "Rs. " + totalamount.ToString();

                    query = "update medic_ set quantity='" + newquantity + "'where medid= '" + txtid.Text + "'";
                    fn.setdata(query,"Medicine Added");
                }
                else
                {
                    MessageBox.Show("Medicine is out of stock  only"+quant+"left! ","Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtid.Clear();
                txtname.Clear();
                txtprice.Clear();
                txtquant.Clear();
                txtsearch.Clear();
                txttotal.Clear();
                sell_Load(this, null);
            }
            else
            {
                MessageBox.Show("Select the medicine first .", "information!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
