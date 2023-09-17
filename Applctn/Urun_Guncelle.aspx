<%@ Page Title="Ürün Güncelleme" Language="C#" MasterPageFile="~/Applctn/Site.master" AutoEventWireup="true"
    CodeFile="Urun_Guncelle.aspx.cs" Inherits="About" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_urun" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_urun_Group"/>
<asp:Label ID="Lbl_sonuc" runat="server"></asp:Label>      
<br />
<asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
<asp:Label runat="server" ID="Lbl_Srlm_Olct">Sıralama Ölçütü</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:DropDownList ID="DDL_Srlm_Olct" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:DropDownList ID="DDL_sira" runat="server">
   <asp:ListItem Value="asc" Text="Baştan sona"></asp:ListItem>
   <asp:ListItem Value="desc" Text="Sondan başa"></asp:ListItem>
   </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:TextBox ID="Txt_bas_trh" runat="server" Width="80"></asp:TextBox>
  <asp:ImageButton ID="Imagebuttonum" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />      
     <asp:CalendarExtender  ID="CalendarExtender1" runat="server" Enabled="True" PopupButtonID="Imagebuttonum" TargetControlID="Txt_bas_trh" Format="dd.MM.yyyy">
     </asp:CalendarExtender>
     <asp:MaskedEditExtender TargetControlID="Txt_bas_trh" ErrorTooltipEnabled="true" MessageValidatorTip="true" MaskType="Date" Mask="99/99/9999" ID="Mee_txt_bas_trh" runat="server" CultureName="tr-TR"></asp:MaskedEditExtender>
     <asp:MaskedEditValidator ID="Mev_Txt_bas_trh" runat="server"  ControlToValidate="Txt_bas_trh" ControlExtender="Mee_txt_bas_trh"
     InvalidValueMessage="Tarih formatı geçerli değil." ValidationGroup="Validation_urun_Group" >*</asp:MaskedEditValidator>&nbsp;&nbsp;
<asp:Label ID="Lbl_ile" runat="server"> ile </asp:Label>&nbsp;&nbsp;
   <asp:TextBox ID="Txt_bit_trh" runat="server" Width="80"></asp:TextBox>
  <asp:ImageButton ID="Imagebuttonum2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />      
     <asp:CalendarExtender  ID="CalendarExtender2" runat="server" Enabled="True" PopupButtonID="Imagebuttonum2" TargetControlID="Txt_bit_trh" Format="dd.MM.yyyy">
     </asp:CalendarExtender>
     <asp:MaskedEditExtender TargetControlID="Txt_bit_trh" ErrorTooltipEnabled="true" MessageValidatorTip="true" MaskType="Date" Mask="99/99/9999" ID="Mee_Txt_bit_trh" runat="server" CultureName="tr-TR"></asp:MaskedEditExtender>
     <asp:MaskedEditValidator ID="Mev_Txt_bit_trh" runat="server"  ControlToValidate="Txt_bit_trh" ControlExtender="Mee_Txt_bit_trh"
     InvalidValueMessage="Tarih formatı geçerli değil." ValidationGroup="Validation_urun_Group" >*</asp:MaskedEditValidator>&nbsp;&nbsp;
<asp:Label ID="Lbl_arasini" runat="server"> arasını </asp:Label>&nbsp;&nbsp;
<asp:Button ID="btn_sorgula" runat="server" ValidationGroup="Validation_urun_Group" OnClick="btn_sorgula_Click" Text="Sorgula" />
</center>
<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="Both" 
        AllowPaging="True" onrowdatabound="GridView1_RowDataBound">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:TemplateField HeaderText="İşlem">
        <ItemTemplate>
        <a href="<%# (string) CheckURLGunc(Eval("Urun_id").ToString())%>">Güncelle</a>&nbsp;
        <a href="<%# (string) CheckURLSil(Eval("Urun_id").ToString())%>">Sil</a>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Urun_adi" HeaderText="Ürün Adı" 
            SortExpression="Urun_adi" />
        <asp:TemplateField HeaderText="Ürün Foto">
        <ItemTemplate>
        <img src="<%#Eval("Urun_resim_adresi")%>" height="30" width="30"/>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Kategori_adi" HeaderText="Kategori Adı" 
            SortExpression="Kategori_adi" />
        <asp:BoundField DataField="Alt_kategori_adi" HeaderText="Alt kategori Adı" 
            SortExpression="Alt_kategori_adi" />
        <asp:BoundField DataField="Liste_fiyati" HeaderText="Liste Fiyatı" 
            SortExpression="Liste_fiyati" />
        <asp:BoundField DataField="Indirim_fiyati" HeaderText="İndirim Fiyatı" 
            SortExpression="Indirim_fiyati" />
         <asp:BoundField DataField="Indirim_bitis_tarihi" 
            HeaderText="İndirim Bitiş Tarihi" SortExpression="Indirim_bitis_tarihi" />
        <asp:BoundField DataField="Urun_onay" HeaderText="Yayın Durumu" 
            SortExpression="Urun_onay" />
        <asp:BoundField DataField="Urun_kayit_tarihi" HeaderText="Kayıt Tarihi" 
            SortExpression="Urun_kayit_tarihi" />
        <asp:BoundField DataField="Yon_kullanici_adi" HeaderText="Kayıt Yapan" 
            SortExpression="Yon_kullanici_adi" />
    </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center"/>
    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />
</asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Ybyk.Nurun.BO.Urun" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.Nurun.Bll.UrunManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>

        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>

