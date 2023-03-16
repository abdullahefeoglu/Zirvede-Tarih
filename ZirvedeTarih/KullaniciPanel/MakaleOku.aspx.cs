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

                rp_yorumlar.DataSource = dm.YorumListele();
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
            
        }
    }
}



