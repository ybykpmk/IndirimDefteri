<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Applctn/Site.master" AutoEventWireup="true"
    CodeFile="Kategori_Kayit.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<asp:ValidationSummary ID="Validation_kategorikayit" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_kategorikayit_Group"/>
<asp:ValidationSummary ID="Validation_altkategorikayit" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_altkategorikayit_Group"/>
<asp:ValidationSummary ID="Validation_kategorikayitgunc" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_kategorikayitgunc_Group"/>
<asp:ValidationSummary ID="Validation_altkategorikayitgunc" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_altkategorikayitgunc_Group"/>
<asp:UpdatePanel ID="upt_pnl" runat="server">
<ContentTemplate>
<br />
<asp:Label ID="Lbl_kayit_sonucu" runat="server"></asp:Label>      
<br />
<center>
<asp:Table runat="server">
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
<asp:Label ID="Lbl_kategori" runat="server">Kategori Listesi : </asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:ListBox ID="Lstbox_kategori" Rows="12" SelectionMode="Multiple" runat="server" Width="200" OnSelectedIndexChanged="Lstbox_kategori_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
</asp:TableCell>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
<asp:Label ID="Lbl_altkategori" runat="server">Alt Kategori Listesi : </asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:ListBox ID="Lstbox_altkategori" Rows="12" SelectionMode="Multiple" runat="server" Width="200" OnSelectedIndexChanged="Lstbox_altkategori_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>
<asp:Label ID="Lbl_yenikategori" runat="server">Yeni Kategori</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="btn_kategoriekle" Text="Ekle" ValidationGroup="Validation_kategorikayit_Group" OnClick="btn_kategoriekle_Click" runat="server" Width="80" BackColor="AliceBlue"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_kategori" runat="server" Width="190" BackColor="AliceBlue"></asp:TextBox>
<asp:RequiredFieldValidator ID="txt_kategoriRequired" runat="server" ControlToValidate="txt_kategori" 
                             CssClass="failureNotification" ErrorMessage="Kategori adı gerekli." ToolTip="Kategori adı gerekli." 
                             ValidationGroup="Validation_kategorikayit_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
<asp:TableCell>
<asp:Label ID="Lbl_yenialtkategori" runat="server">Yeni Alt Kategori</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="btn_altkategoriekle" Text="Ekle" ValidationGroup="Validation_altkategorikayit_Group" OnClick="btn_altkategoriekle_Click" runat="server" Width="80" BackColor="AliceBlue"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_altkategori" runat="server" Width="190" BackColor="AliceBlue"></asp:TextBox>
<asp:RequiredFieldValidator ID="txt_altkategoriRequired" runat="server" ControlToValidate="txt_altkategori" 
                             CssClass="failureNotification" ErrorMessage="Alt kategori adı gerekli." ToolTip="txt_altkategori adı gerekli." 
                             ValidationGroup="Validation_altkategorikayit_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell RowSpan="2">
<asp:Label ID="Lbl_mevcutkategori" runat="server">Mevcut Kategoriyi</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="btn_kategoriguncelle" ValidationGroup="Validation_kategorikayitgunc_Group" Enabled="false" Text="Güncelle" OnClick="btn_kategoriguncelle_Click" runat="server" Width="80" BackColor="LightGreen"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_kategorigunc" Enabled="false" runat="server" Width="174" BackColor="LightGreen"></asp:TextBox>
<asp:RequiredFieldValidator ID="txt_kategoriguncRequired" runat="server" ControlToValidate="txt_kategorigunc" 
                             CssClass="failureNotification" ErrorMessage="Kategori adı gerekli." ToolTip="Kategori adı gerekli." 
                             ValidationGroup="Validation_kategorikayitgunc_Group">*</asp:RequiredFieldValidator>
<asp:CheckBox ID="Chckbox_kategorigunc" Enabled="false" runat="server" BackColor="LightGreen"/>
</asp:TableCell>
<asp:TableCell RowSpan="2">
<asp:Label ID="Lbl_mevcutaltkategori" runat="server">Mevcut Alt Kategoriyi</asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="btn_altkategoriguncelle" ValidationGroup="Validation_altkategorikayitgunc_Group" Enabled="false" Text="Güncelle" OnClick="btn_altkategoriguncelle_Click" runat="server" Width="80" BackColor="LightGreen"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_altkategorigunc" Enabled="false" runat="server" Width="174" BackColor="LightGreen"></asp:TextBox>
<asp:RequiredFieldValidator ID="txt_altkategoriguncRequired" runat="server" ControlToValidate="txt_altkategorigunc" 
                             CssClass="failureNotification" ErrorMessage="Alt kategori adı gerekli." ToolTip="Alt kategori adı gerekli." 
                             ValidationGroup="Validation_altkategorikayitgunc_Group">*</asp:RequiredFieldValidator>
<asp:CheckBox ID="Chckbox_altkategorigunc" Enabled="false" runat="server" BackColor="LightGreen"/>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>
<asp:Button ID="btn_kategorisil" Text="Sil" Enabled="false" OnClick="btn_kategorisil_Click" runat="server" Width="80" BackColor="LightPink"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_kategorisil" Enabled="false" runat="server" Width="180" ReadOnly="true" BackColor="LightPink"></asp:TextBox>
<asp:CheckBox ID="Chckbox_kategorisil" Enabled="false" runat="server" BackColor="LightPink"/>
</asp:TableCell>
<asp:TableCell>
<asp:Button ID="btn_altkategorisil" Enabled="false" Text="Sil" OnClick="btn_altkategorisil_Click" runat="server" Width="80" BackColor="LightPink"/>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="txt_altkategorisil" Enabled="false" runat="server" Width="180" ReadOnly="true" BackColor="LightPink"></asp:TextBox>
<asp:CheckBox ID="Chckbox_altkategorisil" Enabled="false" runat="server" BackColor="LightPink"/>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
<asp:Label ID="Lbl_kat_Kul_drm" runat="server">Kullanım Durumu : </asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:Label ID="Lbl_kat_Kul_sys" runat="server"></asp:Label>
</asp:TableCell>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
<asp:Label ID="Lbl_alt_kat_Kul_drm" runat="server">Kullanım Durumu : </asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:Label ID="Lbl_alt_kat_Kul_sys" runat="server"></asp:Label>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</center>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="btn_kategoriekle" EventName="Click" />
<asp:AsyncPostBackTrigger ControlID="btn_altkategoriekle" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</asp:Content>
