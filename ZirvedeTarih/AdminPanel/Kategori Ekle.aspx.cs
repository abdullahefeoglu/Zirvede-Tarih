using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class Kategori_Ekle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_kategoriAciklama.Text.Trim()))
                {
                    if (dm.VeriControl("Kategoriler","Isim",tb_isim.Text.Trim()))
                    {
                        Kategori k = new Kategori();
                        k.Isim = tb_isim.Text;
                        k.kategoriAciklama = tb_kategoriAciklama.Text;
                        k.begeniSayisi = 0;
                        k.makaleSayisi = 0;
                        if (dm.KategoriEkle(k))
                        {
                            pnl_basarili.Visible = true;
                            pnl_basarisiz.Visible = false;
                            tb_isim.Text = "";
                            tb_kategoriAciklama.Text = "";

                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kategori Ekleme İşlemi Başarısız";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kategori Daha Önce Eklenmiş";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori Açıklaması Boş Bırakılamaz";
                }

            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kategori Adı Boş Bırakılamaz";
            }
        }
	}
    
}