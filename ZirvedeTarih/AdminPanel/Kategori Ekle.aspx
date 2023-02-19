<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Kategori Ekle.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.Kategori_Ekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxContainer">
        <div class="begining">
            <h1>Kategori Ekle</h1>
        </div>
            <div class="row">
                <label>Kategorinin İsmi</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="inputBox"></asp:TextBox>
            </div><br /><br />
            <div class="row">
                <label>Kategorinin Açıklaması</label><br />
                <asp:TextBox ID="tb_kategoriAciklama" runat="server" CssClass="inputBox"></asp:TextBox>
            </div>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kategori Eklendi
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="row"><br />
                <asp:LinkButton ID="lbtn_ekle" runat="server" Text="Kategori Ekle" CssClass="formbutton" OnClick="lbtn_ekle_Click"></asp:LinkButton>
            </div>
        </div>
</asp:Content>
