<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="index" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>Ýndirim Defteri- Güncel Ýndirim, Fýrsat ve Kampanya Haberleri</title>
<meta name="description" content="indirimdefteri.com sayesinde, üyelik þartý aranmaksýzýn, firmalarýn güncel indirim, fýrsat ve kampanyalarýndan ürün bazýnda haberdar olun, kazançlý çýkan siz olun." /><meta name="keywords" content="kampanya, indirim, fýrsat, indirim fýrsatlarý, elektronik, bilgisayar, biliþim, bebek, oyuncak, kozmetik" />
    <link href="Styles/menustyle.css" rel="stylesheet" type="text/css" />    
    <script type="text/javascript">
        function showmodalpopup(urun_resim_adresi) {
            $get("<%=img_resim.ClientID %>").src = urun_resim_adresi;
            $find("mdl_popup_Ext1").show();
        }
        function showmodalpopup2() {
            if ($get("img_cpcha").src == "http://indirimdefteri.com/site_cpha.aspx") {
                $get("img_cpcha").src = "site_cpha2.aspx";
            }
            else {
                $get("img_cpcha").src = "site_cpha.aspx";
            }
            $find("mdl_popup_Ext2").show();
        }
        function showmodalpopup3(span_text) {
            if ($get("cpcha_image").src == "http://indirimdefteri.com/site_cpha3.aspx") {
                $get("cpcha_image").src = "site_cpha4.aspx";
            }
            else {
                $get("cpcha_image").src = "site_cpha3.aspx";
            }
            document.getElementById("Lbl_urun_adi").innerHTML = span_text;
            $find("mdl_popup_Ext3").show();
        }
        function body_onmousedown() {
            $find("mdl_popup_Ext1").hide();
        }
        function img_click(mdl_pop_ext) {
            $find(mdl_pop_ext).hide();
        }
        function btn_Temizle_Click() {
            document.getElementById("Txt_konu").value = "";
            document.getElementById("Txt_URL").value = "";
            document.getElementById("Txt_Mesaj").value = "";
            document.getElementById("Txt_Adi").value = "";
            document.getElementById("Txt_eposta").value = "";
            document.getElementById("DDL_dh_ucz_var").selectedIndex = 0;
            return false;
        }
        function Btn_ark_hrb_ver_temizle_Click() {
            document.getElementById("Txt_eposta_ark_hbr_ver").value = "";
            document.getElementById("Txt_ad_ark_hbr_ver").value = "";
            document.getElementById("Txt_ark_eposta1").value = "";
            document.getElementById("Txt_ark_ad1").value = "";
            document.getElementById("Txt_ark_eposta2").value = "";
            document.getElementById("Txt_ark_ad2").value = "";
            document.getElementById("Txt_ark_eposta3").value = "";
            document.getElementById("Txt_ark_ad3").value = "";
            document.getElementById("Txt_ark_eposta4").value = "";
            document.getElementById("Txt_ark_ad4").value = "";
            document.getElementById("Txt_ark_eposta5").value = "";
            document.getElementById("Txt_ark_ad5").value = "";
            return false;
        }
</script>
</head>
<body onmousedown="body_onmousedown()">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <asp:Table ID="Tbl_dt" runat="server" Width="100%" HorizontalAlign="Center" Font-Size="Medium" Font-Names="Arial" Font-Bold="True">
<asp:TableRow>
<asp:TableCell>
<a href="default.aspx"><asp:Image ID="Image1" ImageUrl="~/images/logo3.jpg" runat="server" BorderStyle="None" /></a>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Right">
<asp:UpdatePanel ID="upd_pnl" runat="server">
<ContentTemplate>
<asp:Table CssClass="arama_label" ID="Table1" runat="server">
<asp:TableRow>
<asp:TableCell ColumnSpan="5" HorizontalAlign="Center">
<asp:Label ID="Lbl_urun_arama" runat="server" CssClass="arama_label_baslik">Ürün Arama</asp:Label>
<br />
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell> <asp:Label ID="Lbl_kategori" runat="server">Kategori : </asp:Label>
</asp:TableCell>
<asp:TableCell>
<asp:DropDownList CssClass="arama" ID="DDL_kategori" Width="145px" runat="server" AutoPostBack="true" Height="20"></asp:DropDownList>
</asp:TableCell>
<asp:TableCell RowSpan="2">
<asp:ImageButton ID="btn_Ara" runat="server" ImageUrl="~/images/ARA.jpg" OnClick="btn_Ara_Click" Text="ARA" Height="70" Width="70" />
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell>
 <asp:Label ID="Label3" runat="server">Anahtar Sözcük : </asp:Label>
 </asp:TableCell>
<asp:TableCell>
 <asp:TextBox CssClass="arama" ID="Txt_anh_szck" runat="server" Width="140px"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID="DDL_kategori" EventName="SelectedIndexChanged" />
<asp:AsyncPostBackTrigger ControlID="btn_Ara" EventName="Click" />
</Triggers>
</asp:UpdatePanel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
<asp:UpdatePanel ID="UpdPnl_lblarama" runat="server">
<ContentTemplate>
<asp:Label ID="lblAramaSonucu" runat="server"></asp:Label>
</ContentTemplate>
</asp:UpdatePanel>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="ObjectDataSource1" GridLines="None" OnDataBound="GridView1_DataBound"
        AllowPaging="True" PageSize="20" UseAccessibleHeader="False" ShowHeader="False" Height="50" Width="100%" PagerSettings-Mode="NumericFirstLast" PagerSettings-FirstPageText="Ýlk Sayfa" PagerSettings-LastPageText="Son Sayfa" PagerSettings-NextPageText="Sonraki Sayfa" PagerSettings-PreviousPageText="Önceki Sayfa" PagerStyle-ForeColor="#CC0000">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:TemplateField ItemStyle-Width="83%">
        <ItemTemplate>
        <asp:Table ID="Table1" runat="server" Width="100%" Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" HorizontalAlign="Left">
                <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/line2.png" Width="100%" />
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="4" Font-Bold="True" Font-Names="Arial" Font-Size="Large" HorizontalAlign="Left">
        <asp:Label ID="Lbl_col3" runat="server" Text='<%# (string) Sutun_Olustur3(Eval("link").ToString(),Eval("urun_adi").ToString(),Eval("indirim_fiyati").ToString(),Eval("urun_ozellik_adi").ToString())%>'></asp:Label>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
        <asp:Image ID="img_line" runat="server" ImageUrl="~/images/line.png" Width="100%" />
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell Width="71%" VerticalAlign="Top">
        <asp:Label ID="Lbl_col1" runat="server" Text='<%# (string) Sutun_Olustur1(Eval("urun_id").ToString(),Eval("indirim_bitis_tarihi").ToString(),Eval("urun_not1").ToString(),Eval("urun_not2").ToString(),Eval("urun_not3").ToString(),Eval("urun_not4").ToString(),Eval("urun_not5").ToString(),Eval("urun_saticisi_adi").ToString())%>'></asp:Label>
        </asp:TableCell>
        <asp:TableCell Width="17%" HorizontalAlign="Left">
        <asp:Label ID="Lbl_resim" runat="server" Text='<%# (string) Resim_Olustur(Eval("urun_resim_adresi").ToString())%>'></asp:Label>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Top" HorizontalAlign="Left">
        <asp:ImageButton ID="imajbuton" runat="server" ImageUrl="~/images/bSorguEkle.gif" DescriptionUrl='<%#Eval("urun_resim_adresi")%>'/>
        </asp:TableCell>
        <asp:TableCell VerticalAlign="Top">
        <asp:Label ID="Lbl_col2" runat="server" Text='<%# (string) Sutun_Olustur2(Eval("indirim_fiyati").ToString() , Eval("liste_fiyati").ToString() , Eval("kargo").ToString() , Eval("urun_kayit_tarihi").ToString()) %>'></asp:Label>
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/line.png" Width="100%" />
        </asp:TableCell>
        </asp:TableRow>
              <asp:TableRow>
        <asp:TableCell ColumnSpan="4">
        <asp:LinkButton ID="LB_ark_hbr_ver" runat="server" Text="Arkadaþýma haber vereyim" style="text-decoration: none; color: #808080;" CommandArgument='<%#Eval("Urun_id")%>'></asp:LinkButton>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LB_dh_ucuz_var" runat="server" Text="Daha Ucuzu var" style="text-decoration: none; color: #808080;" OnClientClick="showmodalpopup2()"></asp:LinkButton>
        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </ItemTemplate>
        </asp:TemplateField>
     </Columns>
    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" Height="30px" />
    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" Height="30" Font-Size="Medium" Font-Bold="True" />
    <RowStyle BackColor="White" ForeColor="#4A3C8C" />
    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    <SortedAscendingCellStyle BackColor="#F4F4FD" />
    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
    <SortedDescendingCellStyle BackColor="#D8D8F0" />
    <SortedDescendingHeaderStyle BackColor="#3E3277" />
</asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DataObjectTypeName="Ybyk.Nurun.BO.Urun" DeleteMethod="Delete" 
        InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetList_ForSite" TypeName="Ybyk.Nurun.Bll.UrunManager" 
        UpdateMethod="Update"></asp:ObjectDataSource>
        </ContentTemplate>
        <Triggers>
        
        </Triggers>
        </asp:UpdatePanel>
</asp:TableCell>

</asp:TableRow>
        <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
        <asp:Image ID="img_line" runat="server" ImageUrl="~/images/line2.png" Width="100%" />
        </asp:TableCell>
        </asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" Font-Size="X-Small" Font-Names="Arial" Font-Strikeout="False" ForeColor="#666666" HorizontalAlign="Center">
Copyright © IndirimDefteri.com. Tüm hakký saklýdýr. Sitemizde çeþitli firmalarýn düzenlemiþ olduðu kampanyalar, indirimli ürünlere ait bilgiler ve fýrsat haberleri yayýnlanmaktadýr. Sunulan bilgilendirme hizmeti tamamen ücretsizdir. Ýndirimdefteri.com ürünlerin satýþýnýn yapýldýðý bir e-ticaret sitesi deðildir. Bu sitede yayýmlanan ve tanýtýmý yapýlan ürünlerin satýþý ilgili firmalar tarafýndan yapýlmaktadýr. Firmalarýn indirimi sona erdirmesi, fiyat deðiþikliði yapmasý, hatalý ilanlar vb. gibi hususlarda indirimdefteri.com hiçbir þekilde sorumluluk kabul etmez. Ýndirimdefteri.com da yayýmlanan ürünlerin satýþ þartlarý, özellikleri, fiyatlarý vb. her tür bilgi, ürünün satýþý yapan firmadan teyit edilmelidir. Websitemizde yer alan markalarýn tüm haklarý tescilli sahiplerine aittir.
Bu sitede yer alan her tür bilginin izinsiz olarak kopya edilmesi, basýlý veya elektronik bir ortamda kullanýlmasý yasaktýr.
</asp:TableCell>
</asp:TableRow>
</asp:Table>
        <asp:ModalPopupExtender ID="mdl_popup_Ext1" runat="server" PopupControlID="Pnl_img" CancelControlID="Pnl_img"  TargetControlID="HiddenField1" BackgroundCssClass="modalBackground">
 
        </asp:ModalPopupExtender>
<asp:Panel ID="Pnl_img" runat="server" Style="display: none" CssClass="modalPopup"
            Height="402px" Width="402px">
<asp:Image ImageUrl="" runat="server" ID="img_resim" HorizontalAlign="Center" ImageAlign="Middle" Width="400" Height="400" />
</asp:Panel>

        <asp:ModalPopupExtender ID="mdl_popup_Ext2" runat="server" CancelControlID="HiddenField1" TargetControlID="HiddenField1" PopupControlID="Pnl_dh_ucz_var" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
 <asp:ValidationSummary ID="Validation_dh_ucz_var" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_dh_ucz_var_Group"/>  
<asp:Panel ID="Pnl_dh_ucz_var" runat="server" Style="display: none" CssClass="modalPopup" Width="80%">
<asp:Table ID="Tbl_dh_ucz_var" runat="server" CssClass="arama_label">
<asp:TableRow>
<asp:TableCell HorizontalAlign="Left">
<asp:Image ID="img_bilgi" ImageUrl="~/images/notlar.jpg" runat="server" Height="40" Width="35" />&nbsp;&nbsp;
<asp:Label ID="lbl_bilgi" runat="server" Text="SÝTE YÖNETÝMÝNÝ BÝLGÝLENDÝRME" ForeColor="Green" Font-Size="32" Font-Names="Arial" Font-Bold="True"></asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
<asp:Image ID="image" runat="server" ImageUrl="~/images/x.png" Height="10" Width="10" OnClick="img_click('mdl_popup_Ext2')"/>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Label ID="Lbl_dh_ucz_var" runat="server">Lütfen bizi bilgilendirmek istediðiniz konuyu seçerek düþüncenizi aþaðýdaki bölüme yazýnýz, adýnýz ile e-posta adresinizi doldurunuz ve gönder butonuna basýnýz. Konuyla ilgili olarak sizi en kýsa süre içinde bilgilendireceðimizi belirterek teþekkür ederiz.</asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2">
<asp:Table ID="Table2" runat="server">
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_baslik" runat="server">Baþlýk :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:DropDownList ID="DDL_dh_ucz_var" runat="server">
<asp:ListItem Text="Ucuz Ürün Buldum"></asp:ListItem>
<asp:ListItem Text="Site Hakkýndaki Düþüncelerim"></asp:ListItem>
<asp:ListItem Text="Yanlýþ Fiyat Bilgilendirmesi"></asp:ListItem>
<asp:ListItem Text="Site Yönetimine"></asp:ListItem>
<asp:ListItem Text="Diðer Konularda"></asp:ListItem>
</asp:DropDownList>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_konu" runat="server">Konu :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_konu" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_URL" runat="server">URL :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_URL" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_Mesaj" runat="server">Mesajýnýz :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_Mesaj" runat="server" Width="600" Rows="5" TextMode="MultiLine"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_MesajRequired" runat="server" ControlToValidate="Txt_Mesaj" 
                             CssClass="failureNotification" ErrorMessage="Mesajýnýz gerekli." ToolTip="Mesajýnýz gerekli." 
                             ValidationGroup="Validation_dh_ucz_var_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_Adi" runat="server">Adýnýz :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_Adi" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_eposta" runat="server">E-posta Adresiniz :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_eposta" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle">
<asp:Label ID="Lbl_cpha" runat="server">Resim Yazýsý:</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<img src="" id="img_cpcha"/>
<br /><asp:TextBox ID="Txt_cpha" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Label ID="Lbl_Not" runat="server">Sayýn Ziyaretçi; eðer adýnýzý ve e-posta adresinizi belirtmiþseniz, kiþisel gizlilik haklarýnýz gereði bilgilerinizin kayýt altýna alýnmayacaðýný taahhüt ederiz.</asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Button ID="btn_Gonder" runat="server" ValidationGroup="Validation_dh_ucz_var_Group" OnClick="btn_Gonder_Click" Text="Gönder" />&nbsp;&nbsp;&nbsp;
<input type="button" id="btn_Temizle" onclick="btn_Temizle_Click()" value="Temizle" />
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Panel>
        <asp:ModalPopupExtender ID="mdl_popup_Ext3" runat="server" CancelControlID="HiddenField1" TargetControlID="HiddenField1" PopupControlID="Pnl_ark_hbr_ver" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>
 <asp:ValidationSummary ID="Validation_ark_hbr_ver" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validation_ark_hbr_ver_Group"/>  
<asp:Panel ID="Pnl_ark_hbr_ver" runat="server" Style="display: none" CssClass="modalPopup" Width="74%">
<asp:Table ID="Tbl_ark_hbr_ver" runat="server" CssClass="arama_label">
<asp:TableRow>
<asp:TableCell HorizontalAlign="Left">
<asp:Image ID="Image2" ImageUrl="~/images/kalem.jpg" runat="server" Height="40" Width="35" />&nbsp;&nbsp;
<asp:Label ID="Label4" runat="server" Text="ARKADAÞIMA HABER VEREYÝM" ForeColor="Green" Font-Size="32" Font-Names="Arial" Font-Bold="True"></asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Right" VerticalAlign="Top">
<asp:Image ID="image3" runat="server" ImageUrl="~/images/x.png" Height="10" Width="10" OnClick="img_click('mdl_popup_Ext3')"/>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Label ID="Lbl_urun_adi" runat="server" ForeColor="#666633"></asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Label ID="Label5" runat="server">Arkadaþýnýza haber vermek istediðiniz yukarýdaki ürün için hem sizin hem de arkadaþlarýnýzýn adý ile e-posta adreslerini doldurunuz ve gönder butonuna basýnýz.</asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Table ID="tbl_bilgiler" runat="server">
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_ad_ark_hbr_ver" runat="server">Adýnýz :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_ad_ark_hbr_ver" runat="server" Width="197"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_ad_ark_hbr_verRequired" runat="server" ControlToValidate="Txt_ad_ark_hbr_ver" 
                             CssClass="failureNotification" ErrorMessage="Adýnýz gerekli." ToolTip="Adýnýz gerekli." 
                             ValidationGroup="Validation_ark_hbr_ver_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right">
<asp:Label ID="Lbl_eposta_ark_hbr_ver" runat="server">E-posta Adresiniz :</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<asp:TextBox ID="Txt_eposta_ark_hbr_ver" runat="server" Width="197"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_eposta_ark_hbr_verRequired" runat="server" ControlToValidate="Txt_eposta_ark_hbr_ver" 
                             CssClass="failureNotification" ErrorMessage="E-posta adresiniz gerekli." ToolTip="E-posta adresiniz gerekli." 
                             ValidationGroup="Validation_ark_hbr_ver_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="150">
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Table ID="Tbl_arkadaslar" runat="server" BorderColor="#666633" BorderStyle="Inset" BorderWidth="2" GridLines="Both">
<asp:TableRow>
<asp:TableCell HorizontalAlign="Center" Width="230">
<asp:Label ID="Lbl_arkadas_adi" runat="server" Text="Arkadaþýnýzýn Adý"></asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Center" Width="230">
<asp:Label ID="Lbl_arkadas_eposta" runat="server" Text="Arkadaþýnýzýn E-posta Adresi"></asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="20">
<asp:TableCell>
<asp:TextBox ID="Txt_ark_ad1" runat="server" Width="95%"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_ark_ad1RequiredField" runat="server" ControlToValidate="Txt_ark_ad1" 
                             CssClass="failureNotification" ErrorMessage="Arkadaþýnýzýn adý gerekli." ToolTip="Arkadaþýnýzýn adý gerekli." 
                             ValidationGroup="Validation_ark_hbr_ver_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="Txt_ark_eposta1" runat="server" Width="95%"></asp:TextBox>
 <asp:RequiredFieldValidator ID="Txt_ark_eposta1Required" runat="server" ControlToValidate="Txt_ark_eposta1" 
                             CssClass="failureNotification" ErrorMessage="Arkadaþýnýzýn e-posta adresi gerekli." ToolTip="Arkadaþýnýzýn e-posta adresi gerekli." 
                             ValidationGroup="Validation_ark_hbr_ver_Group">*</asp:RequiredFieldValidator>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="20">
<asp:TableCell>
<asp:TextBox ID="Txt_ark_ad2" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="Txt_ark_eposta2" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="20">
<asp:TableCell>
<asp:TextBox ID="Txt_ark_ad3" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="Txt_ark_eposta3" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="20">
<asp:TableCell>
<asp:TextBox ID="Txt_ark_ad4" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="Txt_ark_eposta4" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow Height="20">
<asp:TableCell>
<asp:TextBox ID="Txt_ark_ad5" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
<asp:TableCell>
<asp:TextBox ID="Txt_ark_eposta5" runat="server" Width="97%"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell HorizontalAlign="Right" VerticalAlign="Middle">
<asp:Label ID="Label12" runat="server">Resim Yazýsý:</asp:Label>
</asp:TableCell>
<asp:TableCell HorizontalAlign="Left">
<img src="" id="cpcha_image"/><br /><asp:TextBox ID="Txt_ark_hbr_ver_cpha" runat="server" Width="197"></asp:TextBox>
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Label ID="Label13" runat="server">Sayýn Ziyaretçi, kiþisel gizlilik haklarý gereði sizin ve arkadaþlarýnýzýn ad ve e-posta adres bilgilerinin kayýt altýna alýnmayacaðýný taahhüt ederiz.</asp:Label>
</asp:TableCell>
</asp:TableRow>
<asp:TableRow>
<asp:TableCell ColumnSpan="2" HorizontalAlign="Left">
<asp:Button ID="Btn_ark_hrb_ver_gonder" runat="server" ValidationGroup="Validation_ark_hbr_ver_Group" OnClick="Btn_ark_hrb_ver_gonder_Click" Text="Gönder" />&nbsp;&nbsp;&nbsp;
<input type="button" id="Btn_ark_hrb_ver_temizle" onclick="Btn_ark_hrb_ver_temizle_Click()" value="Temizle" />
</asp:TableCell>
</asp:TableRow>
</asp:Table>
</asp:Panel>
<asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    </form>
</body>
</html>
