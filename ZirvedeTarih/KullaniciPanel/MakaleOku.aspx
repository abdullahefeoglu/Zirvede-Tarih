<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="Makaleoku.aspx.cs" Inherits="ZirvedeTarih.KullaniciPanel.Makaleoku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assetss/css/kullaniciarayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaMakale">
        <asp:Image ID="img_resim" runat="server" />
        <div class="mbaslik">
            <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            <div class="mbilgi">
                Yazar :
                <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
                <img src="../ProjeResimleri/8665290_eye_vision_view_icon.png" style="width: 15px; height: 15px;" />
                <asp:Literal ID="ltrl_goruntulenmeSayisi" runat="server"></asp:Literal>
            </div>
        </div>
        <div class="micerik">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
        </div>
        <div class="mkategori">
            Kategori :
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal><br />
            Kategori Açıklaması :
            <asp:Literal ID="ltrl_aciklama" runat="server"></asp:Literal>
        </div>
    </div>
    <hr />
    <div class="yorumPanel">
        <div class="begining">
            Yorumlar
        </div>
        <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar" >
            <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="forminput"></asp:TextBox>
            <br /><br />
            <asp:LinkButton ID="lbtn_yorumYap" runat="server" CssClass="formbutton">Yorum Yap</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="pnl_girisyok" runat="server" CssClass="girisyok">
            Yorum Yapabilmek İçin Lütfen öncelikle <asp:LinkButton ID="lbtn_girisyonlendir" runat="server" OnClick="lbtn_girisyonlendir_Click">Giriş</asp:LinkButton> yapınız.
        </asp:Panel>
        <div class="begining">
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorum">
                        Üye : <label class="yorumUye"><%#Eval("Uye") %></label><br />
                        <%#Eval("YorumIcerik") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <hr />
</asp:Content>
