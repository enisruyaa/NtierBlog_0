using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinUI
{
    public partial class Form1 : Form
    {
        AuthorRepository _aRep;
        public Form1()
        {
            InitializeComponent();
            _aRep = new AuthorRepository();
        }

        public void Listele()
        {
            lstYazarlar.DataSource = _aRep.GetActives();
            lstYazarlar.DisplayMember = "UserName";
            lstYazarlar.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Author a = new Author
            {
                UserName = txtKullaniciAdi.Text,
                Password = txtSifre.Text
            };
            _aRep.Add(a);
            Listele();
        }

        Author _secilen;

        public void SecileniResetle()
        {
            _secilen = null;
        }

        private void lstYazarlar_Click(object sender, EventArgs e)
        {
            if (lstYazarlar.SelectedIndex > -1)
            {
                _secilen = lstYazarlar.SelectedItem as Author;
                txtKullaniciAdi.Text = _secilen.UserName;
                txtSifre.Text = _secilen.Password;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_secilen != null)
            {
                _aRep.Delete(_secilen);
                SecileniResetle();
                Listele();
            }
            else MessageBox.Show("Lütfen Silmek İstediğiniz Yazarı Seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_secilen !=null)
            {
                _secilen.UserName = txtKullaniciAdi.Text;
                _secilen.Password = txtSifre.Text;
                _aRep.Update(_secilen);
                SecileniResetle();
                Listele();
            }
            else MessageBox.Show("Lütfen Güncellemek İstediğiniz Yazarı Seçiniz");
        }

        private void btnSpecialAdd_Click(object sender, EventArgs e)
        {
            if (_secilen != null)
            {
                _aRep.SpecialAdd(_secilen);
                SecileniResetle();
                Listele();
            }
            else MessageBox.Show("Lütfen Özel Yükleme Yapmak İstediğiniz Yazarı Seçiniz");
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
