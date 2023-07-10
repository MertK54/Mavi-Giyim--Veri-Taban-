using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaviGiyim.DL;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaviGiyim.Bl
{
    public static class BLogic
    {
        public static bool MüşteriEkle(Musteri m)
        {
            try
            {
                int result = DataLayer.MüşteriEkle(m);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" +ex.Message);
                return false;
            }
            
        }

        internal static DataSet MüşteriGetir(string filtre)
        {
            try
            {
                DataSet ds = DataLayer.MüşteriGetir(filtre);
                return ds;
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return null;
            }
        }

        internal static bool MüşteriGüncelle(Musteri musteri)
        {
            try
            {
                int result = DataLayer.MüşteriGüncelle(musteri);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static bool MüşteriSil(Guid id)
        {
            try
            {
                int result = DataLayer.MüşteriSil(id);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        

        internal static bool UrunEkle(Urun urun)
        {
            try
            {
                int result = DataLayer.UrunEkle(urun);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static DataSet UrunGetir(string v)
        {
            try
            {
                DataSet ds = DataLayer.UrunGetir(v);
                return ds;
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return null;
            }
        }

        internal static bool UrunGüncelle(Urun urun)
        {
            try
            {
                int result = DataLayer.UrunGüncelle(urun);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static bool UrunSil(Guid ıD)
        {
            try
            {
                int result = DataLayer.UrunSil(ıD);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }
        internal static bool SatisEkle(Satis satis)
        {
            try
            {
                int result = DataLayer.SatisEkle(satis);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static DataSet SatisDetay()
        {
            try
            {
                DataSet ds = DataLayer.SatisDetay();
                return ds;
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return null;
            }
        }

        internal static bool SatisGuncelle(Satis satis)
        {
            try
            {
                int result = DataLayer.SatisGuncelle(satis);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static bool SatisSil(Guid ıD)
        {
            try
            {
                int result = DataLayer.SatisSil(ıD);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static bool OdemeEkle(Odeme odeme)
        {
            try
            {
                int result = DataLayer.OdemeEkle(odeme);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static DataSet OdemeDetay()
        {
            try
            {
                DataSet ds = DataLayer.OdemeDetay();
                return ds;
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return null;
            }
        }

        internal static bool OdemeGuncelle(Odeme odeme)
        {
            try
            {
                int result = DataLayer.OdemeGuncelle(odeme);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }

        internal static bool OdemeSil(string id)
        {
            try
            {
                int result = DataLayer.OdemeSil(id);
                return (result > 0);
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata :" + ex.Message);
                return false;
            }
        }
    }  
}
