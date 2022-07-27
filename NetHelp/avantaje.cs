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
    public partial class avantaje : Form
    {
        public avantaje()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                panel2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
               
            }
            else
            {
                panel2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                panel3.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
            }
            else
            {
                panel3.Hide();
                label7.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
            }
        }

        private void slideshow_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            calculatorscreen f = new calculatorscreen();
            f.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            slide f = new slide();
            f.Show();
            this.Hide();
        }
    }
}
