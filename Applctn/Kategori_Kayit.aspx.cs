using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.BO;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lstleri_olustur(sender, e);
            Lstbox_kategori.SelectedIndex = 0;
            Lstbox_kategori_SelectedIndexChanged(sender, e);
        }
    }

    public void lstleri_olustur(object sender, EventArgs e)
    {
        Lstbox_kategori.Items.Clear();
        KategoriList kategori_listem = KategoriManager.GetList();
        Int32 i = 0;
        if (kategori_listem != null)
        {
            foreach (Kategori Kategorim in kategori_listem)
            {
                Lstbox_kategori.Items.Add(Kategorim.Kategori_adi);
                Lstbox_kategori.Items[i].Value = Kategorim.Kategori_id.ToString();
                i++;
            }
        }
        else
            Lbl_kat_Kul_sys.Text = "";
    }

    public void Lstbox_kategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 count = 0;
        Lstbox_altkategori.Items.Clear();
        Alt_kategoriList altkategori_listem = Alt_kategoriManager.GetList(Convert.ToInt32(Lstbox_kategori.Items[Lstbox_kategori.SelectedIndex].Value));
        if (altkategori_listem != null)
        {
            Int32 i = 0;
            foreach (Alt_kategori Alt_kategorim in altkategori_listem)
            {
                Lstbox_altkategori.Items.Add(Alt_kategorim.Alt_kategori_adi);
                Lstbox_altkategori.Items[i].Value = Alt_kategorim.Alt_kategori_id.ToString();
                i++;
            }
        }
        count = UrunManager.GetKategoriCount(Convert.ToInt32(Lstbox_kategori.SelectedValue));
        txt_kategorigunc.Enabled = true;
        txt_kategorigunc.Text = Lstbox_kategori.SelectedItem.Text;
        txt_kategorisil.Text = Lstbox_kategori.SelectedItem.Text;
        if (count > 0)
        {
            btn_kategorisil.Enabled = false;
            Chckbox_kategorisil.Enabled = false;
            txt_kategorisil.Enabled = false;
            Lbl_kat_Kul_sys.Text = count.ToString()+",silme işlemi yapılamaz";
        }
        else
        {
            btn_kategorisil.Enabled = true;
            Chckbox_kategorisil.Enabled = true;
            txt_kategorisil.Enabled = true;
            Lbl_kat_Kul_sys.Text = count.ToString();
        }
        btn_kategoriguncelle.Enabled = true;
        Chckbox_kategorigunc.Enabled = true;
        Chckbox_kategorigunc.Checked = false;
        Chckbox_kategorisil.Checked = false;

        if (Lstbox_altkategori.Items.Count > 0)
        {
            Lstbox_altkategori.SelectedIndex = Lstbox_altkategori.Items.Count - 1;
            Lstbox_altkategori_SelectedIndexChanged(sender, e);
        }
        else
        {
            txt_altkategorigunc.Enabled = false;
            txt_altkategorisil.Enabled = false;
            btn_altkategoriguncelle.Enabled = false;
            btn_altkategorisil.Enabled = false;
            Chckbox_altkategorigunc.Enabled = false;
            Chckbox_altkategorisil.Enabled = false;
            Lbl_alt_kat_Kul_sys.Text = "";

            txt_altkategorigunc.Text = "";
            txt_altkategorisil.Text = "";
            Chckbox_altkategorigunc.Checked = false;
            Chckbox_altkategorisil.Checked = false;
        }
    }
    public void Lstbox_altkategori_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 count = 0;
        txt_altkategorigunc.Enabled = true;
        txt_altkategorigunc.Text = Lstbox_altkategori.SelectedItem.Text;
        txt_altkategorisil.Text = Lstbox_altkategori.SelectedItem.Text;
        btn_altkategoriguncelle.Enabled = true;
        Chckbox_altkategorigunc.Enabled = true;
        Chckbox_altkategorigunc.Checked = false;
        Chckbox_altkategorisil.Checked = false;
        count = UrunManager.GetAltKategoriCount(Convert.ToInt32(Lstbox_altkategori.SelectedValue));
        if (count > 0)
        {
            btn_altkategorisil.Enabled = false;
            Chckbox_altkategorisil.Enabled = false;
            txt_altkategorisil.Enabled = false;
            Lbl_alt_kat_Kul_sys.Text = count.ToString() + ",silme işlemi yapılamaz";
        }
        else
        {
            btn_altkategorisil.Enabled = true;
            Chckbox_altkategorisil.Enabled = true;
            txt_altkategorisil.Enabled = true;
            Lbl_alt_kat_Kul_sys.Text = count.ToString();
        }
    }
    public void btn_kategoriekle_Click(object sender, EventArgs e)
    {
        if (txt_kategori.Text.Trim() != "")
        {
            Int32 kategorisonucu = 0;
            try
            {
                kategorisonucu = KategoriManager.GetItem(txt_kategori.Text.Trim());
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1! " + exc1.Message);
                return;
            }
            if (kategorisonucu < 0)
            {
                try
                {
                    Kategori kategorim = new Kategori();
                    kategorim.Kategori_adi = txt_kategori.Text.Trim();
                    kategorisonucu=KategoriManager.Insert(kategorim);
                    if (kategorisonucu > 0)
                    {
                        try
                        {
                            Log kayitlogu = new Log();
                            kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                            kayitlogu.Islem_tarihi = DateTime.Now;
                            kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                            kayitlogu.Islem = "Kategori kayıt işlemini gerçekleştirdi.";
                            LogManager.Insert(kayitlogu);
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
                txt_kategori.Text = "";
                lstleri_olustur(sender, e);
                Lstbox_kategori.SelectedIndex = Lstbox_kategori.Items.Count - 1;
                Lstbox_kategori_SelectedIndexChanged(sender, e);
                Lbl_kayit_sonucu.Text = "<font color='navy'>Kategori eklendi.</font>";
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Eklemek istediğiniz kategori mevcut: " + Request.QueryString["mtn"] + "</font>";
        }
    }
    public void btn_altkategoriekle_Click(object sender, EventArgs e)
    {
        if (txt_altkategori.Text.Trim() != "")
        {
            Int32 altkategorisonucu = 0;
            try
            {
                altkategorisonucu = Alt_kategoriManager.GetItem(txt_altkategori.Text.Trim());
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1! " + exc1.Message);
                return;
            }
            if (altkategorisonucu < 0)
            {
                try
                {
                    Alt_kategori altkategorim = new Alt_kategori();
                    altkategorim.Alt_kategori_adi = txt_altkategori.Text.Trim();
                    altkategorim.Kategori_id = Convert.ToInt32(Lstbox_kategori.SelectedValue);
                    altkategorisonucu = Alt_kategoriManager.Insert(altkategorim);
                    if (altkategorisonucu > 0)
                    {
                        try
                        {
                            Log kayitlogu = new Log();
                            kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                            kayitlogu.Islem_tarihi = DateTime.Now;
                            kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                            kayitlogu.Islem = "Alt kategori kayıt işlemini gerçekleştirdi.";
                            LogManager.Insert(kayitlogu);
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
                txt_altkategori.Text = "";
                Lstbox_kategori.SelectedIndex = Lstbox_kategori.Items.Count - 1;
                Lstbox_kategori_SelectedIndexChanged(sender, e);
                Lbl_kayit_sonucu.Text = "<font color='navy'>Alt kategori eklendi.</font>";
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Eklemek istediğiniz alt kategori mevcut: " + Request.QueryString["mtn"] + "</font>";
        }
    }
    public void btn_kategoriguncelle_Click(object sender, EventArgs e)
    {
        if ((txt_kategorigunc.Text.Trim() != null) & (txt_kategorigunc.Text.Trim() != "") & (Chckbox_kategorigunc.Checked))
        {
            Int32 guncsonucu = -1;
            string selected_value = "";
            try
            {
                Kategori gunc_kategori = KategoriManager.GetItem(Convert.ToInt32(Lstbox_kategori.SelectedItem.Value));
                selected_value = Lstbox_kategori.SelectedItem.Value;
                gunc_kategori.Kategori_adi = txt_kategorigunc.Text.Trim();
                guncsonucu = KategoriManager.Update(gunc_kategori);
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1: " + exc1.Message);
                return;
            }
            if (guncsonucu > 0)
            {
                try
                {
                    Log kayitlogu = new Log();
                    kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                    kayitlogu.Islem_tarihi = DateTime.Now;
                    kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                    kayitlogu.Islem = "Kategori kayıt güncelleme işlemini gerçekleştirdi.";
                    LogManager.Insert(kayitlogu);
                }
                catch (Exception exc2)
                {
                    Response.Write("Hata2! " + exc2.Message);
                    return;
                }
                Lbl_kayit_sonucu.Text = "<font color='navy'>Kategori guncellendi.</font>";
                lstleri_olustur(sender, e);
                Lstbox_kategori.SelectedValue = selected_value;
                Lstbox_kategori_SelectedIndexChanged(sender, e);
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Kategori guncellenemedi!</font>";
        }
    }
    public void btn_altkategoriguncelle_Click(object sender, EventArgs e)
    {
        if ((txt_altkategorigunc.Text.Trim() != null) & (txt_altkategorigunc.Text.Trim() != "") & (Chckbox_altkategorigunc.Checked))
        {
            Int32 guncsonucu = -1;
            try
            {
                Alt_kategori gunc_altkategori = Alt_kategoriManager.GetItem(Convert.ToInt32(Lstbox_altkategori.SelectedItem.Value));
                gunc_altkategori.Alt_kategori_adi = txt_altkategorigunc.Text.Trim();
                guncsonucu = Alt_kategoriManager.Update(gunc_altkategori);
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1: " + exc1.Message);
                return;
            }
            if (guncsonucu > 0)
            {
                try
                {
                    Log kayitlogu = new Log();
                    kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                    kayitlogu.Islem_tarihi = DateTime.Now;
                    kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                    kayitlogu.Islem = "Alt kategori kayıt güncelleme işlemini gerçekleştirdi.";
                    LogManager.Insert(kayitlogu);
                }
                catch (Exception exc2)
                {
                    Response.Write("Hata2! " + exc2.Message);
                    return;
                }
                Lbl_kayit_sonucu.Text = "<font color='navy'>Alt kategori guncellendi.</font>";
                Lstbox_kategori_SelectedIndexChanged(sender, e);
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Alt kategori guncellenemedi!</font>";
        }
    }
    public void btn_kategorisil_Click(object sender, EventArgs e)
    {
        if ((txt_kategorisil.Text.Trim() != null) & (txt_kategorisil.Text.Trim() != "") & (Chckbox_kategorisil.Checked))
        {
            bool silmesonucu = false;
            try
            {
                silmesonucu = KategoriManager.Delete(Convert.ToInt32(Lstbox_kategori.SelectedItem.Value));
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1: " + exc1.Message);
                return;
            }
            if (silmesonucu)
            {
                try
                {
                    Log kayitlogu = new Log();
                    kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                    kayitlogu.Islem_tarihi = DateTime.Now;
                    kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                    kayitlogu.Islem = "Kategori kayıt silme işlemini gerçekleştirdi.";
                    LogManager.Insert(kayitlogu);
                }
                catch (Exception exc2)
                {
                    Response.Write("Hata2! " + exc2.Message);
                    return;
                }
                Lbl_kayit_sonucu.Text = "<font color='navy'>Kategori silindi.</font>";

                lstleri_olustur(sender, e);
                if (Lstbox_kategori.Items.Count > 0)
                {
                    Lstbox_kategori.SelectedIndex = Lstbox_kategori.Items.Count - 1;
                    Lstbox_kategori_SelectedIndexChanged(sender, e);
                }
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Kategori silinemedi!</font>";
        }
    }
    public void btn_altkategorisil_Click(object sender, EventArgs e)
    {
        if ((txt_altkategorisil.Text.Trim() != null) & (txt_altkategorisil.Text.Trim() != "") & (Chckbox_altkategorisil.Checked))
        {
            bool silmesonucu = false;
            try
            {
                silmesonucu = Alt_kategoriManager.Delete(Convert.ToInt32(Lstbox_altkategori.SelectedItem.Value));
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1: " + exc1.Message);
                return;
            }
            if (silmesonucu)
            {
                try
                {
                    Log kayitlogu = new Log();
                    kayitlogu.Islem_host_ip = HttpContext.Current.Request.UserHostAddress;
                    kayitlogu.Islem_tarihi = DateTime.Now;
                    kayitlogu.Kullanici_id = (Session["User"] as yonetici).Yonetici_id;
                    kayitlogu.Islem = "Alt kategori kayıt silme işlemini gerçekleştirdi.";
                    LogManager.Insert(kayitlogu);
                }
                catch (Exception exc2)
                {
                    Response.Write("Hata2! " + exc2.Message);
                    return;
                }
                Lbl_kayit_sonucu.Text = "<font color='navy'>Alt kategori silindi.</font>";
                Lstbox_kategori_SelectedIndexChanged(sender, e);
            }
            else
                Lbl_kayit_sonucu.Text = "<font color='red'>Alt kategori silinemedi!</font>";
        }
    }
}
