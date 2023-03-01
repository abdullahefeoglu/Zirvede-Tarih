<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YorumListele.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.YorumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxContainer">
        <div class="begining">
            <h1>Yorumların Listesi</h1>
        </div>
        <br />
        <br />
        <a href='YorumListele.aspx?yorumid=<%#Eval("ID") %>' class="bekleyen">Bekleyenler</a>
        <a href='OnaylananYorumlar.aspx?yorumid=<%#Eval("ID") %>' class="onay">Onaylananlar</a>
        <a href='ReddedilenYorumlar.aspx?yorumid=<%#Eval("ID") %>' class="red">Reddedilenler</a>
        <br />
        <br />
        <br />
        <asp:ListView ID="lv_yorumlar" runat="server" OnItemCommand="lv_yorumlar_ItemCommand">
            <LayoutTemplate>
                <table class="tablo" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Üye</th>
                            <th>Yönetici</th>
                            <th>Makale</th>
                            <th>Tarih</th>
                            <th>Beğeni</th>
                            <th>İçerik</th>
                            <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("ID") %></td>
                    <td><%#Eval("Uye") %></td>
                    <td><%#Eval("Yonetici") %></td>
                    <td><%#Eval("Makale") %></td>
                    <td><%#Eval("YorumTarih") %></td>
                    <td><%#Eval("YorumBegeni") %></td>
                    <td><%#Eval("YorumIcerik") %></td>
                    <td><%#Eval("YorumOnayStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_onayla" runat="server" CssClass="aktif" CommandArgument='<%#Eval("ID") %>' CommandName="onayla">Onayla</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_reddet" runat="server" CssClass="pasif" CommandArgument='<%#Eval("ID") %>' CommandName="redder">Onayla</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
