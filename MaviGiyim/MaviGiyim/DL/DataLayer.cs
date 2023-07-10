using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaviGiyim.DL;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaviGiyim.DL
{
    public static class DataLayer
    {
        static MySqlConnection conn = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server = "localhost",
                Database = "mavi_db",
                UserID = "root",
                Password = "Karakartal54",
            }.ConnectionString
            );
        public static int MüşteriEkle(Musteri m)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_MusteriEkle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", m.ID);
                cmd.Parameters.AddWithValue("@ad", m.Ad);
                cmd.Parameters.AddWithValue("@soy", m.Soyad);
                cmd.Parameters.AddWithValue("@tel", m.Telefon);
                cmd.Parameters.AddWithValue("@mail", m.Mail);
                cmd.Parameters.AddWithValue("@adr", m.Adres);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet MüşteriGetir(string filtre)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd;
                if (string.IsNullOrEmpty(filtre))
                {
                    cmd = new MySqlCommand("mavi_MusteriHepsi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = new MySqlCommand("mavi_MusteriGetir", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtre", filtre);
                }
                DataSet dataset = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset);
                return dataset;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int MüşteriGüncelle(Musteri musteri)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_MusteriGuncelle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", musteri.ID);
                cmd.Parameters.AddWithValue("@ad", musteri.Ad);
                cmd.Parameters.AddWithValue("@soy", musteri.Soyad);
                cmd.Parameters.AddWithValue("@tel", musteri.Telefon);
                cmd.Parameters.AddWithValue("@mail", musteri.Mail);
                cmd.Parameters.AddWithValue("@adr", musteri.Adres);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int MüşteriSil(Guid id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_MusteriSil", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }



        internal static int UrunEkle(Urun urun)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_UrunEkle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", urun.ID);
                cmd.Parameters.AddWithValue("@ad", urun.Ad);
                cmd.Parameters.AddWithValue("@kategori", urun.Kategori);
                cmd.Parameters.AddWithValue("@fiyat", urun.Fiyat);
                cmd.Parameters.AddWithValue("@stok", urun.Stok);
                cmd.Parameters.AddWithValue("@birim", urun.Birim);
                cmd.Parameters.AddWithValue("@detay", urun.Detay);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet UrunGetir(string filtre)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd;
                if (string.IsNullOrEmpty(filtre))
                {
                    cmd = new MySqlCommand("mavi_UrunlerHepsi", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    cmd = new MySqlCommand("mavi_UrunBul", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@filtre", filtre);
                }
                DataSet dataset = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset);
                return dataset;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int UrunGüncelle(Urun urun)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_UrunGuncelle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", urun.ID);
                cmd.Parameters.AddWithValue("@ad", urun.Ad);
                cmd.Parameters.AddWithValue("@kategori", urun.Kategori);
                cmd.Parameters.AddWithValue("@fiyat", urun.Fiyat);
                cmd.Parameters.AddWithValue("@stok", urun.Stok);
                cmd.Parameters.AddWithValue("@birim", urun.Birim);
                cmd.Parameters.AddWithValue("@detay", urun.Detay);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int UrunSil(Guid ıD)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_UrunSil", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ıD);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int SatisSil(Guid ıD)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_SatisSil", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ıD);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int SatisEkle(Satis satis)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_SatisEkle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", satis.ID);
                cmd.Parameters.AddWithValue("@mid", satis.MusteriID);
                cmd.Parameters.AddWithValue("@uid", satis.UrunID);
                cmd.Parameters.AddWithValue("@tarih", satis.Tarih);
                cmd.Parameters.AddWithValue("@fiyat", satis.Fiyat);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet SatisDetay()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_SatisDetay", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DataSet dataset = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset);
                return dataset;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int SatisGuncelle(Satis satis)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_SatisGuncelle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", satis.ID);
                cmd.Parameters.AddWithValue("@mid", satis.MusteriID);
                cmd.Parameters.AddWithValue("@uid", satis.UrunID);
                cmd.Parameters.AddWithValue("@tarih", satis.Tarih);
                cmd.Parameters.AddWithValue("@fiyat", satis.Fiyat);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int OdemeEkle(Odeme odeme)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_OdemeEkle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oid", odeme.ID);
                cmd.Parameters.AddWithValue("@mid", odeme.MusteriID);
                cmd.Parameters.AddWithValue("@tarih", odeme.Tarih);
                cmd.Parameters.AddWithValue("@tutar", odeme.Fiyat);
                cmd.Parameters.AddWithValue("@tur", odeme.Tur);
                cmd.Parameters.AddWithValue("@aciklama", odeme.Aciklama);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet OdemeDetay()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_OdemeDetay", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                DataSet dataset = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset);
                return dataset;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int OdemeGuncelle(Odeme odeme)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_OdemeGuncelle", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oid", odeme.ID);
                cmd.Parameters.AddWithValue("@mid", odeme.MusteriID);
                cmd.Parameters.AddWithValue("@tarih", odeme.Tarih);
                cmd.Parameters.AddWithValue("@tutar", odeme.Fiyat);
                cmd.Parameters.AddWithValue("@tur", odeme.Tur);
                cmd.Parameters.AddWithValue("@aciklama", odeme.Aciklama);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int OdemeSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();
                MySqlCommand cmd = new MySqlCommand("mavi_OdemeSil", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oid", id);
                int res = cmd.ExecuteNonQuery();
                return res;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
