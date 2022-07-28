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
using System.Data.SqlClient;

namespace NetHelp
{
    public partial class leaderboard : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public leaderboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            string select = "select * from rank order by cast(scor as int) DESC";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                dataGridView1.Rows.Add(r[0], r[1], r[2], r[3]);
            c.Close();
        }
    }
}
