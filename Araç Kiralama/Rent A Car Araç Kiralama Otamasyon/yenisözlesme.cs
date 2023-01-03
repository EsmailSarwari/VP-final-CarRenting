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
    public partial class yenisözlesme : Form
    {
        public yenisözlesme()
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
        private void yenisözlesme_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            label26.Text = DateTime.Now.ToLongDateString();
            verilerigöster("Select * from yenisözleşme");
            MySqlCommand komut = new MySqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "Select * from boşaraçlar";
            komut.CommandType = CommandType.Text;

            MySqlDataReader dr;
            baglan.Open();
            dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr["Plaka"]);
            }
            baglan.Close();
            dataGridView1.Columns[0].Visible = false;
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("Select * From boşaraçlar", baglan);
            baglan.Open();
            MySqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text == read["Plaka"].ToString())
                {

                    textBox13.Text = read["Plaka"].ToString();
                    textBox14.Text = read["Marka"].ToString();
                    textBox15.Text = read["Seri"].ToString();
                    textBox16.Text = read["Model"].ToString();
                    textBox17.Text = read["Renk"].ToString();
                }
            }
            baglan.Close();
            komut.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                MySqlCommand komut = new MySqlCommand("insert into yenisözleşme (SözleşmeTarihi,TcKimlik,AdSoyad,Cinsiyet,DoğumTarihi,DoğumYeri,CepTelefon,EMail,Adres,EhliyetNo,EhliyetTarihi,EhliyetVerilenYer,ÇıkışZamanı,DönüşZamanı,KullanımSüresi,VekilAdSoyad,VekilCepTelefon,Plaka,Marka,Seri,Model,Renk,Açıklama,ToplamTutar) values (@SözleşmeTarihi,@TcKimlik,@AdSoyad,@Cinsiyet,@DoğumTarihi,@DoğumYeri,@CepTelefon,@EMail,@Adres,@EhliyetNo,@EhliyetTarihi,@EhliyetVerilenYer,@ÇıkışZamanı,@DönüşZamanı,@KullanımSüresi,@VekilAdSoyad,@VekilCepTelefon,@Plaka,@Marka,@Seri,@Model,@Renk,@Açıklama,@ToplamTutar)", baglan);
                komut.Parameters.AddWithValue("@SözleşmeTarihi", label26.Text);
                komut.Parameters.AddWithValue("@TcKimlik", textBox1.Text);
                komut.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
                komut.Parameters.AddWithValue("@Cinsiyet", comboBox2.Text);
                komut.Parameters.AddWithValue("@DoğumTarihi", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@DoğumYeri", textBox4.Text);
                komut.Parameters.AddWithValue("@CepTelefon", textBox5.Text);
                komut.Parameters.AddWithValue("@EMail", textBox6.Text);
                komut.Parameters.AddWithValue("@Adres", textBox7.Text);
                komut.Parameters.AddWithValue("@EhliyetNo", textBox8.Text);
                komut.Parameters.AddWithValue("@EhliyetTarihi", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("@EhliyetVerilenYer", textBox9.Text);
                komut.Parameters.AddWithValue("@ÇıkışZamanı", dateTimePicker3.Text);
                komut.Parameters.AddWithValue("@DönüşZamanı", dateTimePicker4.Text);
                komut.Parameters.AddWithValue("@KullanımSüresi", textBox10.Text);
                komut.Parameters.AddWithValue("@VekilAdSoyad", textBox11.Text);
                komut.Parameters.AddWithValue("@VekilCepTelefon", textBox12.Text);
                komut.Parameters.AddWithValue("@Plaka", textBox13.Text);
                komut.Parameters.AddWithValue("@Marka", textBox14.Text);
                komut.Parameters.AddWithValue("@Seri", textBox15.Text);
                komut.Parameters.AddWithValue("@Model", textBox16.Text);
                komut.Parameters.AddWithValue("@Renk", textBox17.Text);
                komut.Parameters.AddWithValue("@Açıklama", textBox18.Text);
                komut.Parameters.AddWithValue("@ToplamTutar", textBox19.Text);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from yenisözleşme");
                baglan.Close();
                baglan.Open();
                MySqlCommand komutt = new MySqlCommand("insert into doluaraçlar (Plaka,Marka,Seri,Model,Renk) values (@Plaka,@Marka,@Seri,@Model,@Renk)", baglan);
                komutt.Parameters.AddWithValue("@Plaka", textBox13.Text);
                komutt.Parameters.AddWithValue("@Marka", textBox14.Text);
                komutt.Parameters.AddWithValue("@Seri", textBox15.Text);
                komutt.Parameters.AddWithValue("@Model", textBox16.Text);
                komutt.Parameters.AddWithValue("@Renk", textBox17.Text);
                komutt.ExecuteNonQuery();
                baglan.Close();
                baglan.Open();
                MySqlCommand komuttt = new MySqlCommand("insert into kasa (SözleşmeTarihi,MüşteriAdSoyad,SeçilenAraba,ToplamTutar) values (@SözleşmeTarihi,@MüşteriAdSoyad,@SeçilenAraba,@ToplamTutar)", baglan);
                komuttt.Parameters.AddWithValue("@SözleşmeTarihi", label26.Text);
                komuttt.Parameters.AddWithValue("@MüşteriAdSoyad", textBox2.Text);
                komuttt.Parameters.AddWithValue("@SeçilenAraba", textBox13.Text);
                komuttt.Parameters.AddWithValue("@ToplamTutar", textBox19.Text);
                komuttt.ExecuteNonQuery();
                baglan.Close();
                baglan.Open();
                komutt.Connection = baglan;
                komutt.CommandText = "delete from boşaraçlar where Plaka='" + comboBox1.Text + "'";
                komutt.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Girmiş Olduğunuz Sözleşme Bilgileri Başarıyla Kaydedilmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            catch
            {
                MessageBox.Show("Bir Hata Olustu.\n Tutar Bos Olamaz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand komutt = new MySqlCommand();
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'sunu Yazınız...", "Silme İşlemi", "");
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Silmek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'su : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                baglan.Open();
                komutt.Connection = baglan;
                komutt.CommandText = "delete from yenisözleşme where TcKimlik='" + IsimGirisi + "'";
                komutt.ExecuteNonQuery();
                baglan.Close();
                verilerigöster("Select * from yenisözleşme");
                MessageBox.Show("Sözleşme Başarıyla Silinmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            if (cikis == DialogResult.No)
            {
                MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
            }
        }

        private void yenisözlesme_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Sözleşmesini Güncellemek İstediğiniz Kişinin Tc Kimlik Nosunu Giriniz.");
            }
            else 
            {
                baglan.Open();
                MySqlCommand komut = new MySqlCommand("Update yenisözleşme set AdSoyad='" + textBox2.Text + "',Cinsiyet='" + comboBox2.Text + "',DoğumTarihi='" + dateTimePicker1.Text + "',DoğumYeri='" + textBox4.Text + "',CepTelefon='" + textBox5.Text + "',EMail='" + textBox6.Text + "',Adres='" + textBox7.Text + "',EhliyetNo='" + textBox8.Text + "',EhliyetTarihi='" + dateTimePicker2.Text + "',EhliyetVerilenYer='" + textBox9.Text + "',ÇıkışZamanı='" + dateTimePicker3.Text + "',DönüşZamanı='" + dateTimePicker4.Text + "',KullanımSüresi='" + textBox10.Text + "',VekilAdSoyad='" + textBox11.Text + "',VekilCepTelefon='" + textBox12.Text + "',Plaka='" + textBox13.Text + "',Marka='" + textBox14.Text + "',Seri='" + textBox15.Text + "',Model='" + textBox16.Text + "',Renk='" + textBox17.Text + "',Açıklama='" + textBox18.Text + "',ToplamTutar='" + textBox19.Text + "' where TcKimlik='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from yenisözleşme");
                baglan.Close();
                MessageBox.Show("Girmiş Olduğunuz Sözleşme Bilgileri Başarıyla Güncellenmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            dateTimePicker4.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();
            textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[19].Value.ToString();
            textBox15.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
            textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString();
            textBox17.Text = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
            textBox18.Text = dataGridView1.Rows[e.RowIndex].Cells[23].Value.ToString();
            textBox19.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
        }
    }
}
