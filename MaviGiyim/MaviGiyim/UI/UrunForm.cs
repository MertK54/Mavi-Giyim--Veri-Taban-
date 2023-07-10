using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MaviGiyim.UI
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public Urun Urun{ get; set; }
        public bool Güncelleme { get; internal set; } = false;

        private void btnOkey_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtUrun)) return;
            if (!ErrorControl(cbCat)) return;
            if (!ErrorControl(nmPrice)) return;
            if (!ErrorControl(nmStock)) return;
            if (!ErrorControl(cbUnit)) return;
            if (!ErrorControl(destription)) return;
            Urun.Ad = txtUrun.Text;
            Urun.Kategori = cbCat.Text;
            Urun.Fiyat = (double)nmPrice.Value;
            Urun.Stok = (double)nmStock.Value;
            Urun.Birim = cbUnit.Text;
            Urun.Detay = destription.Text;
            DialogResult = DialogResult.OK;

        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorProvider1.SetError(c, "Bu alan boş bırakılamaz.");
                    textBox.Focus();
                    return false;
                }
            }
            else if (c is ComboBox comboBox)
            {
                if (comboBox.SelectedItem == null)
                {
                    errorProvider1.SetError(c, "Bu alan boş bırakılamaz.");
                    comboBox.Focus();
                    return false;
                }
            }
            else if (c is NumericUpDown numericUpDown)
            {
                if (numericUpDown.Value == 0)
                {
                    errorProvider1.SetError(c, "Bu alan boş bırakılamaz.");
                    numericUpDown.Focus();
                    return false;
                }
            }

            errorProvider1.SetError(c, ""); // Hata yok, mesajı temizle
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UrunForm_Load(object sender, EventArgs e)
        {
            txtID.Text = Urun.ID.ToString();
            if (Güncelleme)
            {
                txtUrun.Text = Urun.Ad;
                cbCat.Text= Urun.Kategori;
                nmPrice.Value = (decimal)Urun.Fiyat;
                nmStock.Value = (decimal)Urun.Stok;
                cbUnit.Text = Urun.Birim;
                destription.Text = Urun.Detay;
            }
        }
    }
}
