using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Kategori İşlemleri
        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim,kategoriAciklama,begeniSayisi,makaleSayisi) VALUES(@isim,@kategoriaciklama,@begenisayisi,@makalesayisi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@kategoriaciklama", kat.kategoriAciklama);
                cmd.Parameters.AddWithValue("@begeniSayisi",kat.begeniSayisi);
                cmd.Parameters.AddWithValue("@makalesayisi",kat.makaleSayisi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim, kategoriAciklama=@kategoriaciklama WHERE = ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@kategoriaciklama", kat.kategoriAciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT * FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim=reader.GetString(1);
                    k.kategoriAciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "Açıklama Girilmemiş";
                    k.begeniSayisi =reader.GetInt32(3);
                    k.makaleSayisi = reader.GetInt32(4);
                    kategoriler.Add(k);

                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                Kategori k = new Kategori();
                cmd.CommandText = "SELECT * FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.kategoriAciklama=reader.GetString(2);
                    
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim=@isim , kategoriAciklama=@kategoriaciklama WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("isim", kat.Isim);
                cmd.Parameters.AddWithValue("@kategoriaciklama", kat.kategoriAciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }
        }
        #endregion

        #region Yardımcılar
        public bool VeriControl(string tablo, string kolon, string veri)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM " + tablo + " WHERE " + kolon + " = @isim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", veri);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }
        #endregion

        #region Yönetici
        public Yonetici AdminGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail",mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi=Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 0)
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyad, KullaniciAdi, Mail, Sifre, Aktif FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyad = reader.GetString(2);
                        y.KullaniciAdi=reader.GetString(3);
                        y.Mail=reader.GetString(4);
                        y.Sifre=reader.GetString(5);
                        y.Aktif = reader.GetBoolean(6);

                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        #endregion

    }
}
