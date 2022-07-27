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
    public partial class schedule : Form
    {
        
        public schedule()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value == dateTimePicker2.Value)
            {
                button1.BackColor = Color.FromArgb(67, 115, 251);
                panel1.BackColor = Color.FromArgb(79, 48, 238);
                panel2.BackColor = Color.FromArgb(154, 98, 255);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.BackColor = Color.FromArgb(84, 78, 255);
                this.BackColor = Color.FromArgb(31, 29, 87);
            }
            else if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                MessageBox.Show("Inca nu este ora la care se porneste Dark Mode.");
                button1.BackColor = Color.MediumTurquoise;
                panel1.BackColor = Color.Turquoise;
                panel2.BackColor = Color.Aquamarine;
                label1.ForeColor = Color.Gray;
                label2.ForeColor = Color.Black;
                label3.BackColor = Color.MediumAquamarine;
                this.BackColor = Color.White;
            }
            else
            {
                button1.BackColor = Color.FromArgb(67, 115, 251);
                panel1.BackColor = Color.FromArgb(79, 48, 238);
                panel2.BackColor = Color.FromArgb(154, 98, 255);
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.BackColor = Color.FromArgb(84, 78, 255);
                this.BackColor = Color.FromArgb(31, 29, 87);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu2 f = new meniu2();
            f.Show();
        }
    }
}
