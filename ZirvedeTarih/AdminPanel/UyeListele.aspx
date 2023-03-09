<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="ZirvedeTarih.UyeListele" %>

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
        <br />
        <asp:ListView ID="lv_uyeler" runat="server" OnItemCommand="lv_uyeler_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0" style="border: 2px solid black;">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>KullaniciAdi</th>
                            <th>E-posta</th>
                            <th>KatılımTarihi</th>
                            <th>YorumSayisi</th>
                            <th>Durum</th>
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
                    <td><%#Eval("Eposta") %></td>
                    <td><%#Eval("KatılımTarihi") %></td>
                    <td><%#Eval("YorumSayisi") %></td>
                    <td><%#Eval("AktifStr") %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
