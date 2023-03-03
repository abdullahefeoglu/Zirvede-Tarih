using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class YorumListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "reddet")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.YorumReddet(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();

            if (e.CommandName == "onayla")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.YorumOnayla(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele();
            lv_yorumlar.DataBind();
        }
    }
}