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
                cmd.Parameters.AddWithValue("@begeniSayisi", kat.begeniSayisi);
                cmd.Parameters.AddWithValue("@makalesayisi", kat.makaleSayisi);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            { return false; }
            finally { con.Close(); }
        }
        public bool AltKategoriEkle(AltKategori ak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO AltKategoriler(Isim, Kategoriler_ID) VALUES(@isim, @kategoriler_ID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", ak.Isim);
                cmd.Parameters.AddWithValue("@kategoriler_ID", ak.Kategoriler_ID);
                con.Open();
                cmd.ExecuteReader();
                return true;
            }
            catch
            {
                return false;
            }
            finally { con.Close(); }

        }
        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim,  kategoriAciklama=@kategoriaciklama WHERE = ID=@id";
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
                    k.Isim = reader.GetString(1);
                    k.kategoriAciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "Açıklama Girilmemiş";
                    k.begeniSayisi = reader.GetInt32(3);
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
                    k.kategoriAciklama = reader.GetString(2);

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
        #endregion

        #region Makale İşlemleri
        public bool MakaleEkle(Makale mak)
        {
            try
            {

                cmd.CommandText = "INSERT INTO Makaleler(Yonetici_ID, Kategori_ID, Baslik, Ozet, Icerik, Resim, GoruntulenmeSayisi, EklemeTarihi, BeğeniSayisi, Yayında) \r\nVALUES(@yonetici_ID, @kategori_ID, @baslik, @ozet, @icerik, @resim, @goruntulenmesayisi, @eklemetarihi, @begenisayisi, @yayinda)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yonetici_ID", mak.Yonetici_ID);
                cmd.Parameters.AddWithValue("@kategori_ID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@resim", mak.Resim);
                cmd.Parameters.AddWithValue("@goruntulenmesayisi", mak.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@eklemetarihi", mak.EklemeTarihi);
                cmd.Parameters.AddWithValue("@begenisayisi", mak.BegeniSayisi);
                cmd.Parameters.AddWithValue("@yayinda", mak.Yayinda);
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
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi > 0)
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
                        y.KullaniciAdi = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
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

        #region Uyeler
        public bool UyeBanla(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Uyeler SET Aktif = 0 WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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
        public bool UyeBanKaldir(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Uyeler SET Aktif = 1 WHERE ID =@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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
        public List<Uye> UyeListele(int id)
        {
            List<Uye> uyeler = new List<Uye>();
            try
            {
                cmd.CommandText = "SELECT * FROM Uyeler WHERE Aktif=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.KullaniciAdi = reader.GetString(2);
                    u.Sifre = reader.GetString(3);
                    u.KatılımTarihi = reader.GetDateTime(4);
                    u.YorumSayisi = reader.GetInt32(5);
                    u.Aktif = reader.GetBoolean(6);
                    u.AktifStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        public List<Uye> UyeListele()
        {
            List<Uye> uyeler = new List<Uye>();
            try
            {
                cmd.CommandText = "SELECT * FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.KullaniciAdi = reader.GetString(2);
                    u.Sifre = reader.GetString(3);
                    u.KatılımTarihi = reader.GetDateTime(4);
                    u.YorumSayisi = reader.GetInt32(5);
                    u.Aktif = reader.GetBoolean(6);
                    u.AktifStr = reader.GetBoolean(6) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    uyeler.Add(u);
                }
                return uyeler;
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
