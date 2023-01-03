using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void araçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracdüzenleme aracdüzenleme = new aracdüzenleme();
            aracdüzenleme.Show();
        }

        private void boştakiAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bosaraclar bosaraclar = new bosaraclar();
            bosaraclar.Show();
        }

        private void doluAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doluaraclar doluaraclar = new doluaraclar();
            doluaraclar.Show();
        }

        private void araçlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            araclarılistele araclistele = new araclarılistele();
            araclistele.Show();
        }

        private void müşteriDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenisözlesme yenisözlesme = new yenisözlesme();
            yenisözlesme.Show();
        }

        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sözlesmelerilistele sözlesmelerilistele = new sözlesmelerilistele();
            sözlesmelerilistele.Show();
        }

        private void kullanıcılarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanıcılarıdüzenle kullanıcılarıdüzenle = new kullanıcılarıdüzenle();
            kullanıcılarıdüzenle.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kasaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasa kasa = new kasa();
            kasa.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripMenuItem5.Text = DateTime.Now.ToLongDateString();

            var request = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=kutahya&units=metric&lang=tr&appid=f648c50e66d18646dfc9341d3774dfe7");
            request.ContentType = "application/json";
            request.Method = "POST";
            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var sonuc = streamReader.ReadToEnd();

                    //MessageBox.Show(sonuc.ToString());
                    var veri = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(sonuc);

                    label1.Text = veri["main"]["temp"].ToString() + " " + label1.Text;
                }
            }
            catch
            {
                MessageBox.Show("Connection Faild");
            }
        }

        private void giderİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giderişlemleri gider = new giderişlemleri();
            gider.Show();
        }
    }
}
