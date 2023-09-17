using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.Nurun.BO;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.Dal;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            Lbl_kullanici.Text = "Kullanıcı : <font style='color:yellow'>" + (Session["User"] as yonetici).Yon_kullanici_adi + "</font>";
            lbl_oturum.Text="<a href='../Account/Login.aspx' ID='Oturumkapat' runat='server'>Oturum Kapat</a></Label>";
            ShowOnlineUsers();
        }
        else
        {
            Response.Redirect("../Account/Login.aspx");
        }
      
    }
    private void ShowOnlineUsers()
    {
        //Response.Write(Application["ActiveUsers"].ToString());
        lblOnlineUser.Text = "Anlık Ziyaretçi Sayısı: <font style='color:yellow'>" + Application["ActiveUsers"].ToString() + "</font>";
        gunluk_erisim bugunku_erisim = gunluk_erisimManager.GetToplam();
        if (bugunku_erisim == null)
        {
            lblgunlukerisim.Text = "";
        }
        else
        {
            lblgunlukerisim.Text = "<font style='color:yellow'>" + bugunku_erisim.Gunun_tarihi.ToShortDateString() + "</font> tarihinden itibaren erişim sayısı: <font style='color:yellow'>" + bugunku_erisim.Erisim_sayisi.ToString() + "</font>";
        }
        string bugun = DateTime.Now.ToShortDateString();
        bugunku_erisim = gunluk_erisimManager.GetItem(bugun);
        if (bugunku_erisim == null)
        {
            lblgunlukerisim.Text = lblgunlukerisim.Text + " Bugünkü Erişim sayısı: <font style='color:yellow'>0</font>";
        }
        else
        {
            lblgunlukerisim.Text = lblgunlukerisim.Text + " Bugünkü Erişim sayısı: <font style='color:yellow'>" + bugunku_erisim.Erisim_sayisi.ToString() + "</font>";
        }
    }
}
