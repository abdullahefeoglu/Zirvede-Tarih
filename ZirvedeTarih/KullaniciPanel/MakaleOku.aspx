<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="Makaleoku.aspx.cs" Inherits="ZirvedeTarih.KullaniciPanel.Makaleoku" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Image ID="img_resim" runat="server" />
        <div class="baslik">
            <h2>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            </h2>
        </div>
        <div class="bilgi">
            Yazar :
            <asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>
            | Kategori :
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Görüntüleme :
            <asp:Literal ID="ltrl_goruntuleme" runat="server"></asp:Literal>
        </div>
        <div class="icerik">
             <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
             <div style="height:20px;"></div>
        </div>
        <hr />

    </div>
</asp:Content>
