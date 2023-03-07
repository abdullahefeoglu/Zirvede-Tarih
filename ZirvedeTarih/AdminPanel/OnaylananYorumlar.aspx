<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMaster.Master" AutoEventWireup="true" CodeBehind="OnaylananYorumlar.aspx.cs" Inherits="ZirvedeTarih.AdminPanel.OnaylananYorumlar" %>
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
                    <td><%#Eval("Makale") %></td>
                    <td><%#Eval("YorumTarih") %></td>
                    <td><%#Eval("YorumBegeni") %></td>
                    <td><%#Eval("YorumIcerik") %></td>
                    <td><%#Eval("AktiflikStr") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_reddet" runat="server" CssClass="reddet" CommandArgument='<%#Eval("ID") %>' CommandName="reddet">Reddet</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
