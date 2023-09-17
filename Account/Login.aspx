<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="Form1" runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                    ÜRÜN GİRİŞ UYGULAMASI
                </h1>
            </div>    
            <div class="clear hideSkiplink">
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Applctn/Urun_Kayit.aspx" Text="Ürün Kayıt"/>
                        <asp:MenuItem NavigateUrl="~/Applctn/Urun_Guncelle.aspx" Text="Ürün Güncelleme&Silme"/>
                        <asp:MenuItem NavigateUrl="~/Applctn/Kategori_Kayit.aspx" Text="Kategori/Alt Kategori Kayıt"/>
                        <asp:MenuItem NavigateUrl="~/Applctn/Log_Izle.aspx" Text="Log İzleme"/>
                    </Items>
                </asp:Menu>
            </div>
        </div>
        <div class="main">
       <h2>
        Oturum Aç
    </h2>
    <p>
        Lütfen kullanıcı adınızı ve parolanızı giriniz.       
    </p>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Kullanıcı Hesabı Bilgileri</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Kullanıcı Adı:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="Kullanıcı adı gerekli." ToolTip="Kullanıcı adı gerekli." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Parola:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Parola gerekli." ToolTip="Parola gerekli." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>                    
                    <p>
                        <asp:Label ID="Lbl_cpha" runat="server">Resim Yazısı:</asp:Label>
                        <img src="lgn_cpha.aspx" /><br /><asp:TextBox ID="Txt_cpha" runat="server" CssClass="textEntry"></asp:TextBox>

                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                        Text="Oturum Aç" ValidationGroup="LoginUserValidationGroup" 
                        onclick="LoginButton_Click"/>
                </p>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>
    </form>
</body>
</html>
