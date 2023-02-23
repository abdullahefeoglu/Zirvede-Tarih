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
    }
    
}