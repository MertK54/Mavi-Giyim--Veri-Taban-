using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaviGiyim.UI;
using MaviGiyim.Bl;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1;

namespace MaviGiyim
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {

            DataSet ds = BLogic.SatisDetay();
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Veri bulunamadı.");
            }
            DataSet dsOdeme = BLogic.OdemeDetay();
            if (dsOdeme.Tables.Count > 0)
            {
                dataGridView2.DataSource = dsOdeme.Tables[0];
            }
            else
            {
                MessageBox.Show("Ödeme verisi bulunamadı.");
            }

        }
        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            new Müşteriler().ShowDialog();
        }

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            new Ürünler().ShowDialog();
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            SatisForm satisForm = new SatisForm()
            {
                Text = "Satış Yap",
                Satis =new Satis() 
                {
                    ID = Guid.NewGuid(),
                }
            };
                tekrar:
                var sonuc = satisForm.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    bool b = BLogic.SatisEkle(satisForm.Satis);
                    if (b)
                    {
                        DataSet ds = BLogic.SatisDetay();
                     if (ds != null)
                      {
                           dataGridView1.DataSource = ds.Tables[0];
                      }
                        else
                          goto tekrar;
                    }
            }

        }

       

        private void btnSatisDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            SatisForm satisForm = new SatisForm()
            {
                Text = "Satış Güncelle",
                Güncelleme = true,
                Satis = new Satis()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    MusteriID = Guid.Parse(row.Cells[1].Value.ToString()),
                    UrunID = Guid.Parse(row.Cells[2].Value.ToString()),
                    Fiyat = double.Parse(row.Cells[7].Value.ToString()),
                    Tarih = DateTime.Parse(row.Cells[8].Value.ToString()),
                },
            };
            var sonuc = satisForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisGuncelle(satisForm.Satis);
                {
                    row.Cells[1].Value = satisForm.Satis.ID;
                    row.Cells[2].Value = satisForm.Satis.UrunID;
                    row.Cells[7].Value = satisForm.Satis.Fiyat;
                    row.Cells[8].Value = satisForm.Satis.Tarih;
                }
            }
        }

        private void btnSatisSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = Guid.Parse(row.Cells[0].Value.ToString());
            var sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi", "Silmeyi Onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.SatisDetay();
                    if (ds != null)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            OdemeForm odemeForm = new OdemeForm()
            {
                Text = "Ödeme Yap",
                Odeme = new Odeme()
                {
                    ID = Guid.NewGuid(),
                }
            };
            tekrar:
            var sonuc = odemeForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeEkle(odemeForm.Odeme);
                if (b)
                {
                    DataSet ds = BLogic.OdemeDetay();
                    if (ds != null)
                    {
                        dataGridView2.DataSource = ds.Tables[0];
                    }
                    else
                        goto tekrar;
                }
            }
        }

        private void btnÖdemeDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            OdemeForm odemeForm = new OdemeForm()
            {
                Text = "Ödeme Düzenle",
                Güncelleme = true,
                Odeme = new Odeme()
                {
                    ID = Guid.Parse(row.Cells[0].Value.ToString()),
                    MusteriID = Guid.Parse(row.Cells[1].Value.ToString()),
                    Tarih = DateTime.Parse(row.Cells[3].Value.ToString()),
                    Fiyat = double.Parse(row.Cells[4].Value.ToString()),
                    Tur = row.Cells[5].Value.ToString(),
                    Aciklama = row.Cells[6].Value.ToString(),
                },
            };
            var sonuc = odemeForm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeGuncelle(odemeForm.Odeme);
                {
                    row.Cells[1].Value = odemeForm.Odeme.MusteriID;
                    row.Cells[3].Value = odemeForm.Odeme.Tarih;
                    row.Cells[5].Value = odemeForm.Odeme.Fiyat;
                    row.Cells[5].Value = odemeForm.Odeme.Tur;
                    row.Cells[6].Value = odemeForm.Odeme.Aciklama;
                }
            }
        }

        private void btnÖdemeSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID =row.Cells[0].Value.ToString();
            var sonuc = MessageBox.Show("Seçili Kayıt Silinsin mi", "Silmeyi Onayla", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OdemeSil(ID);
                if (b)
                {
                    DataSet ds = BLogic.OdemeDetay();
                    if (ds != null)
                    {
                        dataGridView2.DataSource = ds.Tables[0];
                    }
                }
            }
        }

        private void btnOdemeYap_Click_1(object sender, EventArgs e)
        {

        }
    }
}
