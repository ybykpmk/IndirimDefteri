using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.Nurun.BO;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.Dal;
public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            try
            {
                Log kulanici_logu = new Log();
                kulanici_logu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                kulanici_logu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                kulanici_logu.Islem_tarihi = DateTime.Now;
                kulanici_logu.Islem = "Oturum kapattı";
                LogManager.Insert(kulanici_logu);
                Session["User"] = null;
            }
            catch (Exception exc)
            {
                Response.Write("Oturum kapatırken hata oluştu. " + exc.Message);
            }
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Session["randomlgnStr"] != null)
        {
            if (Page.IsValid && (Txt_cpha.Text == Session["randomlgnStr"].ToString()))
            {
                if (((UserName.Text).Trim() != null) & ((Password.Text).Trim() != null))
                {
                    try
                    {
                        yonetici yyonetici = yoneticiManager.GetItem((UserName.Text).Trim(), (Password.Text).Trim());
                        if (yyonetici != null)
                        {
                            Session.Add("User", yyonetici);
                            Session["randomlgnStr"] = null;
                            try
                            {
                                Log kulanici_logu = new Log();
                                kulanici_logu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                                kulanici_logu.Kullanici_id = yyonetici.Yonetici_id;
                                kulanici_logu.Islem_tarihi = DateTime.Now;
                                kulanici_logu.Islem = "Oturum açtı";
                                LogManager.Insert(kulanici_logu);
                            }
                            catch (Exception exc)
                            {
                                Response.Write("Oturum açarken hata oluştu. " + exc.Message);
                            }
                            Response.Redirect("../Applctn/Urun_Kayit.aspx");
                        }
                        else
                        {

                        }
                    }
                    catch (Exception exc)
                    {
                        Response.Write("Hata! " + exc.Message);
                    }
                }
            }
            else
            {
                FailureText.Text = "Kullanıcı adını, parolasını veya resim yazısını yanlış girdiniz.";
            }
        }
    }
}
