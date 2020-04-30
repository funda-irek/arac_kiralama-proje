using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projje
{
    public partial class Müşteri_Ekleme : Form
    {
        Araç_Kirala arac_kiralama = new Araç_Kirala();
        public Müşteri_Ekleme()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "insert into müşteri(tc,adsoyad,telefon,email,adres) values(@tc,@adsoyad,@telefon,@email,@adres)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc",txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@email", txtEmail.Text);
            komut2.Parameters.AddWithValue("@adres", txtAdres.Text);
            arac_kiralama.ekle_sil_güncelle(komut2,cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
        }

        private void Müşteri_Ekleme_Load(object sender, EventArgs e)
        {

        }
    }
}
