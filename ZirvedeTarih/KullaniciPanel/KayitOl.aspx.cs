using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.KullaniciPanel
{
    public partial class KayitOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbtn_kayit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_kullaniciadi.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(tb_eposta.Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(tb_sifre.Text.Trim()))
                        {
                            Uye u = new Uye();
                            u.Isim = tb_isim.Text;
                            u.KullaniciAdi = tb_kullaniciadi.Text;
                            u.Eposta = tb_eposta.Text;
                            u.Sifre = tb_sifre.Text;
                            u.KatılımTarihi = DateTime.Now;
                            u.YorumSayisi = 0;
                            u.Aktif = true;
                            if (dm.UyeEkle(u))
                            {
                                pnl_basarili.Visible = true;
                                pnl_basarisiz.Visible = false;
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Kayıt Olurken Bir Hata Oluştu";
                            }
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Şifre Boş Bırakılamaz";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "E-posta Boş Bırakılamaz";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı Adı Boş Bırakılamaz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "İsim Boş Bırakılamaz";
            }
        }
    }
}