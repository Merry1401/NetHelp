using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace NetHelp
{
    public partial class meniu : Form
    {
        int nr = 0;
        Graphics g;
        string s1 = "NetHelp";
        string s2 = "Digital Wellbeing";
        string s3 = "Avantajele si dezavantajele tehnologiei intr-o lume moderna";
       
        public meniu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            introducere f = new introducere();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            meniu2 f = new meniu2();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            calculatorscreen f = new calculatorscreen();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            slide2 f = new slide2();
            f.Show();
            this.Hide();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(56, 63, 250);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.SteelBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(56, 63, 250);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.SteelBlue;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(56, 63, 250);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.SteelBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(56, 63, 250);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.SteelBlue;
        }

        private void meniu_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g = this.CreateGraphics();

            nr++;
            if (nr % 4 == 1)
            {
                Font drawFont = new Font("Arial", 18);
                SolidBrush drawBrush = new SolidBrush(Color.Black);

                float x = 160.0F;
                float y = 200.0F;

                g.DrawString(s1, drawFont, drawBrush, x, y);
            }
            else if (nr % 4 == 2)
            {

                Font drawFont = new Font("Arial", 18, FontStyle.Underline);
                SolidBrush drawBrush = new SolidBrush(Color.SteelBlue);

                float x = 180.0F;
                float y = 250.0F;

                g.DrawString(s2, drawFont, drawBrush, x, y);
            }
            else if (nr % 4 == 3)
            {

                Font drawFont = new Font("Arial", 16, FontStyle.Italic);
                SolidBrush drawBrush = new SolidBrush(Color.CornflowerBlue);

                float x = 200.0F;
                float y = 300.0F;

                g.DrawString(s3, drawFont, drawBrush, x, y);



            }
        }
    }
}
