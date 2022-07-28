# NetHelp
# About This Project
Digital wellbeing este utilizarea constienta a tehnologiei care permite indivizilor si 
comunitatilor sa-si realizeze potentialul. 
Aceasta constituie impactul pe care il are tehnologia asupra sanatatii fizice, 
mentale si emotionale. 

Noi consideram ca tehnologia exista pentru a veni in sprijinul nostru.

Totusi, uneori apare atat de des in viata noastra, incat ne poate distrage atentia de la lucrurile 
importante, cel mai intalnit efect negativ fiind utilizarea in mod excesiv a retelelor de socializare.

Ca solutie, am realizat acest proiect pentru a ajuta utilizatorul sa-si organizeze viata.

# Technologies Used
C#
SQL Server

# Content

1. Logare si inregistrare
Am folosit biblioteca Cryptography ca sa criptez parola pe care apoi am salvat-o intr-o baza de date. Pentru logare am criptat parola introdusa in textbox si am comparat-o cu cea din baza de date. Am folosit codul de aici: https://www.c-sharpcorner.com/article/encrypt-and-decrypt-user-password-in-sql-server-db-using-c-sharp-winform-application/ .


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
            if (textBox1.Text != "" && textBox2.Text != "")
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
            else
            {
                MessageBox.Show("Te rog introduce toate datele.", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
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
    public partial class pagina_start : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public pagina_start()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register f = new register();
            f.Show();
        }

        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "fbdshahfbhjasbhjdbfkjbfsadhj";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pass = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pass.GetBytes(32);
                encryptor.IV = pass.GetBytes(16);

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
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Te rog introduce toate datele.", "Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            c.Open();
            string s1 = textBox2.Text;
            var hash = Encrypt(s1);
            string select = "select * from logare where username='" + textBox1.Text + "' and password= '" + hash + "'";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
            {
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
                meniu f = new meniu();
                f.Show();
                
            }
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

2. Meniul
Pe aceasta forma am adus mai multe butoane, fiecare corespunde la unul din programele pe care le-am creat pentru acest proiect. Am creat si o animatie de string cu titlul si tema proiectului.
public partial class meniu : Form
    {
        int nr = 0, nr2;
        Graphics g, g1;
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
2.1 Introducere
Aceasta este o forma simpla cu doua labels unde este descrisa tema proiectului.

2.2 Avantaje si Dezavantaje
Am separat avantajele si dezavantajele folosirii tehnologiei in doua slideshow-uri. Apar succesiv imagini si date existente dintr-un fisier text la un interval specific de timp.

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

public partial class slide2 : Form
    {
        PointF[] v2 = new PointF[100];
        Class1[] v = new Class1[100];
        int k = 0, i = 0, n, m;
        Graphics g;
        public slide2()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
            slide f = new slide();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
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

            using (StreamReader fin = new StreamReader("textavantaj.txt"))
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            g = this.CreateGraphics(); g.Clear(Color.White);

            String drawString = v[i % n].denumire.ToString();

            Font drawFont = new Font("Trebuchet MS", 13, FontStyle.Underline);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            float x = 689.0F;
            float y = 90.0F;

            g.DrawString(drawString, drawFont, drawBrush, x, y);

            Image newImage = Image.FromFile(v[i % n].poza.ToString());
            Bitmap bimage = new Bitmap(newImage);
            TextureBrush tb = new TextureBrush(bimage);
            g.FillPolygon(tb, v2);
        }
    }

2.3 Modalitati de a combata excesul de screentime
 public partial class meniu2 : Form
    {
        public meniu2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            app f = new app();
            this.Close();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            schedule f = new schedule();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
            meniu f = new meniu();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            survey f = new survey();
            f.Show();
        }

2.3.1 Timer pentru Screentime
 public partial class timerscreen : Form
    {
        int time = 15;

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
            timer1.Interval = 1000;
            label2.Text = time.ToString();
            timer1.Start();
            panel11.BackColor = Color.DarkTurquoise;
            panel10.BackColor = Color.OrangeRed;
            panel9.BackColor = Color.Chartreuse;
            panel8.BackColor = Color.Red;
            panel7.BackColor = Color.Peru;
            panel6.BackColor = Color.Gold;
            panel12.BackColor = Color.DarkTurquoise;
            panel13.BackColor = Color.Chartreuse;
            panel12.Show();
            panel13.Show();
            panel11.Show();
            panel10.Show();
            panel9.Show();
            panel8.Show();
            panel7.Show();
            panel6.Show();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if(time == 0)
            {
                panel12.Hide();
                panel13.Hide();
                panel11.Hide();
                panel10.Hide();
                panel9.Hide();
                panel8.Hide();
                panel7.Hide();
                panel6.Hide();
                timer1.Stop();
                MessageBox.Show("Ai stat destul pe telefon astazi.", "Timer Screentime", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            label2.Text = time.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out time))
            {
                label2.Text = time.ToString();
            }
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            panel12.BackColor = Color.Crimson;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Crimson;
        }

2.3.2 Dark Mode Schedule
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

2.3.3 Activity Check
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
            if (int.TryParse(textBox1.Text, out val) && int.TryParse(textBox2.Text, out val1))
            {
                scor = scor - val + val1;
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

* Leaderboard
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
            string select = "select * from rank order by scor";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
                dataGridView1.Rows.Add(r[0], r[1], r[2], r[3]);
            c.Close();
        }
    }
2.3.4 Sondaj despre Digital Wellbeing
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

2.4 Calculator Screentime
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
            meniu f = new meniu();
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

2.4.1 Avantaje si Dezavantaje
Aceasta este tot o forma cu avantajele si dezavantajele tehnologiei, dar aici au fost afisate ca labels ca sa fie mai usor de citit.

public partial class avantaje : Form
    {
        public avantaje()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                panel2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
               
            }
            else
            {
                panel2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                panel3.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
            }
            else
            {
                panel3.Hide();
                label7.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
            }
        }

        private void slideshow_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
        }

2.4.2 Mai multe informatii
Am folosit biblioteca Diagnostics.
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
