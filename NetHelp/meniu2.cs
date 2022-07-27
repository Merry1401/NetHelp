using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetHelp
{
    public partial class meniu2 : Form
    {
        public meniu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerscreen f = new timerscreen();
            this.Close();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            schedule f = new schedule();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            survey f = new survey();
            f.Show();
        }
    }
}
