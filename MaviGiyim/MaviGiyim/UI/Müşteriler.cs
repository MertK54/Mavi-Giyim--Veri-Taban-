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
    public partial class Müşteriler : Form
    {
        public Müşteriler()
        {
            InitializeComponent();
        }
        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            MusteriForm musteriForm = new MusteriForm()
            {
                Text = "Musteri Ekle",
                Musteri = new Musteri() { ID = Guid.NewGuid() },
            };
            tekrar:
            var sonuc = musteriForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriEkle(musteriForm.Musteri);
                if (b)
                {
                    DataSet ds = BLogic.MüşteriGetir("");
                    if (ds != null)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    else
                        goto tekrar;
                }
            }
        }

        private void btnMusteriDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            MusteriForm musteriForm = new MusteriForm()
            {
                Text = "Musteri Güncelle",
                Güncelleme = true,
                Musteri = new Musteri()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[2].Value.ToString(),
                    Telefon = row.Cells[3].Value.ToString(),
                    Mail = row.Cells[4].Value.ToString(),
                    Adres = row.Cells[5].Value.ToString(),
                },
            };
            var sonuc = musteriForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriGüncelle(musteriForm.Musteri);
                if (b)
                {
                    row.Cells[1].Value = musteriForm.Musteri.Ad;
                    row.Cells[2].Value = musteriForm.Musteri.Soyad;
                    row.Cells[3].Value = musteriForm.Musteri.Telefon;
                    row.Cells[4].Value = musteriForm.Musteri.Mail;
                    row.Cells[5].Value = musteriForm.Musteri.Adres;
                }
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.MüşteriGetir(toolStripTextBox1.Text);
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Veri bulunamadı.");
            }
        }
        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());
            var sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi", "Silmeyi Onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.MüşteriSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.MüşteriGetir("");
                    if (ds != null)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private void Müşteriler_Load(object sender, EventArgs e)
        {
            DataSet ds = BLogic.MüşteriGetir("");
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Veri bulunamadı.");
            } 
            btnOkey.Click += btnOkey_Click;
        }
        public Musteri Musteri { get; set; }
        private void btnOkey_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            Musteri = new Musteri()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Soyad = row.Cells[2].Value.ToString(),
                Telefon = row.Cells[3].Value.ToString(),
                Mail = row.Cells[4].Value.ToString(),
                Adres = row.Cells[5].Value.ToString(),
            };
            DialogResult = DialogResult.OK; // Formun kapanmasını sağlar

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
