using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["islem"] == "Gunc")
        {
            Lbl_sonuc.Text = "<font color='navy'>Kayıt güncelleme işlemi gerçekleşti.</font>";
        }
        if (Request.QueryString["islem"] == "Sil")
        {
            Lbl_sonuc.Text = "<font color='navy'>Kayıt silme işlemi gerçekleşti.</font>";
        }
        if (!IsPostBack)
        {
            DDL_Srlm_Olct.Items.Add("Ürün Adı");
            DDL_Srlm_Olct.Items[0].Value = "Urun_adi";
            DDL_Srlm_Olct.Items.Add("Kategori Adı");
            DDL_Srlm_Olct.Items[1].Value = "Kategori_adi";
            DDL_Srlm_Olct.Items.Add("Alt kategori Adı");
            DDL_Srlm_Olct.Items[2].Value = "Alt_kategori_adi";
            DDL_Srlm_Olct.Items.Add("Liste Fiyatı");
            DDL_Srlm_Olct.Items[3].Value = "Liste_fiyati";
            DDL_Srlm_Olct.Items.Add("İndirim Fiyatı");
            DDL_Srlm_Olct.Items[4].Value = "Indirim_fiyati";
            DDL_Srlm_Olct.Items.Add("İndirim Bitiş Tarihi");
            DDL_Srlm_Olct.Items[5].Value = "Indirim_bitis_tarihi";
            DDL_Srlm_Olct.Items.Add("Yayın Durumu");
            DDL_Srlm_Olct.Items[6].Value = "Urun_onay";
            DDL_Srlm_Olct.Items.Add("Kayıt Tarihi");
            DDL_Srlm_Olct.Items[7].Value = "Urun_kayit_tarihi";
            DDL_Srlm_Olct.Items.Add("Kayıt Yapan");
            DDL_Srlm_Olct.Items[8].Value = "Yon_kullanici_adi";
        }
    }
    public string CheckURLGunc(string myurun_id)
    {
        string myurl = "Gunc_Islem.aspx?urun_no=" + myurun_id;
        return myurl;
    }

    public string CheckURLSil(string myurun_id)
    {
        string myurl = "Sil_Islem.aspx?urun_no=" + myurun_id;
        return myurl;
    }
    //public string GetMyHashCode(string myurun_id)
    //{
    //    //Int32 sayim = Convert.ToInt32("1" + myurun_id);
    //    Int32[] ModArray={19,17,15,13,11,9,7,5,3};
    //    string[] CharArray = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "T", "U", "V", "W", "X",};
    //    Int32 Modi;
    //    string URLHashCode = "";
    //    double bolum=0;
    //    double bolen = 0;
    //    Int64 sayim = 0;
    //    for (Modi = 0; Modi < ModArray.Length; Modi++)
    //    {
    //        if ((Convert.ToInt32("1" + myurun_id) / ModArray[Modi]) != 0)
    //        {
    //            bolum = Convert.ToInt32("1" + myurun_id) / ModArray[Modi];
    //            sayim = Convert.ToInt32("1" + myurun_id) / ModArray[Modi];
    //            bolen = (bolum - sayim)*ModArray[Modi];
    //            break;
    //        }
    //        Modi++;
    //        if (Modi == ModArray.Length - 1)
    //        {
    //            break;
    //            sayim = 23;
    //            bolum = 0;
    //            bolen = 0;
    //        }
    //    }        
    //    sayim = sayim * sayim;
    //    sayim = Convert.ToInt32("2" + sayim.ToString());
    //    sayim = sayim * sayim;
    //    sayim = Convert.ToInt32("3" + sayim.ToString());
    //    sayim = sayim * sayim;
    //    URLHashCode = bolum.ToString() + "Xm" + "Xn" + bolen.ToString() + "X";
    //    for (int i = 0; i < sayim.ToString().Length; i=i+2)
    //    {
    //        URLHashCode=URLHashCode+CharArray[Convert.ToInt32(sayim.ToString().Substring(i,2)) % 34];
    //    }
    //    return URLHashCode;
    //}
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1)
        {
            if (e.Row.Cells[8].Text == "0")
            {
                e.Row.Cells[8].Text = "Yayında Değil";
                e.Row.BackColor = System.Drawing.Color.Moccasin;
            }
            else if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToShortDateString()),Convert.ToDateTime(e.Row.Cells[7].Text)) > -1)
            {
                e.Row.Cells[8].Text = "Yayında,süre bitmiş";
                e.Row.BackColor = System.Drawing.Color.LightCyan;
            }
            else
            {
                e.Row.Cells[8].Text = "Yayında";
                e.Row.BackColor = System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.WhiteSmoke);
            }
        }
    }
    public void btn_sorgula_Click(object sender, EventArgs e)
    {
        if (((Txt_bas_trh.Text != null) & (Txt_bas_trh.Text != "")) & ((Txt_bit_trh.Text != null) & (Txt_bit_trh.Text != "")) || (DDL_Srlm_Olct.SelectedIndex > -1))
        {
            ObjectDataSource1.SelectParameters.Clear();
            if (((Txt_bas_trh.Text != null) & (Txt_bas_trh.Text != "")) & ((Txt_bit_trh.Text != null) & (Txt_bit_trh.Text != "")))
            {
                ObjectDataSource1.SelectParameters.Add("pi_bastar", Convert.ToDateTime(Txt_bas_trh.Text).ToString("yyyy-MM-dd"));
                ObjectDataSource1.SelectParameters.Add("pi_bittar", Convert.ToDateTime(Txt_bit_trh.Text).ToString("yyyy-MM-dd"));
            }
            else
            {
                ObjectDataSource1.SelectParameters.Add("pi_bastar", Convert.ToDateTime("01.01.1900").ToString("yyyy-MM-dd"));
                ObjectDataSource1.SelectParameters.Add("pi_bittar", Convert.ToDateTime("31.12.9999").ToString("yyyy-MM-dd"));
            }
            ObjectDataSource1.SelectParameters.Add("pi_siralama", DDL_sira.SelectedValue);
            if (DDL_Srlm_Olct.SelectedIndex > -1)
            {
                ObjectDataSource1.SelectParameters.Add("pi_orderby", DDL_Srlm_Olct.SelectedValue);
            }
            else
            {
                ObjectDataSource1.SelectParameters.Add("pi_orderby", "Urun_adi");
            }
            GridView1.DataBind();
        }
    }
}
