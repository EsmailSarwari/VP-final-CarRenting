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
    public partial class doluaraclar : Form
    {
        MySqlConnection baglan = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=secret;database=arac_kiralama");
        public doluaraclar()
        {
            InitializeComponent();
        }
        public void verilerigöster(string veriler)
        {
           
        }
        private void doluaraclar_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter ad = new MySqlDataAdapter("Select * from doluaraçlar", baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void doluaraclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
