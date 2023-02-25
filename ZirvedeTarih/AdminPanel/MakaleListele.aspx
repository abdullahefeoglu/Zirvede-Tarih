﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.MakaleListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxContainer">
        <div class="begining">
            Makalelerin Listesi
        </div>
        <asp:ListView ID="lv_makaleler" runat="server" OnItemCommand="lv_makaleler_ItemCommand">
            <LayoutTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Resim</th>
                            <th>ID</th>
                            <th>Başlık</th>
                            <th>Kategori</th>
                            <th>Yonetici</th>
                            <th>Görüntülenme Sayısı</th>
                            <th>Ekleme Tarihi</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody><asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder></tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td></td<img src="../MakaleResimleri/<%# Eval("Resim") %>" width="50" />
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Kategori") %></td>
                    <td><%#Eval("Baslik") %></td>
                    <td><%#Eval("Yonetici") %></td>
                    <td><%#Eval("GoruntulemeSayisi") %></td>
                    <td><%#Eval("EklemeTarihStr") %></td>
                    <td><%#Eval("YayindaStr") %></td>
                    <td><a href='MakaleDuzenle.aspx?mid=<%# Eval("ID") %>' class="duzenle">Düzenle</a>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>