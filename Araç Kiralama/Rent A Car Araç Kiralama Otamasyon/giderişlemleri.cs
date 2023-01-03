using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class giderişlemleri : Form
    {
        public giderişlemleri()
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
            MySqlCommand komut = new MySqlCommand("INSERT INTO `giderislemleri`(`tarih`, `tutar`, `aciklama`) VALUES (@tarih,@tutar,@aciklama)", baglan);
            komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@tutar", textBox2.Text);
            komut.Parameters.AddWithValue("@aciklama", textBox1.Text);
            komut.ExecuteNonQuery();
            verilerigöster("Select * from giderislemleri");
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            if (selecdedIndex > 0)
            {
                cikis = MessageBox.Show("Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    MySqlCommand komut = new MySqlCommand("DELETE FROM `giderislemleri` WHERE id=@id", baglan);
                    komut.Parameters.AddWithValue("@id", selecdedIndex);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Gider Başarıyla Silinmiştir...");
                    verilerigöster("Select * from giderislemleri");
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silinmedi !");
                }

            }
        }

        private void giderişlemleri_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from giderislemleri");
        }

        private void giderişlemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        int selecdedIndex = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selecdedIndex = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }
    }
}
