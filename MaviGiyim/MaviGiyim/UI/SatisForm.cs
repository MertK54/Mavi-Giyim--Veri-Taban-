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
    public partial class SatisForm : Form
    {
        public SatisForm()
        {
            InitializeComponent();
        }


        public Satis Satis { get; set; }
        public bool Güncelleme { get;set; }=false;
        private void SatisForm_Load(object sender, EventArgs e)
        {
            txtID.Text = Satis.ID.ToString();
            if(Güncelleme)
            {
                txtName.Text = Satis.MusteriID.ToString();
                tbProduct.Text = Satis.UrunID.ToString();
                nmPrice.Value = (decimal)Satis.Fiyat;
                tdDate.Value = Satis.Tarih;
            }
        }
        private void btnOkey_Click(object sender, EventArgs e)
        {
            if(nmPrice.Value == 0)
            {
                errorProvider1.SetError(nmPrice, "lütfen fiyat giriniz");
                nmPrice.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmPrice, "");
            }
            Satis.Tarih = tdDate.Value;
            Satis.Fiyat = (double)nmPrice.Value;
            Satis.UrunID = Guid.Parse(tbProduct.Text);
            Satis.MusteriID = Guid.Parse(txtName.Text);
            Satis.ID= Satis.ID;
            DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            Müşteriler frm = new Müşteriler();
            if(frm.ShowDialog() == DialogResult.OK) 
            {
                    txtName.Text = frm.Musteri.ID.ToString();
            }
        }

        private void btnUrunSec_Click(object sender, EventArgs e)
        {
            Ürünler frm = new Ürünler();
            if (frm.ShowDialog() == DialogResult.OK) 
            { 
                tbProduct.Text = frm.Urun.ID.ToString();
            }
        }
    }
}
