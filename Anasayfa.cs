using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projje
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müşteri_Ekleme ekle = new Müşteri_Ekleme();
            ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Müşteri_Listeleme listele = new Müşteri_Listeleme();
            listele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Araç_Kayıt_Formu kayit = new Araç_Kayıt_Formu();
            kayit.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Araç_Listeleme liste = new Araç_Listeleme();
            liste.ShowDialog();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sözleşme sözleşme = new Sözleşme();
            sözleşme.ShowDialog();
        }

        private void btnKullanıcı_Click(object sender, EventArgs e)
        {
            Kullanıcı_Giriş_Sayfası goster = new Kullanıcı_Giriş_Sayfası();
                  goster.ShowDialog();
        }
    }
}
