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
                dm.GoruntulenmeArttir(id);
                Makale m = dm.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                ltrl_goruntuleme.Text = m.GoruntulemeSayisi.ToString();
                ltrl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_yazar.Text = m.Yonetici;
                img_resim.ImageUrl = "MakaleResimleri/" + m.Resim;
            }
	}
}