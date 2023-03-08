<%@ Page Title="" Language="C#" MasterPageFile="~/KullaniciPanel/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ZirvedeTarih.KullaniciPanel.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfa">
        <asp:Repeater ID="rp_makaleler" runat="server">
            <ItemTemplate>
                <div class="makale">
                    <div class="baslik">
                        <%#Eval("Baslik") %>

                        <div class="bilgi">
                            Yazar : <%#Eval("Yonetici") %> |
                    <img src="../ProjeResimleri/8665290_eye_vision_view_icon.png" style="width: 15px; height: 15px;" />
                            <%#Eval("GoruntulemeSayisi") %>
                        </div>
                    </div>
                    <div class="resim">
                        <a href='../MakaleResimleri/<%# Eval("Resim") %>' target="_blank">
                            <img src='../MakaleResimleri/<%# Eval("Resim") %>' /></a>
                    </div>
                    <div class="ozet">
                        <%# Eval("Ozet") %>
                        <br />
                        <a href='MakaleOku.aspx?mid=<%# Eval("ID") %>'>Devamı...</a>
                    </div>
                    <div class="kategori">
                        Kategori : <%# Eval("Kategori") %>
                    </div>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
