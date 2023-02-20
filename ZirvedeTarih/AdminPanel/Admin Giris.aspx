<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Giris.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.Admin_Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Zirvede Tarih</title>
    <link href="css/adminlogincss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="logo">
            LOGO EKLENECEK
        </div>
        <div class="loginBox">
            <div class="row">Admin Panel Girişi</div>
            
            <asp:TextBox ID="tb_mail" runat="server" CssClass="inputBox" placeholder="Mail Adresinizi Giriniz"></asp:TextBox>
            <br />
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="inputBox" placeholder="Şifrenizi Giriniz"></asp:TextBox>

            <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false">
                <asp:Label ID="lbl_hata" runat="server"></asp:Label>
            </asp:Panel>
            <br /><br />
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" CssClass="loginButton" OnClick="lbtn_giris_Click"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
