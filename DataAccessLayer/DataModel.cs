using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> Makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, K.kategoriAciklama, M.Yonetici_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.Resim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.BeğeniSayisi, M.Yayında FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yonetici_ID = Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.kategoriAciklama = reader.GetString(3);
                    m.Yonetici_ID = reader.GetInt32(4);
                    m.Yonetici = reader.GetString(5);
                    m.Baslik = reader.GetString(6);
                    m.Ozet = reader.GetString(7);
                    m.Icerik = reader.GetString(8);
                    m.Resim = reader.GetString(9);
                    m.GoruntulemeSayisi = reader.GetInt32(10);
                    m.EklemeTarihi = reader.GetDateTime(11);
                    m.EklemeTarihStr = reader.GetDateTime(11).ToShortDateString();
                    m.BegeniSayisi = reader.GetInt32(12);
                    m.Yayinda = reader.GetBoolean(13);
                    m.YayindaStr = reader.GetBoolean(13) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    Makaleler.Add(m);
                }
                return Makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Makale> MakaleListele(int kid, bool durum)
        {
            try
            {
                List<Makale> Makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, K.kategoriAciklama, M.Yonetici_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.Resim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.BeğeniSayisi, M.Yayında FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yonetici_ID = Y.ID WHERE M.Kategori_ID=@kategori_ID AND M.Yayinda=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", durum);
                cmd.Parameters.AddWithValue("@kategori_ID", kid);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.kategoriAciklama = reader.GetString(3);
                    m.Yonetici_ID = reader.GetInt32(4);
                    m.Yonetici = reader.GetString(5);
                    m.Baslik = reader.GetString(6);
                    m.Ozet = reader.GetString(7);
                    m.Icerik = reader.GetString(8);
                    m.Resim = reader.GetString(9);
                    m.GoruntulemeSayisi = reader.GetInt32(10);
                    m.EklemeTarihi = reader.GetDateTime(11);
                    m.EklemeTarihStr = reader.GetDateTime(11).ToShortDateString();
                    m.BegeniSayisi = reader.GetInt32(12);
                    m.Yayinda = reader.GetBoolean(13);
                    m.YayindaStr = reader.GetBoolean(13) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    Makaleler.Add(m);
                }
                return Makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE Yorumlar WHERE Makale_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE Makaleler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Makale MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.Kategori_ID, K.Isim, K.kategoriAciklama M.Yonetici_ID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.Resim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.BeğeniSayisi, M.Yayında FROM Makaleler AS M JOIN Kategoriler AS K ON M.Kategori_ID = K.ID JOIN Yoneticiler AS Y ON M.Yonetici_ID = Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                Makale m = new Makale();
                while (reader.Read())
                {
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.kategoriAciklama = reader.GetString(3);
                    m.Yonetici_ID = reader.GetInt32(4);
                    m.Yonetici = reader.GetString(5);
                    m.Baslik = reader.GetString(6);
                    m.Ozet = reader.GetString(7);
                    m.Icerik = reader.GetString(8);
                    m.Resim = reader.GetString(9);
                    m.GoruntulemeSayisi = reader.GetInt32(10);
                    m.EklemeTarihi = reader.GetDateTime(11);
                    m.EklemeTarihStr = reader.GetDateTime(11).ToShortDateString();
                    m.BegeniSayisi = reader.GetInt32(12);
                    m.Yayinda = reader.GetBoolean(13);
                    m.YayindaStr = reader.GetBoolean(13) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                }
                return m;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool MakaleDuzenle(Makale m)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET Baslik = @baslik, Kategori_ID = kategori_ID, Ozet = @ozet, Icerik = @icerik, Resim = @resim, Yayında = @yayinda WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", m.ID);
                cmd.Parameters.AddWithValue("@baslik", m.Baslik);
                cmd.Parameters.AddWithValue("@kategori_ID", m.Kategori_ID);
                cmd.Parameters.AddWithValue("@ozet", m.Ozet);
                cmd.Parameters.AddWithValue("@icerik", m.Icerik);
                cmd.Parameters.AddWithValue("@resim", m.Resim);
                cmd.Parameters.AddWithValue("@yayinda", m.Yayinda);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
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
                    u.Eposta = reader.GetString(3);
                    u.Sifre = reader.GetString(4);
                    u.KatılımTarihi = reader.GetDateTime(5);
                    u.YorumSayisi = reader.GetInt32(6);
                    u.Aktif = reader.GetBoolean(7);
                    u.AktifStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
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
                    u.Eposta = reader.GetString(3);
                    u.Sifre = reader.GetString(4);
                    u.KatılımTarihi = reader.GetDateTime(5);
                    u.YorumSayisi = reader.GetInt32(6);
                    u.Aktif = reader.GetBoolean(7);
                    u.AktifStr = reader.GetBoolean(7) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
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
        public bool UyeEkle(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, KullaniciAdi, Eposta, Sifre, KatılımTarihi, YorumSayisi, Aktif) VALUES(@isim, @kullaniciadi, @eposta, @sifre, @katilimtarihi, @yorumsayisi, @aktif)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", u.Isim);
                cmd.Parameters.AddWithValue("@kullaniciadi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@eposta", u.Eposta);
                cmd.Parameters.AddWithValue("@sifre", u.Sifre);
                cmd.Parameters.AddWithValue("@katilimtarihi", u.KatılımTarihi);
                cmd.Parameters.AddWithValue("@yorumsayisi", u.YorumSayisi);
                cmd.Parameters.AddWithValue("@aktif", u.Aktif);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }

        public Uye UyeGiris(string eposta, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Eposta=@eposta AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eposta", eposta);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Eposta=@eposta AND Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@eposta", eposta);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.KullaniciAdi = reader.GetString(2);
                        u.Eposta = reader.GetString(3);
                        u.Sifre = reader.GetString(4);
                        u.Aktif = reader.GetBoolean(7);
                    }
                    return u;
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

        #region Yorumlar
        public bool YorumOnayla(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Yorumlar SET Aktiflik = 1 Where ID = @id";
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
        public bool YorumReddet(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Yorumlar SET Aktiflik = 0 Where ID = @id";
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
        public List<Yorum> YorumListele(int id)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.Uye_ID,U.KullaniciAdi, Y.Makale_ID, M.Baslik, Y.YorumIcerik, Y.YorumTarih, Y.YorumBegeni, Y.Aktiflik FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID = U.ID JOIN Makaleler AS M ON Y.Makale_ID = M.ID WHERE Y.Aktiflik = @aktiflik";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@aktiflik", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.Uye_ID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.Makale_ID = reader.GetInt32(3);
                    y.Makale = reader.GetString(4);
                    y.YorumIcerik = reader.GetString(5);
                    y.YorumTarih = reader.GetDateTime(6);
                    y.YorumBegeni = reader.GetInt32(7);
                    y.Aktiflik = reader.GetBoolean(8);
                    y.AktiflikStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.Uye_ID,U.KullaniciAdi, Y.Makale_ID, M.Baslik, Y.YorumIcerik, Y.YorumTarih, Y.YorumBegeni, Y.Aktiflik FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID = U.ID JOIN Makaleler AS M ON Y.Makale_ID = M.ID";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.Uye_ID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.Makale_ID = reader.GetInt32(3);
                    y.Makale = reader.GetString(4);
                    y.YorumIcerik = reader.GetString(5);
                    y.YorumTarih = reader.GetDateTime(6);
                    y.YorumBegeni = reader.GetInt32(7);
                    y.Aktiflik = reader.GetBoolean(8);
                    y.AktiflikStr = reader.GetBoolean(8) ? "<label style='color:green'>Aktif</label>" : "<label style='color:red'>Pasif</label>";
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }
    
}



