using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NetHelp
{
    public partial class slide : Form
    {
        PointF[] v2 = new PointF[100];
        Class1[] v = new Class1[100];
        int k = 0, i = 0, n, m;

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            g = this.CreateGraphics(); g.Clear(Color.White);

            String drawString = v[i % n].denumire.ToString();

            Font drawFont = new Font("Trebuchet MS", 13, FontStyle.Underline);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x = 679.0F;
            float y = 90.0F;

            g.DrawString(drawString, drawFont, drawBrush, x, y);

            Image newImage = Image.FromFile(v[i % n].poza.ToString());
            Bitmap bimage = new Bitmap(newImage);
            TextureBrush tb = new TextureBrush(bimage);
            g.FillPolygon(tb, v2);
        }


        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }

        Graphics g;
        public slide()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (StreamReader fin = new StreamReader("textslide.txt"))
            {
                while (!fin.EndOfStream)
                {
                    i++;
                    string s = fin.ReadLine();
                    string[] v = s.Split(' ');
                    v2[i] = new PointF(int.Parse(v[0].ToString()), int.Parse(v[1].ToString()));
                }
                fin.Close(); m = i;
            }

            using (StreamReader fin = new StreamReader("textdezavantaj.txt"))
            {
                while (!fin.EndOfStream)
                {

                    string linie = fin.ReadLine();
                    string[] v1 = linie.Split('/');
                    v[k] = new Class1();
                    v[k].denumire = v1[0].ToString();
                    v[k].poza = v1[1].ToString(); k++;

                }
                n = k;
                fin.Close();
            }
            k = 1; timer1.Start(); i = 0;
        }
    }
}
