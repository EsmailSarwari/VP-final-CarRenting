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
    public partial class sözlesmelerilistele : Form
    {
        public sözlesmelerilistele()
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
        private void sözlesmelerilistele_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from yenisözleşme");
            dataGridView1.Columns[0].Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void sözlesmelerilistele_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
