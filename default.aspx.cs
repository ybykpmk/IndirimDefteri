using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ybyk.Nurun.Bll;
using Ybyk.Nurun.BO;
using Ybyk.Nurun.Dal;
using System.Net.Mail;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Table tablom = new Table();
        //ImageButton imajbutonum = new ImageButton();
        //LinkButton LB_ark_hbr_ver = new LinkButton();
        //Urun urunum = new Urun();
        //string[] resim_adresi=new string[2];        
        //for (int gi = 0; gi < GridView1.Rows.Count; gi++)
        //{
        //    tablom = (Table)GridView1.Rows[gi].Cells[0].FindControl("Table1");
        //    imajbutonum = (ImageButton)tablom.Rows[3].Cells[0].FindControl("imajbuton");
        //    resim_adresi = imajbutonum.DescriptionUrl.Substring(3, imajbutonum.DescriptionUrl.Length - 3).Split('\\');
        //    resim_adresi[0] = resim_adresi[0] + "\\\\";
        //    imajbutonum.Attributes.Add("onclick", "showmodalpopup('" + resim_adresi[0] + resim_adresi[1] + "');");
        //    LB_ark_hbr_ver = (LinkButton)tablom.Rows[5].Cells[0].FindControl("LB_ark_hbr_ver");
        //    urunum = UrunManager.GetItem(Convert.ToInt32(LB_ark_hbr_ver.CommandArgument));
        //    if (urunum != null)
        //    {
        //        Doviz mydoviz = DovizManager.GetItem(urunum.Indirim_fiyati_doviz_id);
        //        LB_ark_hbr_ver.Attributes.Add("onclick", "showmodalpopup3('" + "Ürün adı: " + urunum.Urun_adi + " - " + urunum.Indirim_fiyati + " " + mydoviz.Doviz_adi + "');");
        //    }
        //}
        if (!Page.IsPostBack)
        {
            KategoriList kategori_listem = KategoriManager.GetList();
            DDL_kategori.Items.Add("");
            DDL_kategori.Items[0].Value = "0";
            Int32 i = 1;
            foreach (Kategori Kategorim in kategori_listem)
            {
                DDL_kategori.Items.Add(Kategorim.Kategori_adi);
                DDL_kategori.Items[i].Value = Kategorim.Kategori_id.ToString();
                i++;
            }
        }
    }

    protected string Sutun_Olustur1(string urunid,string indirim_bitis_tarihi, string urun_not1, string urun_not2, string urun_not3, string urun_not4, string urun_not5, string urun_saticisi_adi)
    {
        OdemeList urunodemelistesi = OdemeManager.GetList(Convert.ToInt32(urunid));
        string odemekosulu = "<br>";
        if (urunodemelistesi != null)
        {
            foreach (Odeme odemedurum in urunodemelistesi)
            {
                odemekosulu = odemekosulu + "<br>" + odemedurum.Odeme_aciklamasi;
            }
        }
        string lbl = "<br>Firma :" + urun_saticisi_adi + "<br><br>İndirim Bitiş Tarihi : " + (Convert.ToDateTime(indirim_bitis_tarihi)).ToShortDateString() + "<br>" + urun_not1 + "<br><font color='red'>" + urun_not2 + "</font><br><font color='blue'>" + urun_not3 + "</font>" + odemekosulu;
        return lbl;
    }

    protected string Resim_Olustur(string urun_resim_adresi)
    {
        return "<img src='" + urun_resim_adresi.Substring(3, urun_resim_adresi.Length - 3) + "' height='225' width='225'/>";
    }

    protected string Sutun_Olustur2(string indirim_fiyati, string liste_fiyati, string kargo, string urun_kayit_tarihi)
    {
        string kargo_img = "";
        if (kargo == "1")
            kargo_img = "<img src='images\\kargo.jpg' height='24' width='36'/>";
        if ((indirim_fiyati.Substring(0,4) != "0,00") && (liste_fiyati.Substring(0,4) != "0,00"))
        {
            Int32 lstindof = indirim_fiyati.LastIndexOf(" ");
            string ind_fyt = indirim_fiyati.Substring(0, lstindof);
            string yeni_int_fyt = "";
            for (int i = 0; i < lstindof; i++)
            {
                if (ind_fyt[i].ToString() != ",")
                {
                    yeni_int_fyt = yeni_int_fyt + ind_fyt[i].ToString();
                }
            }
            double dbl_ind_fyt = Convert.ToDouble(yeni_int_fyt);

            lstindof = liste_fiyati.LastIndexOf(" ");
            string list_fyt = liste_fiyati.Substring(0, lstindof);
            string yeni_list_fyt = "";
            for (int i = 0; i < lstindof; i++)
            {
                if (list_fyt[i].ToString() != ",")
                {
                    yeni_list_fyt = yeni_list_fyt + list_fyt[i].ToString();
                }
            }
            double dbl_list_fyt = Convert.ToDouble(yeni_list_fyt);

            double yuzde = (dbl_list_fyt - dbl_ind_fyt) / dbl_list_fyt;
            double carpim = yuzde * Convert.ToDouble("100");
            yuzde = Convert.ToDouble(carpim.ToString().Substring(0, carpim.ToString().LastIndexOf(",") + 2));
            return "<font style='text-decoration: line-through; font-size: 18px; font-family: Arial; font-weight: bold;color: red'>" + liste_fiyati + "</font><br><font style='font-size: 18px; font-family: Arial; font-weight: bold'>" + indirim_fiyati + "</font><br><br><font style='font-size: 18px; font-family: Arial; font-weight: bold;color:red'>% " + yuzde.ToString() + " indirim." + "</font><br>" + kargo_img + "<br><br><br><br><br><br><br><br><font color='navy' size='1px'>" + (Convert.ToDateTime(urun_kayit_tarihi)).ToShortDateString() + "</font>";
        }
        else
            return "<br>" + kargo_img;
    }
    protected string Sutun_Olustur3(string link, string urun_adi, string indirim_fiyati, string urun_ozellik_adi)
    {
        string sonuc = "";
        if (link != "")
        {
            if (indirim_fiyati.Substring(0,4) != "0,00")
                sonuc = "<a href='http://" + link + "' style='border-style: none; text-decoration: none' target='_blank'>" + urun_adi + " - " + indirim_fiyati + "&nbsp;<font style='color: #FF0000'>" + urun_ozellik_adi + "</font></a>";
            else
                sonuc = "<a href='http://" + link + "' style='border-style: none; text-decoration: none' target='_blank'>" + urun_adi + "&nbsp;<font style='color: #FF0000'>" + urun_ozellik_adi + "</font></a>";
        }
        else
        {
            if (indirim_fiyati.Substring(0, 4) != "0,00")
                sonuc = "<a style='border-style: none; text-decoration: none; color: #3388FF'>" + urun_adi + " - " + indirim_fiyati + "&nbsp;<font style='color: #FF0000'>" + urun_ozellik_adi + "</font></a>";
            else
                sonuc = "<a style='border-style: none; text-decoration: none; color: #3388FF'>" + urun_adi + "&nbsp;<font style='color: #FF0000'>" + urun_ozellik_adi + "</font></a>";
        }
        return sonuc;
    }
    protected void btn_Gonder_Click(object sender, EventArgs e)
    {
        if (Txt_cpha.Text == Session["randomsitecphaStr"].ToString())
        {
            //MailMessage msgMail = new MailMessage();

            //msgMail.To = "urundefteri@gmail.com";
            ////msgMail.Cc = "urundefteri@gmail.com";
            //msgMail.From = Txt_eposta.Text;
            //msgMail.Subject = DDL_dh_ucz_var.SelectedValue;

            //msgMail.Body = Txt_Mesaj.Text;

            //SmtpMail.Send(msgMail);
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                MailAddress fromAddress = new MailAddress("admin@indirimdefteri.com", "Indirimdefteri.com ziyaretçisi");
                smtpClient.Credentials = new System.Net.NetworkCredential("admin@indirimdefteri.com", "Nt123456!");
                // You can specify the host name or ipaddress of your server

                // Default in IIS will be localhost 
                
                smtpClient.Host = "relay-hosting.secureserver.net";

                //Default port will be 25

                smtpClient.Port = 25;//server ın mail portu

                //From address will be given as a MailAddress Object

                message.From = fromAddress;

                // To address collection of MailAddress

                message.To.Add("admin@indirimdefteri.com");
                message.Subject = DDL_dh_ucz_var.SelectedValue;

                // CC and BCC optional

                // MailAddressCollection class is used to send the email to various users

                // You can specify Address as new MailAddress("admin1@yoursite.com")

                //message.CC.Add("admin1@yoursite.com");
                //message.CC.Add("admin2@yoursite.com");

                // You can specify Address directly as string

                //message.Bcc.Add(new MailAddress("admin3@yoursite.com"));
                //message.Bcc.Add(new MailAddress("admin4@yoursite.com"));

                //Body can be Html or text format

                //Specify true if it  is html message

                message.IsBodyHtml = true;

                // Message body content

                message.Body = "Konu:" + Txt_konu.Text + "<br>Mesaj: " + Txt_Mesaj.Text + "<br>Gönderen adı: " + Txt_Adi.Text + "<br>E-posta adresi:" + Txt_eposta.Text;

                // Send SMTP mail

                smtpClient.Send(message);

                //lblStatus.Text = "Email successfully sent.";
            }
            catch (Exception ex)
            {
                Response.Write("E-posta gönderilemedi. Hata: " + ex.Message);
                Response.End();
            }

            dh_ucuzu_var_temizle();
        }
    }
    protected void dh_ucuzu_var_temizle()
    {
        Txt_Adi.Text = "";
        Txt_eposta.Text = "";
        Txt_konu.Text = "";
        Txt_Mesaj.Text = "";
        Txt_URL.Text = "";
    }
    protected void Btn_ark_hrb_ver_gonder_Click(object sender, EventArgs e)
    {
        if (Txt_ark_hbr_ver_cpha.Text == Session["randomsitecphaStr"].ToString())
        {
            //MailMessage msgMail = new MailMessage();

            //msgMail.To = "urundefteri@gmail.com";
            ////msgMail.Cc = "urundefteri@gmail.com";
            //msgMail.From = Txt_eposta.Text;
            //msgMail.Subject = DDL_dh_ucz_var.SelectedValue;

            //msgMail.Body = Txt_Mesaj.Text;

            //SmtpMail.Send(msgMail);
            string[] mailArray = new string[10];
            mailArray[0] = Txt_ark_ad1.Text;
            mailArray[1] = Txt_ark_eposta1.Text;
            Int32 arrayi = 1;
            if ((Txt_ark_ad2.Text.Trim() != "") && (Txt_ark_eposta2.Text.Trim() != ""))
            {
                mailArray[++arrayi] = Txt_ark_ad2.Text;
                mailArray[++arrayi] = Txt_ark_eposta2.Text;
            }
            if ((Txt_ark_ad3.Text.Trim() != "") && (Txt_ark_eposta3.Text.Trim() != ""))
            {
                mailArray[++arrayi] = Txt_ark_ad3.Text;
                mailArray[++arrayi] = Txt_ark_eposta3.Text;
            }
            if ((Txt_ark_ad4.Text.Trim() != "") && (Txt_ark_eposta4.Text.Trim() != ""))
            {
                mailArray[++arrayi] = Txt_ark_ad4.Text;
                mailArray[++arrayi] = Txt_ark_eposta4.Text;
            }
            if ((Txt_ark_ad5.Text.Trim() != "") && (Txt_ark_eposta5.Text.Trim() != ""))
            {
                mailArray[++arrayi] = Txt_ark_ad5.Text;
                mailArray[++arrayi] = Txt_ark_eposta5.Text;
            }
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            for (int i = 0; i <= arrayi; i++)
            {
                try
                {
                    MailAddress fromAddress = new MailAddress("admin@indirimdefteri.com", "admin@indirimdefteri.com");
                    smtpClient.Credentials = new System.Net.NetworkCredential("admin@indirimdefteri.com", "Nt123456!");
                    smtpClient.Host = "relay-hosting.secureserver.net";

                    smtpClient.Port = 25;//server ın mail portu

                    message.From = fromAddress;
                    message.To.Add(mailArray[i + 1]);
                    message.Subject = "Fırsat Ürünü";

                    message.IsBodyHtml = true;

                    string urunURL = "";

                    Urun urunum = UrunManager.GetItem(Convert.ToInt32(Request.QueryString["ark_hbr_ver_id"]));
                    if (urunum != null)
                    {
                        Doviz mydoviz = DovizManager.GetItem(urunum.Indirim_fiyati_doviz_id);
                        urunURL = "<a href='http://" + urunum.Link + "' style='border-style: none; text-decoration: none' target='_blank'>Ürün adı: " + urunum.Urun_adi + " - " + urunum.Indirim_fiyati + " " + mydoviz.Doviz_adi + "</a>";
                    }

                    message.Body = "Sayın " + mailArray[i] + "," + Txt_eposta_ark_hbr_ver.Text + " e-posta adresini kullanan " + Txt_ad_ark_hbr_ver.Text + " isimli arkadaşınız aşağıda URL si bulunan indirimli ürünü size haber vermek istemiştir.<br>" + urunURL;

                    smtpClient.Send(message);
                    i++;
                }
                catch (Exception ex)
                {
                    Response.Write("E-posta gönderilemedi. Hata: " + ex.Message);
                    Response.End();
                }
            }
            ark_hrb_ver_gonder_temizle();
        }
    }
    protected void ark_hrb_ver_gonder_temizle()
    {
        Txt_Adi.Text = "";
        Txt_eposta.Text = "";
        Txt_konu.Text = "";
        Txt_Mesaj.Text = "";
        Txt_URL.Text = "";
    }
    protected void btn_Ara_Click(object sender, EventArgs e)
    {
        //ObjectDataSource1.SelectMethod = "GetList_ForSiteArama";
        if ((Txt_anh_szck.Text != "") || (DDL_kategori.SelectedIndex != 0))
        {
            ObjectDataSource1.SelectParameters.Clear();
            if (DDL_kategori.SelectedIndex != 0)
                ObjectDataSource1.SelectParameters.Add("pi_kategori_id", DDL_kategori.SelectedValue);
            else
                ObjectDataSource1.SelectParameters.Add("pi_kategori_id", "0");
            if (Txt_anh_szck.Text.Trim() != "")
                ObjectDataSource1.SelectParameters.Add("pi_urun_adi", Txt_anh_szck.Text);
            else
                ObjectDataSource1.SelectParameters.Add("pi_urun_adi", "");
            GridView1.DataBind();
            lblAramaSonucu.Text = "ARAMA SONUCU";
            lblAramaSonucu.CssClass = "arama_sonucu_baslik";
        }
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        Table tablom = new Table();
        ImageButton imajbutonum = new ImageButton();
        LinkButton LB_ark_hbr_ver = new LinkButton();
        Urun urunum = new Urun();
        string[] resim_adresi = new string[2];
        for (int gi = 0; gi < GridView1.Rows.Count; gi++)
        {
            tablom = (Table)GridView1.Rows[gi].Cells[0].FindControl("Table1");
            imajbutonum = (ImageButton)tablom.Rows[3].Cells[0].FindControl("imajbuton");
            resim_adresi = imajbutonum.DescriptionUrl.Substring(3, imajbutonum.DescriptionUrl.Length - 3).Split('\\');
            resim_adresi[0] = resim_adresi[0] + "\\\\";
            imajbutonum.Attributes.Add("onclick", "showmodalpopup('" + resim_adresi[0] + resim_adresi[1] + "');");
            LB_ark_hbr_ver = (LinkButton)tablom.Rows[5].Cells[0].FindControl("LB_ark_hbr_ver");
            urunum = UrunManager.GetItem(Convert.ToInt32(LB_ark_hbr_ver.CommandArgument));
            if (urunum != null)
            {
                Doviz mydoviz = DovizManager.GetItem(urunum.Indirim_fiyati_doviz_id);
                LB_ark_hbr_ver.Attributes.Add("onclick", "showmodalpopup3('" + "Ürün adı: " + urunum.Urun_adi + " - " + urunum.Indirim_fiyati + " " + mydoviz.Doviz_adi + "');");
            }
        }

        //e.Row.Cells[
    }
}

