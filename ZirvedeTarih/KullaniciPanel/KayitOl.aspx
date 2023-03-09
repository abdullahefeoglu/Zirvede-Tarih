<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="ZirvedeTarih.KullaniciPanel.KayitOl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assetss/css/kullanicipanel.css" rel="stylesheet" />
</head>
<body style="background-color:aqua; font-family:Trebuchet MS;">
    <form id="form1" runat="server">
        <div class="kayitFormu">
            <div class="kayit">
                <h2>KULLANICI KAYIT FORMU</h2>
            </div>
            <div>
                <asp:TextBox ID="tb_isim" runat="server" CssClass="input" placeholder="İsim"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="input" placeholder="Kullanıcı Adı"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tb_eposta" runat="server" CssClass="input" placeholder="E-postanız"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="input" TextMode="Password" placeholder="Şifre"></asp:TextBox>
            </div><br />
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kayıt Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel><br /><br />
            <div>
                <asp:LinkButton ID="lbtn_login" runat="server" CssClass="loginbutton" OnClick="lbtn_login_Click">Kayıt Ol</asp:LinkButton>
            </div><br /><br />
            <a href="Default.aspx" class="don">Anasayfaya Dön</a>
        </div>
    </form>
</body>
</html>
