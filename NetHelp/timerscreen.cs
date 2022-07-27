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
        int time = 0;

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
            timer1.Start();
            panel11.BackColor = Color.DarkTurquoise;
            panel10.BackColor = Color.OrangeRed;
            panel9.BackColor = Color.Chartreuse;
            panel8.BackColor = Color.Red;
            panel7.BackColor = Color.Peru;
            panel6.BackColor = Color.Gold;
            panel11.Show();
            panel10.Show();
            panel9.Show();
            panel8.Show();
            panel7.Show();
            panel6.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if(time == 30)
            {
                MessageBox.Show("Ai stat destul pe telefon astazi.");
                panel11.Hide();
                panel10.Hide();
                panel9.Hide();
                panel8.Hide();
                panel7.Hide();
                panel6.Hide();
                timer1.Stop();
            }
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
    }
}
