﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZirvedeTarih.KullaniciPanel
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.lbtn_login.UniqueID;
        }

        protected void lbtn_login_Click(object sender, EventArgs e)
        {
            Uye u = dm.UyeGiris(tb_eposta.Text, tb_sifre.Text);
            if (u != null)
            {
                Session["uye"] = u;
                if (Session["link"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Redirect(Session["link"].ToString());
                }
            }
            else
            {
                lbl_mesaj.Text = "Kullanıcı Bulunamadı";
            }
        }
    }
}
