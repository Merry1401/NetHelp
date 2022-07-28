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
    public partial class calculatorscreen : Form
    {
        string s = "Stai prea mult in fata unui ecran.";
        string s1 = "Stai destul de mult in fata unui ecran.";
        string s2 = "Bravo, nu stai prea mult in fata unui ecran.";
        float x = 494.0F;
        Graphics g;
        float y = 140.0F;
        Font drawFont = new Font("Arial", 11, FontStyle.Underline);
        int val;
        int val1;
        public calculatorscreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
           if(int.TryParse(textBox1.Text, out val) && int.TryParse(textBox2.Text, out val1))
            {
                if (val1 < 15 && val1 > 10)
                {
                    if (val >= 5 && val <= 7)
                    {
                        button1.BackColor = Color.Orange;
                        panel1.BackColor = Color.FromArgb(243, 86, 17);
                        panel2.BackColor = Color.FromArgb(253, 153, 75);
                        SolidBrush b = new SolidBrush(Color.Orange);
                        g.DrawString(s1, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();

                    }
                    if (val > 7)
                    {
                        button1.BackColor = Color.Red;
                        panel1.BackColor = Color.FromArgb(241, 18, 18);
                        panel2.BackColor = Color.FromArgb(247, 52, 101);
                        SolidBrush b = new SolidBrush(Color.Red);
                        g.DrawString(s, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();
                    }
                    if (val < 5)
                    {
                        button1.BackColor = Color.FromArgb(14, 229, 35);
                        panel1.BackColor = Color.FromArgb(2, 220, 78);
                        panel2.BackColor = Color.FromArgb(47, 244, 165);
                        SolidBrush b = new SolidBrush(Color.Green);
                        g.DrawString(s2, drawFont, b, x, y);
                        label9.Hide();
                        label10.Hide();
                    }
                }
                if(val1 > 15 || val1 == 15)
                {
                    if (val >= 7 && val <= 9)
                    {
                        button1.BackColor = Color.Orange;
                        panel1.BackColor = Color.FromArgb(243, 86, 17);
                        panel2.BackColor = Color.FromArgb(253, 153, 75);
                        SolidBrush b = new SolidBrush(Color.Orange);
                        g.DrawString(s1, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();
                    }
                    if (val > 9)
                    {
                        button1.BackColor = Color.Red;
                        panel1.BackColor = Color.FromArgb(241, 18, 18);
                        panel2.BackColor = Color.FromArgb(247, 52, 101);
                        SolidBrush b = new SolidBrush(Color.Red);
                        g.DrawString(s, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();
                    }
                    if (val < 7)
                    {
                        button1.BackColor = Color.FromArgb(14, 229, 35);
                        panel1.BackColor = Color.FromArgb(2, 220, 78);
                        panel2.BackColor = Color.FromArgb(47, 244, 165);
                        SolidBrush b = new SolidBrush(Color.Green);
                        g.DrawString(s2, drawFont, b, x, y);
                        label9.Hide();
                        label10.Hide();
                    }
                }
                if (val1 <= 10)
                {
                    if (val >= 3 && val <= 4)
                    {
                        button1.BackColor = Color.Orange;
                        panel1.BackColor = Color.FromArgb(243, 86, 17);
                        panel2.BackColor = Color.FromArgb(253, 153, 75);
                        SolidBrush b = new SolidBrush(Color.Orange);
                        g.DrawString(s1, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();
                    }
                    if (val > 4)
                    {
                        button1.BackColor = Color.Red;
                        panel1.BackColor = Color.FromArgb(241, 18, 18);
                        panel2.BackColor = Color.FromArgb(247, 52, 101);
                        SolidBrush b = new SolidBrush(Color.Red);
                        g.DrawString(s, drawFont, b, x, y);
                        label9.Show();
                        label10.Show();
                    }
                    if (val < 3)
                    {
                        button1.BackColor = Color.FromArgb(14, 229, 35);
                        panel1.BackColor = Color.FromArgb(2, 220, 78);
                        panel2.BackColor = Color.FromArgb(47, 244, 165);
                        SolidBrush b = new SolidBrush(Color.Green);
                        g.DrawString(s2, drawFont, b, x, y);
                        label9.Hide();
                        label10.Hide();
                    }
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu2 f = new meniu2();
            f.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            avantaje f = new avantaje();
            f.Show();
        }

        private void calculatorscreen_Load(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            links f = new links();
            f.Show();
        }
    }
}
