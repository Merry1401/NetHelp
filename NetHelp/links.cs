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
using System.Net;
using System.Diagnostics;

namespace NetHelp
{
    public partial class links : Form
    {
        public links()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            Process.Start(new ProcessStartInfo("https://wellbeing.google") { UseShellExecute = true });

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.techtarget.com/whatis/definition/digital-wellbeing") { UseShellExecute = true });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.berkeleywellbeing.com/digital-well-being.html") { UseShellExecute = true });
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.psychologytoday.com/us/blog/click-here-happiness/202102/what-is-digital-well-being") { UseShellExecute = true });
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            calculatorscreen f = new calculatorscreen();
            f.Show();
        }
    }
}
