using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class Makale_Ekle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataTextField = "Isim";
            ddl_kategoriler.DataValueField = "ID";
            ddl_kategoriler.DataSource = dm.KategoriListele();
            ddl_kategoriler.DataBind();
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(tb_icerik.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(tb_ozet.Text.Trim()))
                    {
                        if (Convert.ToInt32(ddl_kategoriler.SelectedItem.Value) != 0)
                        {
                            Makale mak = new Makale();
                            Yonetici y = (Yonetici)Session["yonetici"];
                            mak.Yonetici_ID = y.ID;
                            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                            mak.Baslik = tb_baslik.Text;
                            mak.Ozet = tb_ozet.Text;
                            mak.Icerik = tb_icerik.Text;
                            mak.GoruntulemeSayisi = 0;
                            mak.EklemeTarihi = DateTime.Now;
                            mak.BegeniSayisi = 0;
                            mak.Yayinda = cb_yayinda.Checked;
                            if (fu_resim.HasFile)
                            {
                                FileInfo fi = new FileInfo(fu_resim.FileName);
                                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                                {
                                    string uzanti = fi.Extension;
                                    string isim = Guid.NewGuid().ToString();
                                    mak.Resim = isim + uzanti;
                                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + isim + uzanti));
                                    if (dm.MakaleEkle(mak))
                                    {
                                        pnl_basarili.Visible = true;
                                        pnl_basarisiz.Visible = false;
                                        tb_baslik.Text = "";
                                        tb_ozet.Text = "";
                                        tb_icerik.Text = "";
                                        cb_yayinda.Checked = false;
                                        ddl_kategoriler.SelectedValue = "0";
                                    }
                                    else
                                    {
                                        pnl_basarili.Visible = false;
                                        pnl_basarisiz.Visible = true;
                                        lbl_mesaj.Text = "Makale Eklenirken Bir Hata Oluştu";
                                    }
                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Resim Uzantısı Sadece .jpg veya .png Olmalıdır";
                                }
                            }
                            else
                            {
                                mak.Resim = "none.png";
                                if (dm.MakaleEkle(mak))
                                {
                                    pnl_basarili.Visible = true;
                                    pnl_basarisiz.Visible = false;
                                    tb_baslik.Text = "";
                                    tb_ozet.Text = "";
                                    tb_icerik.Text = "";
                                    cb_yayinda.Checked = false;
                                    ddl_kategoriler.SelectedValue = "0";
                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Makale Eklenirken Bir Hata Oluştu";
                                }
                            }
                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kategori seçimi yapmalısınız";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Özet Boş Bırakılamaz";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "İçerik Boş Bırakılamaz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Başlık Boş Bırakılamaz";
            }
        }
    }

}