using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] !=null)
            {
                Yonetici y = (Yonetici)Session["yonetici"];
                lbl_admin.Text = y.KullaniciAdi + " (admin) ";
            }
            else
            {
                Response.Redirect("Admin Giris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Admin Giris.aspx");
        }
    }
}