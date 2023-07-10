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
    public partial class OdemeForm : Form
    {
        public OdemeForm()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        public Odeme Odeme { get; set; }
        public bool Güncelleme { get; set; } = false;
        private void btnOkey_Click(object sender, EventArgs e)
        {
            
        }

        private void OdemeForm_Load(object sender, EventArgs e)
        {
            txtID.Text = Odeme.ID.ToString();
            if (Güncelleme)
            {
                txtName.Text = Odeme.MusteriID.ToString();
                nmPrice.Value = (decimal)Odeme.Fiyat;
                tdDate.Value = Odeme.Tarih;
                cbBuy.SelectedItem = Odeme.Tur;
                destription.Text = Odeme.Aciklama.ToString();
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            Müşteriler frm = new Müşteriler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtName.Text = frm.Musteri.ID.ToString();
            }
        }

        private void btnOkey_Click_1(object sender, EventArgs e)
        {
            Odeme.Tur = cbBuy.SelectedItem.ToString();
            Odeme.Fiyat = (double)nmPrice.Value;
            Odeme.Aciklama = destription.Text;
            Odeme.Tarih = tdDate.Value;
            Odeme.MusteriID = Guid.Parse(txtName.Text);
            DialogResult = DialogResult.OK;
            if (nmPrice.Value == 0)
            {
                errorProvider1.SetError(nmPrice, "lütfen fiyat giriniz");
                nmPrice.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmPrice, "");
            }
            if (cbBuy.SelectedItem == null)
            {
                errorProvider1.SetError(cbBuy, "Ödeme Türü Seçiniz");
                cbBuy.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(cbBuy, "");
            }

            if (destription.Text == "")
            {
                errorProvider1.SetError(destription, "boş bırakılamaz.");
                destription.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(destription, "");
                return;

            }
        }
    }
}
