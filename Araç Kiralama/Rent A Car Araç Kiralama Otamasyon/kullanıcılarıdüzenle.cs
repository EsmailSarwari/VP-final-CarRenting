using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class kullanıcılarıdüzenle : Form
    {
        public kullanıcılarıdüzenle()
        {
            InitializeComponent();
        }

        MySqlConnection baglan = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=secret;database=arac_kiralama");



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    baglan.Open();
                    MySqlCommand komut = new MySqlCommand("insert into calisanlar (kullAdi,sifre) values (@kullAdi,@sifre)", baglan);
                    komut.Parameters.AddWithValue("@kullAdi", textBox1.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kullanici Kaydedildi");

                    Close();
                }
                catch(Exception err)
                {
                    MessageBox.Show("Bu kullanici adi zaten var"+err.ToString());
                }
              
            }
            else
            {
                MessageBox.Show("Kullanıcı Başarıyla Eklenmiştir...");
            }
        }

        private void kullanıcılarıdüzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Şifresini Değiştirmek İstediğiniz Kullanıcı İsmini Giriniz...");
            }
            else
            {
                baglan.Open();
                MySqlCommand komut = new MySqlCommand("update calisanlar set sifre=@sifre where kullAdi=@kullAdi", baglan);
                komut.Parameters.AddWithValue("@kullAdi", textBox1.Text);
                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();

                Close();
                MessageBox.Show("Kullanıcı Başarıyla Güncellenmiştir...");
                textBox1.Clear();
                textBox2.Clear();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Kullanıcının İsmini Yazınız...", "Silme İşlemi", "");

            DialogResult cikis = new DialogResult();
            
            if(IsimGirisi.Length > 0)
            {
                cikis = MessageBox.Show("Silmek İstediğiniz Kullanıcı İsmi : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    MySqlCommand komut = new MySqlCommand("DELETE from calisanlar where kullAdi=@kullAdi", baglan);
                    komut.Parameters.AddWithValue("@kullAdi", IsimGirisi);
                    komut.ExecuteNonQuery();
                    baglan.Close();

                    MessageBox.Show("Kullanıcı Başarıyla Silinmiştir...");
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
                }

            }
           
        }


        private void kullanıcılarıdüzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
