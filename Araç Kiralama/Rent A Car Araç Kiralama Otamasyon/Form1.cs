using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class Form1 : Form
    {
        MySqlCommand cmd;
        string sql;
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
            sql = "server=localhost;port=3306;uid=root;pwd=secret;database=arac_kiralama";
            conn = new MySqlConnection(sql);
   
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayı1 = rastgele.Next(0, 10);
            int sayı2 = rastgele.Next(0, 10);
            int sayı3 = rastgele.Next(0, 10);
            int sayı4 = rastgele.Next(0, 10);
            label5.Text = sayı1.ToString() + sayı2.ToString() + sayı3.ToString() + sayı4.ToString();
            textBox3.Text = label5.Text;
        }

        string kullAdi, sifre;

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            sql = "SELECT * FROM `admin` LIMIT 1";
            cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                kullAdi = reader[1].ToString();
                sifre = reader[2].ToString();
            }

            if (textBox1.Text == kullAdi && textBox2.Text == sifre)
            {
                Form2 frm2 = new Form2();
                if (textBox3.Text == label5.Text)
                {
                    MessageBox.Show("Giriş Yapılıyor Lütfen Bekleyiniz...");
                    frm2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen Güvenlik Kodunu Kontrol Ediniz !");
                    textBox3.Clear();
                    textBox3.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adınızı veya Şifrenizi Kontrol Ediniz !");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
            conn.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}