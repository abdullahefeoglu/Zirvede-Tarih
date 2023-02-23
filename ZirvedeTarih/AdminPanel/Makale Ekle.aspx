<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Makale Ekle.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.Makale_Ekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxContainer">
        <div style="height: 1000px;">
            <div class="begining">
                <h1>Makale Ekle</h1>
            </div>
            
            <div class="row">
                <label style="margin-left: 100px;">Kategoriler</label><br />
                <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="inputBox" AppendDataBoundItems="true" Style="width: 220px; margin-left: 100px;">
                    <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <br />
            <div class="row">
                <label>Makale Başlığı</label><br />
                <asp:TextBox ID="tb_baslik" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="row">
                <label>Makale Resim</label><br />
                <asp:FileUpload ID="fu_resim" runat="server"></asp:FileUpload>
            </div>
            <br />
            <br />
            <div class="row">
                <label>Yayın Durumu</label><br />
                <asp:CheckBox ID="cb_yayinda" runat="server" Text="Yayında" Style="font-size: 13pt;"></asp:CheckBox>
            </div>
            <br />
            <br />
            <div class="row">
                <label>Makale Özet</label><br />
                <asp:TextBox ID="tb_ozet" TextMode="MultiLine" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <br />
            <br />
            <div class="row">
                <label>Makale İçerik</label><br />
                <asp:TextBox ID="tb_icerik" TextMode="MultiLine" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Makale Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <br />
            <br />
            <div class="row">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="formbutton" OnClick="lbtn_ekle_Click">Makale Ekle</asp:LinkButton>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
