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
    public partial class information : Form
    {
        String user = "";

        public information()
        {
            InitializeComponent();
        }
        public string ID
        {
            get { return user.ToString(); }
        }
        public information(String username)
        {
                InitializeComponent();
            usernamelable.Text = username;
            user=username;
            
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard am = new dashboard();
            am.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            entry fm = new entry();
            fm.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            VIEW fm = new VIEW();
            fm.Show();
            this.Hide();
        }

        private void information_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            update fm = new update();
            fm.Show();
            this.Hide();

        }
    }
}
