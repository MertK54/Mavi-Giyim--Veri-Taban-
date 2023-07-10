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
    public partial class MusteriForm : Form
    {
        public MusteriForm()
        {
            InitializeComponent();
        }


        public Musteri Musteri { get; set; }
        public bool Güncelleme { get; internal set; } = false;
        private void btnOkey_Click(object sender, EventArgs e)
        {
            if(!ErrorControl(txtName)) return;
            if (!ErrorControl(txtSurname)) return;
            if (!ErrorControl(txtMail)) return;
            if (!ErrorControl(txtPhone)) return;
            if (!ErrorControl(txtAdress)) return;
            Musteri.Ad = txtName.Text;
            Musteri.Soyad = txtSurname.Text;
            Musteri.Telefon = txtPhone.Text;
            Musteri.Mail = txtMail.Text;
            Musteri.Adres = txtAdress.Text;
            DialogResult = DialogResult.OK;

        }
        private bool ErrorControl(Control c)
        {
            if(c is TextBox) 
            { 
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "boş bırakılamaz.");
                    c.Focus();
                    return false;
                }
                else
                {
                        errorProvider1.SetError(c, "");
                        return true;
                }
            }
            if (c is MaskedTextBox)
            {
                if (!((MaskedTextBox)c).MaskFull) 
                {
                    errorProvider1.SetError(c, "boş bırakılamaz.");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;
                }
            }
            return true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
             DialogResult = DialogResult.Cancel;
        }

        private void MusteriForm_Load(object sender, EventArgs e)
        {
            txtID.Text = Musteri.ID.ToString();
            if(Güncelleme)
            {
                txtName.Text = Musteri.Ad;
                txtSurname.Text = Musteri.Soyad;
                txtPhone.Text = Musteri.Telefon;
                txtMail.Text = Musteri.Mail;
                txtAdress.Text = Musteri.Adres;
            }
        }
    }
}
