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
using System.Security.Cryptography;

namespace NetHelp
{
    public partial class register : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public register()
        {
            InitializeComponent();
        }

        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "fbdshahfbhjasbhjdbfkjbfsadhj";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                    CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }

            return encryptString;
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            pagina_start f = new pagina_start();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            string s1 = textBox2.Text;
            var hash = Encrypt(s1);
            string insert = @"insert into logare(username,password)values(@username,@password)";
            SqlCommand cmd = new SqlCommand(insert, c);
            cmd.Parameters.AddWithValue("username", textBox1.Text);
            cmd.Parameters.AddWithValue("password", hash);
            SqlDataReader r = cmd.ExecuteReader();
            textBox2.Clear();
            textBox1.Clear();
            c.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;

            }
            else
            {
                textBox2.PasswordChar = '*';


            }
        }
    }
}
