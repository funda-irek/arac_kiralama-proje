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
    public partial class Sözleşme : Form
    {
        public Sözleşme()
        {
            InitializeComponent();
        }
        Araç_Kirala arac = new Araç_Kirala();

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sözleşme_Load(object sender, EventArgs e)
        {
            Boş_Araçlar();
            Yenile();

        }

        private void Boş_Araçlar()
        {
            string sorgu2 = "select * from araç where durumu='BOŞ'";
            arac.Boş_Araçlar(comboAraçlar, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "Select * from sözleşme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

            if (txtTc.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            string sorgu2 = "Select * from müşteri where tc like '" + txtTc.Text + "'";
            arac.Tc_Ara(txtTcAra, txtTc, txtAdSoyad, txtTelefon, sorgu2);


        }


        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "Select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.CombodanGetir(comboAraçlar, txtMarka, txtSeri, txtYil, txtRenk, sorgu2);
        }

        private void txtKiraŞekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "Select * from araç where plaka like '" + comboAraçlar.SelectedItem + "'";
            arac.Ücret_Hesapla(comboKiraŞekli, txtKiraUcreti, sorgu2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDönüşTarihi.Text) - DateTime.Parse(dateÇıkışTarihi.Text);
            int gun2 = gun.Days;
            txtGün.Text = gun2.ToString();
            txtTutar.Text = (gun2 * int.Parse(txtKiraUcreti.Text)).ToString();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();


        }

        private void Temizle()
        {
            dateÇıkışTarihi.Text = DateTime.Now.ToShortDateString();
            dateDönüşTarihi.Text = DateTime.Now.ToShortDateString();
            comboKiraŞekli.Text = "";
            txtKiraUcreti.Text = "";
            txtGün.Text = "";
            txtTutar.Text = "";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözleşme(tc,adsoyad,telefon,ehliyetno,e_tarih,e_yer,plaka,marka,seri,yil,renk,kirasekli,kiraucreti,gun,tutar,c_tarih,d_tarih) values(@tc,@adsoyad,@telefon,@ehliyetno,@e_tarih,@e_yer,@plaka,@marka,@seri,@yil,@renk,@kirasekli,@kiraucreti,@gun,@tutar,@c_tarih,@d_tarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@c_tarih", dateÇıkışTarihi.Text);
            komut2.Parameters.AddWithValue("@d_tarih", dateDönüşTarihi.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);


            string sorgu3 = "update araç set durumu='DOLU' where plaka='" + comboAraçlar + "' ";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_güncelle(komut3, sorgu3);
            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraçlar.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme Eklendi");


        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTcAra.Text == "") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            string sorgu2 = "Select * from müşteri where tc like '" + txtTcAra.Text + "'";
            arac.Tc_Ara(txtTcAra, txtTc, txtAdSoyad, txtTelefon, sorgu2);
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözleşme set tc=@tc,adsoyad=@adsoyad,telefon=@telefon,ehliyetno=@ehliyetno,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,yil=@yil,renk=@renk,kirasekli=@kirasekli,kiraucreti=@kiraucreti,gun=@gun,tutar=@tutar,c_tarih=@c_tarih,d_tarih=@d_tarih where plaka=@plaka ";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_Tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Yer.Text);
            komut2.Parameters.AddWithValue("@plaka", comboAraçlar.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeri.Text);
            komut2.Parameters.AddWithValue("@yil", txtYil.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@kirasekli", comboKiraŞekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiraUcreti.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGün.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutar.Text));
            komut2.Parameters.AddWithValue("@c_tarih", dateÇıkışTarihi.Text);
            komut2.Parameters.AddWithValue("@d_tarih", dateDönüşTarihi.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);

            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraçlar.Text = "";
            Temizle();
            MessageBox.Show("Sözleşme Güncellendi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtE_No.Text = satır.Cells[3].Value.ToString();
            txtE_Tarih.Text = satır.Cells[4].Value.ToString();
            txtE_Yer.Text = satır.Cells[5].Value.ToString();
            comboAraçlar.Text = satır.Cells[6].Value.ToString();
            txtMarka.Text = satır.Cells[7].Value.ToString();
            txtYil.Text = satır.Cells[9].Value.ToString();
            txtRenk.Text = satır.Cells[10].Value.ToString();
            comboKiraŞekli.Text = satır.Cells[11].Value.ToString();
            txtKiraUcreti.Text = satır.Cells[12].Value.ToString();
            txtGün.Text = satır.Cells[14].Value.ToString();
            dateÇıkışTarihi.Text = satır.Cells[15].Value.ToString();
            dateDönüşTarihi.Text = satır.Cells[16].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            //gün fark hesaplama
            DateTime bugün = DateTime.Parse(DateTime.Now.ToLongDateString());
            DateTime dönüş = DateTime.Parse(satır.Cells["d_tarih"].Value.ToString());
            int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
            TimeSpan gunfarkı = bugün - dönüş;
            int _gunfarkı = gunfarkı.Days;
            int ucretfarkı;
            //Ücret farkı hesaplama
            ucretfarkı = _gunfarkı * ucret;
            txtEkstra.Text = ucretfarkı.ToString();
            //toplam tutar hesaplama
        }

        
        private void btnAraçTeslim_Click_1(object sender, EventArgs e)
        {
            
            if(int.Parse(txtEkstra.Text)>=0 && int.Parse(txtEkstra.Text)<0)
            {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            DateTime bugün = DateTime.Parse(DateTime.Now.ToLongDateString());
            int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
            int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
            DateTime çıkış = DateTime.Parse(satır.Cells["ctarih"].Value.ToString());
            TimeSpan gun = bugün - çıkış;
            int _gun= gun.Days;
            int toplamtutar = _gun * ucret;
            ///Toplam tutar ,_gun ve ucret satış tablosuna aktarılacak.
            string sorgu1 = "delete from sözleşme where plaka='"+satır.Cells["plaka"].Value.ToString()+ "'";
            SqlCommand komut = new SqlCommand();
            arac.ekle_sil_güncelle(komut,sorgu1);
            string sorgu2 = "update araç set durumu='BOŞ' where plaka='"+satır.Cells["plaka"].Value.ToString()+ "'";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_güncelle(komut3, sorgu2);

            string sorgu3 = "insert into satış(tc,adsoyad,plaka,marka,seri,yil,renk,gun,tutar,tarih1,tarih2,fiyat) values(@tc,@adsoyad,@plaka,@marka,@seri,@yil,@renk,@gun,@tutar,@tarih1,@tarih2,@fiyat)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc",satır.Cells["tc"].Value.ToString());
            komut2.Parameters.AddWithValue("@adsoyad", satır.Cells["adsoyad"].Value.ToString());
            komut2.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
            komut2.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
            komut2.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
            komut2.Parameters.AddWithValue("@yil", satır.Cells["yil"].Value.ToString());
            komut2.Parameters.AddWithValue("@renk", satır.Cells["renk"].Value.ToString());
            komut2.Parameters.AddWithValue("@gun", _gun);
            komut2.Parameters.AddWithValue("@tutar", toplamtutar);
            komut2.Parameters.AddWithValue("@tarih1", satır.Cells["ctarih"].Value.ToString()); ;
            komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
            komut2.Parameters.AddWithValue("@fiyat", ucret);
            arac.ekle_sil_güncelle(komut2, sorgu3);

            MessageBox.Show("Araç Teslim Edildi");
            comboAraçlar.Text = "";
            comboAraçlar.Items.Clear();
            Boş_Araçlar();
            Yenile();
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            comboAraçlar.Text = "";
            Temizle();

            txtEkstra.Text = "";
            }
        
            else
            {
                MessageBox.Show("Lütfen Seçim Yapınız","Uyarı");
            }

          }
        }
    }

    
