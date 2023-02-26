<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Kategori Listele.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.Kategori_Listele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxContainer">
        <div class="begining">
            <h1>Kategorilerin Listesi</h1>
        </div>

        <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Alt Kategori</th>
                            <th>Kategorinin Açıklaması</th>
                            <th>Beğeni</th> 
                            <th>Makale</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Isim") %></td>
                    <td><%#Eval("Isim") %></td>
                    <td><%#Eval("kategoriAciklama") %></td>
                    <td><%#Eval("begeniSayisi") %></td>
                    <td><%#Eval("makaleSayisi") %></td>
                    <td>
                        <a href='Kategori Duzenle.aspx?kategoriid=<%#Eval("ID") %>' class="duzenle">Düzenle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%#Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
