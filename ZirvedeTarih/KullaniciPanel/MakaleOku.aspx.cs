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
                rp_makaleler.DataSource = dm.MakaleListele(id);
                rp_makaleler.DataBind();

                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();

                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = false;
                    pnl_girisyok.Visible = true;
                }
            }
            else
            {
                 Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_girisyonlendir_Click(object sender, EventArgs e)
        {
            Session["link"] = "MakaleOku.aspx?mid=" + Request.QueryString["mid"];
            Response.Redirect("UyeGiris.aspx");
        }

        protected void lbtn_yorumyap_Click(object sender, EventArgs e)
        {
            Yorum y = new Yorum();  
            Uye u = (Uye)Session["uye"];
            y.Uye_ID = u.ID;
            y.YorumIcerik = tb_yorum.Text;
            if (!string.IsNullOrEmpty(tb_yorum.Text.Trim()))
            {
                try
                {
                    int id = Convert.ToInt32(Request.QueryString["mid"]);
                    y.Makale_ID = id;
                    y.YorumIcerik = tb_yorum.Text;
                    y.YorumTarih = DateTime.Today;
                    pnl_paylasildi.Visible = true;
                    pnl_paylasilmadi.Visible = false;
                    dm.YorumEkle(y);
                    tb_yorum.Text = " ";
                }
                catch
                {
                    pnl_paylasildi.Visible = false;
                    pnl_paylasilmadi.Visible = true;
                    lbl_mesaj.Text = "Yorumun paylaşılırken bir hata oluştu";
                }
            }
            else
            {
                pnl_paylasildi.Visible = false;
                pnl_paylasilmadi.Visible = true;
                lbl_mesaj.Text = "Yorum alanı doldurulmalıdır";
            }
        }
    }
}



