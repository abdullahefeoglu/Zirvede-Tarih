using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.AdminPanel
{
    public partial class Kategori_Duzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                    Kategori k = dm.KategoriGetir(id);
                    if (k != null && k.Isim != null && k.kategoriAciklama != null)
                    {
                        tb_isim.Text = k.Isim;
                        tb_kategoriAciklama.Text = k.kategoriAciklama;
                    }
                    else
                    {
                        Response.Redirect("KategoriListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Kategori Listele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori();
            k.ID = Convert.ToInt32(Request.QueryString["kategoriid"]);
            k.Isim = tb_isim.Text;
            k.kategoriAciklama = tb_kategoriAciklama.Text;
            if (dm.KategoriGuncelle(k))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kategori Güncelleme İşlemi Başarısız";
            }
        }
    }
}