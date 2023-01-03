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
    public partial class aracdüzenleme : Form
    {
        public aracdüzenleme()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=secret;database=arac_kiralama");
        public void verilerigöster(string veriler)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand komut = new MySqlCommand("insert into araçlar (Plaka,Marka,Seri,Model,Renk,MotorGücü,MotorHacmi,BakımTarihi,Kilometre,YakıtTürü,GünlükFiyat,Açıklama) values (@Plaka,@Marka,@Seri,@Model,@Renk,@MotorGücü,@MotorHacmi,@BakımTarihi,@Kilometre,@YakıtTürü,@GünlükFiyat,@Açıklama)", baglan);
            komut.Parameters.AddWithValue("@Plaka", textBox1.Text);
            komut.Parameters.AddWithValue("@Marka", textBox2.Text);
            komut.Parameters.AddWithValue("@Seri", textBox3.Text);
            komut.Parameters.AddWithValue("@Model", textBox4.Text);
            komut.Parameters.AddWithValue("@Renk", textBox5.Text);
            komut.Parameters.AddWithValue("@MotorGücü", textBox6.Text);
            komut.Parameters.AddWithValue("@MotorHacmi", textBox7.Text);
            komut.Parameters.AddWithValue("@BakımTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@Kilometre", textBox8.Text);
            komut.Parameters.AddWithValue("@YakıtTürü", comboBox1.Text);
            komut.Parameters.AddWithValue("@GünlükFiyat", textBox9.Text);
            komut.Parameters.AddWithValue("@Açıklama", textBox10.Text);
            komut.ExecuteNonQuery();
            verilerigöster("Select * from araçlar");
            baglan.Close();
            baglan.Open();
            MySqlCommand komutt = new MySqlCommand("insert into boşaraçlar (Plaka,Marka,Seri,Model,Renk) values (@Plaka,@Marka,@Seri,@Model,@Renk)", baglan);
            komutt.Parameters.AddWithValue("@Plaka", textBox1.Text);
            komutt.Parameters.AddWithValue("@Marka", textBox2.Text);
            komutt.Parameters.AddWithValue("@Seri", textBox3.Text);
            komutt.Parameters.AddWithValue("@Model", textBox4.Text);
            komutt.Parameters.AddWithValue("@Renk", textBox5.Text);
            komutt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Kaydedildi.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox1.Text = "";
        }

        private void aracdüzenleme_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from araçlar");
            dataGridView1.Columns[0].Visible = false;
            label14.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Bilgisini Güncellemek İstediğiniz Aracın Plakasını Giriniz.");
            }
            else
            {
                baglan.Open();
                MySqlCommand komut = new MySqlCommand("Update araçlar set Marka='" + textBox2.Text + "',Seri='" + textBox3.Text + "',Model='" + textBox4.Text + "',Renk='" + textBox5.Text + "',MotorGücü='" + textBox6.Text + "',MotorHacmi='" + textBox7.Text + "',BakımTarihi='" + dateTimePicker1.Text + "',Kilometre='" + textBox8.Text + "',YakıtTürü='" + comboBox1.Text + "',GünlükFiyat='" + textBox9.Text + "',Açıklama='" + textBox10.Text + "' where Plaka='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from araçlar");
                baglan.Close();

                baglan.Open();
                komut = new MySqlCommand("Update boşaraçlar set Marka='" + textBox2.Text + "',Seri='" + textBox3.Text + "',Model='" + textBox4.Text + "',Renk='" + textBox5.Text + "' where Plaka='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from araçlar");
                baglan.Close();

                MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Güncellendi.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                comboBox1.Text = "";
                baglan.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand komutt = new MySqlCommand();
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Aracın Plakasını Giriniz.", "Silmek İstediğiniz Aracın Plakasını Giriniz.", "");
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silinecek Aracın Plakası : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                baglan.Open();
                komutt.Connection = baglan;
                komutt.CommandText = "delete from araçlar where Plaka='" + IsimGirisi + "'";
                komutt.ExecuteNonQuery();
                baglan.Close();

                baglan.Open();
                komutt.Connection = baglan;
                komutt.CommandText = "delete from boşaraçlar where Plaka='" + IsimGirisi + "'";
                komutt.ExecuteNonQuery();
                baglan.Close();




                verilerigöster("Select * from araçlar");
                MessageBox.Show("Silmek İstediğiniz Plaka Başarıyla Silinmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                comboBox1.Text = "";
                baglan.Close();
            }
            if (cikis == DialogResult.No)
            {
                MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
                baglan.Close();

            }
        }

        private void aracdüzenleme_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      

            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();



            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
