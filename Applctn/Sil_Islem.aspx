<%@ Page Title="Ürün Silme" Language="C#" MasterPageFile="~/Applctn/Site.master" AutoEventWireup="true"
    CodeFile="Sil_Islem.aspx.cs" Inherits="Gunc_Islem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<br />
<asp:Label ID="Lbl_kayit_sonucu" runat="server"></asp:Label>      
<br />
<asp:Image ID="Img_urun_resimi" runat="server" height="50" width="50"/>
 <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Baslik" runat="server"><h2>ÜRÜN SİLME</h2></asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_urunadi" runat="server">Ürün Adı : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_urunadi" ReadOnly="true" runat="server" Width="91%"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
  <asp:Label ID="Lbl_kategori" runat="server">Kategorisi : </asp:Label>
    </asp:TableCell>
   <asp:TableCell>
<asp:TextBox ID="Txt_kategori" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                      
  <asp:Label ID="Lbl_altkategori" runat="server">Alt Kategorisi : </asp:Label>
  <asp:TextBox ID="Txt_altkategori" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
       <asp:Label ID="Lbl_ozellik" runat="server">Ürün Özelliği : </asp:Label>      
<asp:TextBox ID="Txt_ozellik" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Listefiyat" runat="server">Liste Fiyatı : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Listefiyat" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
  &nbsp;&nbsp;&nbsp;
 <asp:Label ID="Lbl_ind_fiyat" runat="server">İndirimli Fiyatı : </asp:Label>
 <asp:TextBox ID="Txt_ind_fiyat" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
                               &nbsp;&nbsp;&nbsp;
  <asp:Label ID="Label1" runat="server">İndirim Bitiş Tarihi : </asp:Label>
   <asp:TextBox ID="Txt_ind_bts_trh" ReadOnly="true" runat="server" Width="20%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_satici" runat="server">Ürün Satıcısı : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_satici" ReadOnly="true" runat="server" Width="316"></asp:TextBox>
  &nbsp;
  <asp:Label ID="Lbl_Url" runat="server">Ürün URL : </asp:Label>
 <asp:TextBox ID="Txt_Url" runat="server" ReadOnly="true" Width="348"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not1" runat="server">Ürün Notu1 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not1" ReadOnly="true" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not2" runat="server">Ürün Notu2 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not2" ReadOnly="true" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not3" runat="server">Ürün Notu3 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not3" runat="server" ReadOnly="true" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not4" runat="server">Ürün Notu4 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not4" runat="server" ReadOnly="true" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not5" runat="server">Ürün Notu5 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not5" runat="server" ReadOnly="true" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Urundeme" runat="server">Ürün Ödeme : </asp:Label>
 </asp:TableCell>
 <asp:TableCell>
 <asp:ListBox ID="LBox_Odeme" runat="server" Width="300"></asp:ListBox>&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="Lbl_Kargo" runat="server">Kargo :</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Label ID="Lbl_YayinOnay" runat="server">Ürün Yayınlansın mı? :</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Button ID="btn_urunsil" runat="server" Text="Sil" OnClick="btn_urunsil_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Button ID="btn_urunsiliptal" runat="server"  Text="İptal" OnClick="btn_urunsiliptal_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:Content>
