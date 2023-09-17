using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.BO;
using Ybyk.Nurun.Dal;

public partial class Gunc_Islem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["urun_no"] != null)
            {
                 try
                {
                    Urun sil_urun = UrunManager.GetItem(Convert.ToInt32(Request.QueryString["urun_no"]));
                    if (sil_urun != null)
                    {
                        Doviz ind_fyt_kr = DovizManager.GetItem(sil_urun.Indirim_fiyati_doviz_id);
                        Doviz lst_fyt_kr = DovizManager.GetItem(sil_urun.Liste_fiyati_doviz_id);
                        Txt_ind_bts_trh.Text = sil_urun.Indirim_bitis_tarihi.ToShortDateString();
                        Txt_ind_fiyat.Text = sil_urun.Indirim_fiyati + " " + ind_fyt_kr.Doviz_adi;
                        Txt_Listefiyat.Text = sil_urun.Liste_fiyati + " " + lst_fyt_kr.Doviz_adi;
                        Txt_Not1.Text = sil_urun.Urun_not1;
                        Txt_Not2.Text = sil_urun.Urun_not2;
                        Txt_Not3.Text = sil_urun.Urun_not3;
                        Txt_Not4.Text = sil_urun.Urun_not4;
                        Txt_Not5.Text = sil_urun.Urun_not5;
                        Txt_satici.Text = sil_urun.Urun_saticisi_adi;
                        Txt_Url.Text = sil_urun.Link;
                        Txt_urunadi.Text = sil_urun.Urun_adi;
                        Alt_kategori altkategorim = Alt_kategoriManager.GetItem(sil_urun.Alt_kategori_id);
                        Txt_altkategori.Text = altkategorim.Alt_kategori_adi;
                        Kategori kategorim = KategoriManager.GetItem(altkategorim.Kategori_id);
                        Txt_kategori.Text = kategorim.Kategori_adi;
                        Ozellik ozellikim = OzellikManager.GetItem(sil_urun.Urun_ozellik_id);
                        Txt_ozellik.Text = ozellikim.Ozellik_adi;                        
                        Img_urun_resimi.ImageUrl = sil_urun.Urun_resim_adresi;
                        if (sil_urun.Kargo == 1)
                            Lbl_Kargo.Text="Kargo : E";
                        else
                            Lbl_Kargo.Text = "Kargo : H";
                        if (sil_urun.Urun_onay == 1)
                            Lbl_YayinOnay.Text = "Ürün Yayınlansın mı? : E";
                        else
                            Lbl_YayinOnay.Text = "Ürün Yayınlansın mı? : H";
                        
                        try
                        {
                            OdemeList gunc_odeme_list = OdemeManager.GetList(Convert.ToInt32(Request.QueryString["urun_no"]));
                            if (gunc_odeme_list != null)
                            {
                                foreach (Odeme gunc_odeme in gunc_odeme_list)
                                {
                                    LBox_Odeme.Items.Add(gunc_odeme.Odeme_aciklamasi);
                                }
                            }
                        }
                        catch (Exception exc2)
                        {
                            Response.Write("Hata2! " + exc2.Message);
                            return;
                        }
                    }
                }
                catch (Exception exc3)
                {
                    Response.Write("Hata3! " + exc3.Message);
                    return;
                }
            }
        }
    }
    protected void btn_urunsil_Click(object sender, EventArgs e)
    {
        bool silmesonucu;
        if (LBox_Odeme.Items.Count > 0)
        {
            try
            {
                OdemeManager.Delete(Convert.ToInt32(Request.QueryString["urun_no"]));
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1! " + exc1.Message);
                return;
            }
        }
        try
        {
            silmesonucu = UrunManager.Delete(Convert.ToInt32(Request.QueryString["urun_no"]));
        }
        catch (Exception exc2)
        {
            Response.Write("Hata2! " + exc2.Message);
            return;
        }
        if (silmesonucu==true)
        {
            try
            {
                Log kayitlogu = new Log();
                kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                kayitlogu.Islem_tarihi = DateTime.Now;
                kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                kayitlogu.Islem = "Ürün kayıt silme işlemini gerçekleştirdi.";
                LogManager.Insert(kayitlogu);
            }
            catch (Exception exc3)
            {
                Response.Write("Hata3! " + exc3.Message);
                return;
            }  
            Response.Redirect("Urun_Guncelle.aspx?urun_no=" + Request.QueryString["urun_no"] + "&islem=Sil");
        }
        else
        {
            Lbl_kayit_sonucu.Text = "<font color='red'>Kayıt silme işlemi(1) esnasında hata oluştu.</font>";
        }
    }
     protected void btn_urunsiliptal_Click(object sender, EventArgs e)
    {
        Response.Redirect("Urun_Guncelle.aspx");
    }
}
