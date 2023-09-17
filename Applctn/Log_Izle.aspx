<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Applctn/Site.master" AutoEventWireup="true"
    CodeFile="Log_Izle.aspx.cs" Inherits="About" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_urun" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_urun_Group"/>
 <asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<center>
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
        AllowPaging="True" Width="100%">
    <AlternatingRowStyle BackColor="#F7F7F7" />
    <Columns>
        <asp:BoundField DataField="Log_id" HeaderText="Log Id" 
            SortExpression="Log_id" />
        <asp:BoundField DataField="Yon_kullanici_adi" HeaderText="Kullanici Adı" 
            SortExpression="yon_kullanici_adi" />
                    <asp:BoundField DataField="Islem" HeaderText="Yapılan İşlem" 
            SortExpression="Islem" />
        <asp:BoundField DataField="Islem_tarihi" HeaderText="İşlem Tarihi" 
            SortExpression="Islem_tarihi" />
        <asp:BoundField DataField="Islem_host_ip" HeaderText="İşlem Yapılan PC IP" 
            SortExpression="Islem_host_ip" />
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
        DataObjectTypeName="Ybyk.Nurun.BO.Log"
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList" TypeName="Ybyk.Nurun.Bll.LogManager"></asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:Content>
