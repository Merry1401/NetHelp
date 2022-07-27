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
    public partial class survey : Form
    {
        int verif = 0;
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public survey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            if (string.Compare(listBox1.SelectedItem.ToString(), "Jocuri Video") == 0 )
            { 
                string insert = @"insert into survey(username, nivel, raspuns)values(@username,@nivel,@raspuns)";
                SqlCommand cmd = new SqlCommand(insert, c);
                cmd.Parameters.AddWithValue("username", listBox2.SelectedItem);
                cmd.Parameters.AddWithValue("nivel", listBox1.SelectedItem);
                cmd.Parameters.AddWithValue("raspuns", verif.ToString());
                SqlDataReader r = cmd.ExecuteReader();
            }
            if (string.Compare(listBox1.SelectedItem.ToString(), "Site-uri de Social Media") == 0)
            {
                string insert = @"insert into survey(username, nivel, raspuns)values(@username,@nivel,@raspuns)";
                SqlCommand cmd = new SqlCommand(insert, c);
                cmd.Parameters.AddWithValue("username", listBox2.SelectedItem);
                cmd.Parameters.AddWithValue("nivel", listBox1.SelectedItem);
                cmd.Parameters.AddWithValue("raspuns", verif.ToString());
                SqlDataReader r = cmd.ExecuteReader();
            }
            if (string.Compare(listBox1.SelectedItem.ToString(), "Alte Site-uri") == 0)
            {
                string insert = @"insert into survey(username, nivel, raspuns)values(@username,@nivel,@raspuns)";
                SqlCommand cmd = new SqlCommand(insert, c);
                cmd.Parameters.AddWithValue("username", listBox2.SelectedItem);
                cmd.Parameters.AddWithValue("nivel", listBox1.SelectedItem);
                cmd.Parameters.AddWithValue("raspuns", verif.ToString());
                SqlDataReader r = cmd.ExecuteReader();
            }
            c.Close();
        }

        private void survey_Load(object sender, EventArgs e)
        {
            c.Open();
            string select = "select username from logare";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                listBox2.Items.Add(r[0].ToString());
            c.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            verif = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            verif = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            verif = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            c.Open();
            string select = "select * from survey order by raspuns";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                dataGridView1.Rows.Add(r[0], r[1], r[2], r[3]);
            c.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }
    }
}
