using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.BO;
using Ybyk.Nurun.Dal;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {            
            //DDL_kategori.Items.Add("");
            //DDL_kategori.Items[0].Value = "0";
            KategoriList kategori_listem = KategoriManager.GetList();
            Int32 i = 0;
            foreach (Kategori Kategorim in kategori_listem)
            {
                DDL_kategori.Items.Add(Kategorim.Kategori_adi);
                DDL_kategori.Items[i].Value = Kategorim.Kategori_id.ToString();
                i++;
            }
            DDL_kategori_SelectedIndexChanged(sender, e);
            OzellikList urun_ozelliklist = OzellikManager.GetList();
            i = 0;
            foreach (Ozellik urun_ozellik in urun_ozelliklist)
            {
                DDL_ozellik.Items.Add(urun_ozellik.Ozellik_adi);
                DDL_ozellik.Items[i].Value = urun_ozellik.Ozellik_id.ToString();
                i++;
            }

            DovizList para_turulist = DovizManager.GetList();
            i = 0;
            foreach (Doviz para_turu in para_turulist)
            {
                DDL_ind_fiy_dvz.Items.Add(para_turu.Doviz_adi);
                DDL_Lis_fiy_dvz.Items.Add(para_turu.Doviz_adi);
                DDL_Lis_fiy_dvz.Items[i].Value = para_turu.Doviz_id.ToString();
                DDL_ind_fiy_dvz.Items[i].Value = para_turu.Doviz_id.ToString();
                i++;
            }

            AylarList aylistesi = AylarManager.GetList();
            i = 0;
            foreach (Aylar aylarim in aylistesi)
            {
                DDL_TaksitSuresi.Items.Add(aylarim.Ay_bilgisi);
                DDL_TaksitSuresi.Items[i].Value = aylarim.Ay_id.ToString();
                i++;
            }

            KartList kartlistesi = KartManager.GetList();
            i = 0;
            foreach (Kart kartim in kartlistesi)
            {
                DDL_Kart.Items.Add(kartim.Kart_adi);
                DDL_Kart.Items[i].Value = kartim.Kart_id.ToString();
                i++;
            }

            for (i = 0; i < 101; i++)
            {
                DDL_IndirimYuzdesi.Items.Add(i.ToString());
                DDL_IndirimYuzdesi.Items[i].Value = i.ToString();
            }
        }
    }
    protected void DDL_kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDL_altkategori.Items.Clear();
        Alt_kategoriList altkategori_listem = Alt_kategoriManager.GetList(Convert.ToInt32(DDL_kategori.Items[DDL_kategori.SelectedIndex].Value));
        if (altkategori_listem != null)
        {
            Int32 i = 0;
            foreach (Alt_kategori Alt_kategorim in altkategori_listem)
            {
                DDL_altkategori.Items.Add(Alt_kategorim.Alt_kategori_adi);
                DDL_altkategori.Items[i].Value = Alt_kategorim.Alt_kategori_id.ToString();
                i++;
            }
        }
    }
    protected void alantemizle(object sender, EventArgs e)
    {
        Txt_ind_bts_trh.Text = "";
        Txt_ind_fiyat.Text = "";
        Txt_Listefiyat.Text = "";
        Txt_Not1.Text = "";
        Txt_Not2.Text = "";
        Txt_Not3.Text = "";
        //Txt_Not4.Text = "";
        //Txt_Not5.Text = "";
        Txt_satici.Text = "";
        Txt_Url.Text = "";
        Txt_urunadi.Text = "";        
        DDL_kategori.SelectedIndex = 0;
        DDL_kategori_SelectedIndexChanged(sender, e);
        DDL_Lis_fiy_dvz.SelectedIndex = 0;
        DDL_Kart.SelectedIndex = 0;
        DDL_TaksitSuresi.SelectedIndex = 0;
        DDL_IndirimYuzdesi.SelectedIndex = 0;
        DDL_ozellik.SelectedIndex = 0;
        DDL_ind_fiy_dvz.SelectedIndex = 0;
        ChBox_YayinOnay.Checked = false;
        LBox_Odeme.Items.Clear();
    }
    protected void btn_urunkayit_Click(object sender, EventArgs e)
    {
        Int32 kayitsonucu = -1;
        try
        {
            Urun urunum = new Urun();
            urunum.Alt_kategori_id = Convert.ToInt32(DDL_altkategori.SelectedValue);
            urunum.Indirim_baslangic_tarihi = DateTime.Now.Date;
            urunum.Indirim_bitis_tarihi = Convert.ToDateTime(Txt_ind_bts_trh.Text);
            urunum.Indirim_fiyati = Txt_ind_fiyat.Text.Trim();
            urunum.Indirim_fiyati_doviz_id = Convert.ToInt32(DDL_ind_fiy_dvz.SelectedValue);
            urunum.Kayit_yapan = (Session["User"] as yonetici).Yonetici_id;
            urunum.Link = Txt_Url.Text.Trim();
            urunum.Liste_fiyati = Txt_Listefiyat.Text.Trim();
            urunum.Liste_fiyati_doviz_id = Convert.ToInt32(DDL_Lis_fiy_dvz.SelectedValue);
            urunum.Urun_adi = Txt_urunadi.Text.Trim();
            urunum.Urun_kayit_tarihi = DateTime.Now;
            string[] str_arr_for_spliting = new string[1];
            str_arr_for_spliting[0] = "\r\n";
            string[] urunnotarray = Txt_Not1.Text.Trim().Split(str_arr_for_spliting, new StringSplitOptions());
            string urunnot = "<br>";
            for (int i = 0; i < urunnotarray.Count(); i++)
            {
                urunnot = urunnot + urunnotarray[i] + "<br>";
            }
            urunum.Urun_not1 = urunnot;
            urunum.Urun_not2 = Txt_Not2.Text.Trim();
            urunum.Urun_not3 = Txt_Not3.Text.Trim();
            urunum.Urun_not4 = "";//Txt_Not4.Text.Trim();
            urunum.Urun_not5 = "";// Txt_Not5.Text.Trim();
            if (ChBox_Kargo.Checked)
                urunum.Kargo = 1;
            else
                urunum.Kargo = 0;
            if (ChBox_YayinOnay.Checked)
                urunum.Urun_onay = 1;
            else
                urunum.Urun_onay = 0;
            urunum.Urun_resim_adresi = "";
            urunum.Urun_ozellik_id = Convert.ToInt32(DDL_ozellik.SelectedValue);
            urunum.Urun_saticisi_adi = Txt_satici.Text.Trim();
            kayitsonucu = UrunManager.Insert(urunum);
        }
        catch (Exception exc1)
        {
            Response.Write("Hata1! " + exc1.Message);
            return;
        }
        if (kayitsonucu > 0)
        {
            if (LBox_Odeme.Items.Count > 0)
            {
                for (Int32 i = 0; i < LBox_Odeme.Items.Count; i++)
                {
                    try
                    {
                        Odeme urunodeme = new Odeme();
                        urunodeme.Odeme_aciklamasi = LBox_Odeme.Items[i].Text;
                        urunodeme.Urun_id = kayitsonucu;
                        OdemeManager.Insert(urunodeme);
                    }
                    catch (Exception exc2)
                    {
                        Response.Write("Hata2! " + (i + 1).ToString() + ". kayit. " + exc2.Message);
                        return;
                    }
                }
            }
            if (FileUpl_urunresim.HasFile)
            {
                try
                {
                    FileUpl_urunresim.SaveAs(Server.MapPath(@"..\urunler\") + kayitsonucu.ToString() + FileUpl_urunresim.FileName);
                    Urun urun_upd = UrunManager.GetItem(kayitsonucu);
                    urun_upd.Urun_resim_adresi = @"..\urunler\" + kayitsonucu.ToString() + FileUpl_urunresim.FileName;
                    kayitsonucu = UrunManager.Update(urun_upd);
                    if (kayitsonucu > 0)
                    {
                        try
                        {
                            Log kayitlogu = new Log();
                            kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                            kayitlogu.Islem_tarihi = DateTime.Now;
                            kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                            kayitlogu.Islem = "Ürün kayıt işlemini gerçekleştirdi.";
                            LogManager.Insert(kayitlogu);
                        }
                        catch (Exception exc3)
                        {
                            Response.Write("Hata3! " + exc3.Message);
                            return;
                        }
                        Lbl_kayit_sonucu.Text = "<font color='navy'>Kayıt işlemi gerçekleşti.</font>";
                        alantemizle(sender, e);
                    }
                    else
                    {
                        Lbl_kayit_sonucu.Text = "<font color='red'>Kayıt işlemi(2) esnasında hata oluştu.</font>";
                    }
                }
                catch (Exception exc4)
                {
                    Response.Write("Hata4! " + exc4.Message);
                    return;
                }
            }
        }
        else
        {
            Lbl_kayit_sonucu.Text = "<font color='red'>Kayıt işlemi(1) esnasında hata oluştu.</font>";
        }
    }
    protected void btn_urunkayitiptal_Click(object sender, EventArgs e)
    {
        alantemizle(sender, e);
    }

    protected void Btn_Ekle_Click(object sender, EventArgs e)
    {
        if ((DDL_IndirimYuzdesi.SelectedIndex!=0) && (DDL_Kart.SelectedIndex!=0) && (DDL_TaksitSuresi.SelectedIndex!=0))
        {
            if (DDL_TaksitSuresi.SelectedItem.Text != "Peşin")
            {
                LBox_Odeme.Items.Add(DDL_Kart.SelectedItem.Text + " karta " + DDL_TaksitSuresi.SelectedItem.Text + " taksitle ödeme %" + DDL_IndirimYuzdesi.SelectedItem.Text + " indirim.");
            }
            else
            {
                LBox_Odeme.Items.Add(DDL_Kart.SelectedItem.Text + " karta " + DDL_TaksitSuresi.SelectedItem.Text + " ödeme %" + DDL_IndirimYuzdesi.SelectedItem.Text + " indirim.");
            }
        }
    }

    protected void Btn_Cikar_Click(object sender, EventArgs e)
    {
        if (LBox_Odeme.SelectedIndex > -1)
        {
            LBox_Odeme.Items.RemoveAt(LBox_Odeme.SelectedIndex);
        }
    }
}
