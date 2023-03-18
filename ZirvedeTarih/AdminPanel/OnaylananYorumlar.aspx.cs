using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class OnaylananYorumlar : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();
        }

        protected void lv_yorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "reddet")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.YorumReddet(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();

            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.YorumSil(id);
            }
            lv_yorumlar.DataSource = dm.YorumListele(true);
            lv_yorumlar.DataBind();
        }
    }
}