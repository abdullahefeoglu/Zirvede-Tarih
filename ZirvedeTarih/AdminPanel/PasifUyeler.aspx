<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="PasifUyeler.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.PasifUyeler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="boxContainer">
        <div class="begining">
            <h1>Üyelerin Listesi</h1>
        </div>
        <br />
        <br />
        <a href='AktifUyeler.aspx?uyeid=<%#Eval("ID") %>' class="aktif">Aktif Üyeler</a>
        <a href='PasifUyeler.aspx?uyeid<%#Eval("ID") %>' class="pasif">Pasif Üyeler</a>
        <br />
        <br />
        <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>KullaniciAdi</th>
                            <th>KatılımTarihi</th>
                            <th>YorumSayisi</th>
                            <th>Aktif</th>
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
                    <td><%#Eval("KullaniciAdi") %></td>
                    <td><%#Eval("KatılımTarihi") %></td>
                    <td><%#Eval("YorumSayisi") %></td>
                    <td><%#Eval("Aktif") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_bankaldir" runat="server" CssClass="bankaldir" CommandArgument='<%#Eval("ID") %>' CommandName="bankaldir">Aktif Et</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
