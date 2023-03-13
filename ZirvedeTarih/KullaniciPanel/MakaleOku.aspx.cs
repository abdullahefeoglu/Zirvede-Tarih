using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.KullaniciPanel
{
    public partial class Makaleoku : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                dm.GoruntulemeArttir(id);
                Makale m = dm.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                ltrl_yazar.Text = m.Yonetici;
                ltrl_goruntulenmeSayisi.Text = m.GoruntulemeSayisi.ToString();
                ltrl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_aciklama.Text = m.kategoriAciklama;
                img_resim.ImageUrl = "MakaleResimleri/" + m.Resim;

                rp_yorumlar.DataSource = dm.YorumListele();
                rp_yorumlar.DataBind();
                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
            }
        }

        protected void lbtn_girisyonlendir_Click(object sender, EventArgs e)
        {
            Session["link"] = "MakaleOku.aspx?mid=" + Request.QueryString["mid"];
            Response.Redirect("UyeGiris.aspx");
        }
    }
}



