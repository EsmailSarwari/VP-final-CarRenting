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
    public partial class bosaraclar : Form
    {
        MySqlConnection baglan = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=secret;database=arac_kiralama");

        public bosaraclar()
        {
            InitializeComponent();
        }
        public void verilerigöster(string veriler)
        {
        }

        private void bosaraclar_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("Select * from boşaraçlar", baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void bosaraclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
