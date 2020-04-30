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
    public partial class Kullanıcı_Giriş_Sayfası : Form
    {
        public Kullanıcı_Giriş_Sayfası()
        {
            InitializeComponent();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text="";

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Müşteri_Ekleme form = new Müşteri_Ekleme();
            form.ShowDialog();
        }
        int girishakkı = 3;
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" ||textBox2.Text=="" )
            {
                MessageBox.Show("Kullanıcı Adı ve/veya Şifre Boş Geçilemez!!","Uyarı");
            }
            else
            {
                if (textBox1.Text=="admin" && textBox2.Text=="123" || textBox1.Text=="Yönetici" && textBox2.Text=="456")
                {
                    Müşteri_Listeleme frm = new Müşteri_Listeleme();
                    frm.Show();
                    this.Hide();

                }
                else
                {
                    girishakkı--;
                    MessageBox.Show("Kullanıcı Adı ve/veya Şifre Yanlış!!.Kalan Hakkınız="+girishakkı, "Uyarı2");
                    if (girishakkı==0)
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
