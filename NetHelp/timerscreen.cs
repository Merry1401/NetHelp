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
    public partial class timerscreen : Form
    {
        int time = 15;

        public timerscreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label2.Text = time.ToString();
            timer1.Start();
            panel11.BackColor = Color.DarkTurquoise;
            panel10.BackColor = Color.OrangeRed;
            panel9.BackColor = Color.Chartreuse;
            panel8.BackColor = Color.Red;
            panel7.BackColor = Color.Peru;
            panel6.BackColor = Color.Gold;
            panel12.BackColor = Color.DarkTurquoise;
            panel13.BackColor = Color.Chartreuse;
            panel12.Show();
            panel13.Show();
            panel11.Show();
            panel10.Show();
            panel9.Show();
            panel8.Show();
            panel7.Show();
            panel6.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if(time == 0)
            {
                panel12.Hide();
                panel13.Hide();
                panel11.Hide();
                panel10.Hide();
                panel9.Hide();
                panel8.Hide();
                panel7.Hide();
                panel6.Hide();
                timer1.Stop();
                MessageBox.Show("Ai stat destul pe telefon astazi.", "Timer Screentime", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            label2.Text = time.ToString();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Crimson;
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            panel10.BackColor = Color.Crimson;
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            panel8.BackColor = Color.Crimson;
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            panel9.BackColor = Color.Crimson;
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Crimson;
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            panel6.BackColor = Color.Crimson;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out time))
            {
                label2.Text = time.ToString();
            }
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            panel12.BackColor = Color.Crimson;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Crimson;
        }
    }
}
