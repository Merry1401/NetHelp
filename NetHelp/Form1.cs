using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace NetHelp
{
    public partial class Form1 : Form
    {
        int scor = 0;
        int val = 0, val1 = 0;
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            c.Open();
            string select = "select username from logare";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataAdapter da = new SqlDataAdapter(select, c);
            DataSet ds = new DataSet();
            da.Fill(ds);
            comboBox1.DisplayMember = "username";
            comboBox1.ValueMember = "username";
            comboBox1.DataSource = ds.Tables[0];
            c.Close();
            textBox2.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                scor = scor + 2;
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Clear();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                scor = scor + 2;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                scor = scor + 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out val))
            {
                scor = scor - val;
            }
            if(int.TryParse(textBox2.Text, out val1))
            {
                scor = scor + val1;
            }
            MessageBox.Show(scor.ToString());
            c.Open();
            string insert = @"insert into rank(username, scor, data)values(@username,@scor,@data)";
            SqlCommand cmd = new SqlCommand(insert, c);
            cmd.Parameters.AddWithValue("username", comboBox1.Text);
            cmd.Parameters.AddWithValue("scor", scor.ToString());
            cmd.Parameters.AddWithValue("data", DateTime.Now.ToString());
            SqlDataReader r = cmd.ExecuteReader();
            c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            leaderboard f = new leaderboard();
            f.Show();
        }
    }
}
