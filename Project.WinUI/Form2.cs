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
    public partial class Form2 : Form
    {
        CategoryRepository _cRep;
        public Form2()
        {
            InitializeComponent();
            _cRep = new CategoryRepository();
        }

        public void Listele()
        {
            lstKategoriler.DataSource = _cRep.GetActives();
            lstKategoriler.DisplayMember = "CategoryName";
            lstKategoriler.SelectedIndex = -1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Category c = new Category
            {
                CategoryName = txtKategoriAdi.Text
            };
            _cRep.Add(c);
            Listele();
        }

        Category _secilen;

        public void SecileniResetle()
        {
            _secilen = null;
        }

        private void lstKategoriler_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedIndex >-1)
            {
                _secilen = lstKategoriler.SelectedItem as Category;
                txtKategoriAdi.Text = _secilen.CategoryName;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_secilen != null)
            {
                _cRep.Delete(_secilen);
                SecileniResetle();
                Listele();
            }
            else MessageBox.Show("Lütfen Silmek İstediğiniz Kategoriyi Seçiniz");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_secilen != null)
            {
                _secilen.CategoryName = txtKategoriAdi.Text;
                _cRep.Update(_secilen);
                SecileniResetle();
                Listele();
            }
            else MessageBox.Show("Lütfen Güncellemek İstediğiniz Kategoriyi Seçiniz");
        }

        private void btnSpecialAdd_Click(object sender, EventArgs e)
        {
            if (_secilen != null) 
            {
                _cRep.SpecialAdd(_secilen);
                lstKategoriler.DataSource = _cRep.GetModifieds();
            }
            else MessageBox.Show("Lütfen Özel Ekleme Yapmak İçin Bir Kategori Seçiniz");
        }
    }
}
