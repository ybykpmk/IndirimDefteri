<%@ Page Title="Ürün Güncelle" Language="C#" MasterPageFile="~/Applctn/Site.master" AutoEventWireup="true"
    CodeFile="Gunc_Islem.aspx.cs" Inherits="Gunc_Islem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_urunkayit" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_urunkayit_Group"/>
<br />
<asp:Label ID="Lbl_kayit_sonucu" runat="server"></asp:Label>      
<br />
<asp:Image ID="Img_urun_resimi" runat="server" height="50" width="50"/>
 <asp:Table runat="server" Width="100%" HorizontalAlign="Center">
 <asp:TableRow>
 <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
 <asp:Label ID="Lbl_Baslik" runat="server"><h2>ÜRÜN KAYIT GÜNCELLEME</h2></asp:Label>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell Width="10%">
 <asp:Label ID="Lbl_urunadi" runat="server">Ürün Adı : </asp:Label>
  </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_urunadi" runat="server" Width="91%"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_urunadiRequired" runat="server" ControlToValidate="Txt_urunadi" 
                             CssClass="failureNotification" ErrorMessage="Ürün adı gerekli." ToolTip="Ürün adı gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
  <asp:Label ID="Lbl_kategori" runat="server">Kategorisi : </asp:Label>
    </asp:TableCell>
   <asp:TableCell>
      <asp:UpdatePanel ID="Upd_Pnl_kategori" runat="server">
  <ContentTemplate>
  <asp:DropDownList ID="DDL_kategori" runat="server" Width="170" OnSelectedIndexChanged="DDL_kategori_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:RequiredFieldValidator ID="DDL_kategoriRequired" runat="server" ControlToValidate="DDL_kategori" 
                             CssClass="failureNotification" ErrorMessage="Kategori seçimi gerekli." ToolTip="Kategori seçimi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
 &nbsp;&nbsp;&nbsp;&nbsp;                          
  <asp:Label ID="Lbl_altkategori" runat="server">Alt Kategorisi : </asp:Label>
  <asp:DropDownList ID="DDL_altkategori" runat="server" Width="170"></asp:DropDownList>
   <asp:RequiredFieldValidator ID="DDL_altkategoriRequired" runat="server" ControlToValidate="DDL_altkategori" 
                             CssClass="failureNotification" ErrorMessage="Alt Kategori seçimi gerekli." ToolTip="Alt Kategori seçimi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
                              &nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="Lbl_ozellik" runat="server">Ürün Özelliği : </asp:Label>      
<asp:DropDownList ID="DDL_ozellik" runat="server" Width="170">
  </asp:DropDownList> 
          <asp:RequiredFieldValidator ID="DDL_ozellikRequired" runat="server" ControlToValidate="DDL_ozellik" 
                             CssClass="failureNotification" ErrorMessage="Ürün özelliği seçimi gerekli." ToolTip="Ürün özelliği seçimi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
                                                         </ContentTemplate>
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="DDL_kategori" EventName="SelectedIndexChanged"/>
 </Triggers>
 </asp:UpdatePanel>
  </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Listefiyat" runat="server">Liste Fiyatı : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Listefiyat" runat="server" Width="100"></asp:TextBox>
    <asp:RequiredFieldValidator ID="Txt_ListefiyatRequired" runat="server" ControlToValidate="Txt_Listefiyat" 
                             CssClass="failureNotification" ErrorMessage="Liste fiyatı gerekli." ToolTip="Liste fiyatı gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
                             <asp:MaskedEditExtender ID="MaskedEditExtender1"
    TargetControlID="Txt_Listefiyat" 
    Mask="9,999.99"
    MessageValidatorTip="true" 
    OnFocusCssClass="MaskedEditFocus" 
    OnInvalidCssClass="MaskedEditError"
    MaskType="Number" 
    InputDirection="RightToLeft" 
    AcceptNegative="Left"    
    ErrorTooltipEnabled="True" runat="server"/>
 <asp:DropDownList ID="DDL_Lis_fiy_dvz" runat="server" Width="60">
   </asp:DropDownList>
     <asp:RequiredFieldValidator ID="DDL_Lis_fiy_dvzRequired" runat="server" ControlToValidate="DDL_Lis_fiy_dvz" 
                             CssClass="failureNotification" ErrorMessage="Liste fiyatı para cinsi gerekli." ToolTip="Liste fiyatı para cinsi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
 &nbsp;&nbsp;&nbsp;&nbsp;
 <asp:Label ID="Lbl_ind_fiyat" runat="server">İndirimli Fiyatı : </asp:Label>
 <asp:TextBox ID="Txt_ind_fiyat" runat="server" Width="100"></asp:TextBox>
        <asp:RequiredFieldValidator ID="Txt_ind_fiyatRequired" runat="server" ControlToValidate="Txt_ind_fiyat" 
                             CssClass="failureNotification" ErrorMessage="İndirimli fiyatı gerekli." ToolTip="İndirimli fiyatı gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
<asp:MaskedEditExtender
    TargetControlID="Txt_ind_fiyat" 
    Mask="9,999.99"
    MessageValidatorTip="true" 
    OnFocusCssClass="MaskedEditFocus" 
    OnInvalidCssClass="MaskedEditError"
    MaskType="Number" 
    InputDirection="RightToLeft" 
    AcceptNegative="Left"    
    ErrorTooltipEnabled="True" runat="server"/>
 <asp:DropDownList ID="DDL_ind_fiy_dvz" runat="server" Width="60">
  </asp:DropDownList>
       <asp:RequiredFieldValidator ID="DDL_ind_fiy_dvzRequired" runat="server" ControlToValidate="DDL_ind_fiy_dvz" 
                             CssClass="failureNotification" ErrorMessage="İndirimli fiyatı para cinsi gerekli." ToolTip="İndirimli fiyatı para cinsi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="Label1" runat="server">İndirim Bitiş Tarihi : </asp:Label>
   <asp:TextBox ID="Txt_ind_bts_trh" runat="server" Width="80"></asp:TextBox>
   <asp:RequiredFieldValidator ID="Txt_ind_bts_trhRequired" runat="server" ControlToValidate="Txt_ind_bts_trh" 
                             CssClass="failureNotification" ErrorMessage="İndirim bitiş tarihi gerekli." ToolTip="İndirim bitiş tarihi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>
  <asp:ImageButton
      ID="Imagebuttonum" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />      
     <asp:CalendarExtender  ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="Imagebuttonum" TargetControlID="Txt_ind_bts_trh" Format="dd.MM.yyyy">
     </asp:CalendarExtender>
     <asp:MaskedEditExtender TargetControlID="Txt_ind_bts_trh" ErrorTooltipEnabled="true" MessageValidatorTip="true" MaskType="Date" Mask="99/99/9999" ID="Mee_txt_in_bts_trh" runat="server" CultureName="tr-TR"></asp:MaskedEditExtender>
     <asp:MaskedEditValidator ID="Mev_Txt_ind_bts_trh" runat="server"  ControlToValidate="Txt_ind_bts_trh" ControlExtender="Mee_txt_in_bts_trh"
     InvalidValueMessage="Tarih formatı geçerli değil." ValidationGroup="Validation_urunkayit_Group" >*</asp:MaskedEditValidator>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_satici" runat="server">Ürün Satıcısı : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_satici" runat="server" Width="310"></asp:TextBox>
          <asp:RequiredFieldValidator ID="Txt_saticiRequired" runat="server" ControlToValidate="Txt_satici" 
                             CssClass="failureNotification" ErrorMessage="Ürün satıcısı bilgisi gerekli." ToolTip="Ürün satıcısı bilgisi gerekli." 
                             ValidationGroup="Validation_urunkayit_Group">*</asp:RequiredFieldValidator>

  <asp:Label ID="Lbl_Url" runat="server">Ürün URL : </asp:Label>
 <asp:TextBox ID="Txt_Url" runat="server" Width="358"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not1" runat="server">Ürün Notu1 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not1" runat="server" Width="91%" Rows="5" TextMode="MultiLine" Height="100"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not2" runat="server" ForeColor="Red">Ürün Notu2 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not2" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not3" runat="server" ForeColor="Blue">Ürün Notu3 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not3" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
<%--  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not4" runat="server">Ürün Notu4 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not4" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>
  <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Not5" runat="server">Ürün Notu5 : </asp:Label>
   </asp:TableCell>
   <asp:TableCell>
 <asp:TextBox ID="Txt_Not5" runat="server" Width="91%"></asp:TextBox>
 </asp:TableCell>
 </asp:TableRow>--%>
 <asp:TableRow>
 <asp:TableCell ColumnSpan="2" VerticalAlign="Top">
 <asp:UpdatePanel ID="Upd_Pnl_Odeme" runat="server"> 
  <ContentTemplate>
 <asp:Label ID="Lbl_Kart" runat="server">Kart : </asp:Label>&nbsp;
 <asp:DropDownList ID="DDL_Kart" runat="server"></asp:DropDownList>&nbsp;
 <asp:Label ID="Lbl_TaksitSuresi" runat="server">Taksit Süresi : </asp:Label>&nbsp;
 <asp:DropDownList ID="DDL_TaksitSuresi" runat="server"></asp:DropDownList>&nbsp;
 <asp:Label ID="Lbl_IndirimYuzdesi" runat="server">İndirim % : </asp:Label>&nbsp;
 % <asp:DropDownList ID="DDL_IndirimYuzdesi" runat="server"></asp:DropDownList>&nbsp;
 <asp:Button ID="Btn_Ekle" runat="server" Text="Ekle" OnClick="Btn_Ekle_Click"/>&nbsp;
 <asp:ListBox ID="LBox_Odeme" runat="server" Rows="8" SelectionMode="Multiple" Width="300"></asp:ListBox>&nbsp;&nbsp;
 <asp:Button ID="Btn_Cikar" runat="server" Text="Çıkar" OnClick="Btn_Cikar_Click"/>
 </ContentTemplate>  
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="Btn_Ekle" EventName="Click"/>
 <asp:AsyncPostBackTrigger ControlID="Btn_Cikar" EventName="Click"/>
 </Triggers>
 </asp:UpdatePanel>
 </asp:TableCell>
 </asp:TableRow>
 <asp:TableRow>
 <asp:TableCell>
 <asp:Label ID="Lbl_Upload" runat="server">Ürün Resimi : </asp:Label>
   </asp:TableCell>
 <asp:TableCell>
 <asp:FileUpload ID="FileUpl_urunresim" runat="server" Width="400"/>&nbsp;                             
 <asp:Label ID="Lbl_Kargo" runat="server">Kargo : </asp:Label>
 <asp:CheckBox ID="ChBox_Kargo" runat="server" />&nbsp;
 <asp:Label ID="Lbl_YayinOnay" runat="server">Ürün Yayınlansın mı? : </asp:Label>
 <asp:CheckBox ID="ChBox_YayinOnay" runat="server" />&nbsp;
 <asp:Button ID="btn_urunkayit" runat="server" ValidationGroup="Validation_urunkayit_Group" Text="Kaydet" OnClick="btn_urunkayit_Click"/>&nbsp;&nbsp;
  <asp:Button ID="btn_urunkayitiptal" runat="server"  Text="İptal" OnClick="btn_urunkayitiptal_Click"/> 
 </asp:TableCell>
 </asp:TableRow>
 </asp:Table>
 </asp:Content>
