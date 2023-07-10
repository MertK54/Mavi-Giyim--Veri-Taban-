using MaviGiyim.Bl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaviGiyim.UI
{
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }

        private void Ürünler_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.UrunGetir("");
            if (ds1.Tables.Count > 0)
            {
                dataGridView2.DataSource = ds1.Tables[0];
            }
            else
            {
                MessageBox.Show("Veri bulunamadı.");
            }
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            UrunForm urunForm = new UrunForm()
            {
                Text = "Ürün Ekle",
                Urun = new Urun() { ID = Guid.NewGuid() },
            };
            tekrar:
            var sonuc = urunForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(urunForm.Urun);
                if (b)
                {
                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                    {
                        dataGridView2.DataSource = ds.Tables[0];
                    }
                    else
                        goto tekrar;
                }
            }
        }

        private void btnUrunBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UrunGetir(toolStripTextBox2.Text);
            if (ds.Tables.Count > 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Veri bulunamadı.");
            }
        }

        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            UrunForm urunForm = new UrunForm()
            {
                Text = "Ürün Güncelle",
                Güncelleme = true,
                Urun = new Urun()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Stok = double.Parse(row.Cells[4].Value.ToString()),
                    Birim = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[5].Value.ToString(),
                },
            };
            var sonuc = urunForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunGüncelle(urunForm.Urun);
                if (b)
                {
                    row.Cells[1].Value = urunForm.Urun.Ad;
                    row.Cells[2].Value = urunForm.Urun.Kategori;
                    row.Cells[3].Value = urunForm.Urun.Fiyat;
                    row.Cells[4].Value = urunForm.Urun.Stok;
                    row.Cells[5].Value = urunForm.Urun.Birim;
                    row.Cells[6].Value = urunForm.Urun.Detay;
                }
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());
            var sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi", "Silmeyi Onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                    {
                        dataGridView2.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        public Urun Urun { get; set; }
        private void btnOkey_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
                Urun = new Urun()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Kategori = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[3].Value.ToString()),
                    Stok = double.Parse(row.Cells[4].Value.ToString()),
                    Birim = row.Cells[5].Value.ToString(),
                    Detay = row.Cells[5].Value.ToString(),
                };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
