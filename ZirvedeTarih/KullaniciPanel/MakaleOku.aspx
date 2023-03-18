<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="Makaleoku.aspx.cs" Inherits="ZirvedeTarih.KullaniciPanel.Makaleoku" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assetss/css/kullaniciarayuz.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfa">
        <asp:Repeater ID="rp_makaleler" runat="server">
            <ItemTemplate>
                <div class="resim">
                    <a href='../MakaleResimleri/<%# Eval("Resim") %>' target="_blank">
                        <img src='../MakaleResimleri/<%# Eval("Resim") %>' /></a>
                </div>
                <div class="baslik">
                    <%#Eval("Baslik") %>
                    <div class="bilgi">
                        Yazar : <%#Eval("Yonetici") %> |
                    <img src="../ProjeResimleri/8665290_eye_vision_view_icon.png" style="width: 15px; height: 15px;" />
                        <%#Eval("GoruntulemeSayisi") %>
                    </div>
                </div>
                <div class="icerik">
                    <%# Eval("Icerik") %>
                </div>
                <div class="kategori">
                    <strong>Kategori : </strong><%# Eval("Kategori") %>
                    <br />
                    <strong>Kategori Açıklaması : </strong><%# Eval("kategoriAciklama") %>
                    <br />
                    <strong>Eklenme Tarihi : </strong><%# Eval("EklemeTarihi") %>
                </div>
                <hr />

                <br />
                <br />
            </ItemTemplate>
        </asp:Repeater>
        <div class="yorumPanel">
            <h2 class="yorumbaslik">Yorumlar</h2>
            <asp:Panel ID="pnl_girisvar" runat="server" CssClass="girisvar">
                <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="forminput"></asp:TextBox><br />
                <br />
                <asp:LinkButton ID="lbtn_yorumyap" runat="server" CssClass="formbutton" OnClick="lbtn_yorumyap_Click">Yorum Yap</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnl_girisyok" runat="server" CssClass="girisyok">
                Yorum Yapabilmek İçin Lütfen öncelikle
                <asp:LinkButton ID="lbtn_girisyonlendir" runat="server" OnClick="lbtn_girisyonlendir_Click">Giriş</asp:LinkButton>
                Yapınız.
            </asp:Panel>
            <asp:Panel ID="pnl_paylasildi" runat="server" CssClass="paylasildi" Visible="false">
                <label>Yorumunuz Paylaşıldı</label>
            </asp:Panel>
            <asp:Panel ID="pnl_paylasilmadi" runat="server" CssClass="paylasilmadi" Visible="false">
                <label>
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </label>
            </asp:Panel>
            <asp:Repeater ID="rp_yorumlar" runat="server">
                <ItemTemplate>
                    <div class="yorum">
                        <div class="yorumuye">
                            <strong>Üye : </strong>
                            <label ><%#Eval("Uye") %></label>&nbsp; | &nbsp; <%#Eval("YorumTarih") %><br />
                        </div>
                        <strong>Yorumu </strong>
                        <br />
                        <%# Eval("YorumIcerik") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
