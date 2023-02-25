using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class PasifUyeler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_uyeler.DataSource = dm.UyeListele(0);
            lv_uyeler.DataBind();
        }

        protected void lv_uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "bankaldir")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.UyeBanKaldir(id);
            }
            lv_uyeler.DataSource = dm.UyeListele(0);
            lv_uyeler.DataBind();
        }
    }
}