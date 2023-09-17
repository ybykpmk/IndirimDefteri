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
        //ObjectDataSource1.SelectParameters.Clear();
        //ObjectDataSource1.SelectParameters.Add("pi_bastar", "1901-01-01");
        //ObjectDataSource1.SelectParameters.Add("pi_bittar", "3999-12-31");
        //GridView1.DataBind();
    }
    public void btn_sorgula_Click(object sender, EventArgs e)
    {
        if (((Txt_bas_trh.Text != null) & (Txt_bas_trh.Text != "")) & ((Txt_bit_trh.Text != null) & (Txt_bit_trh.Text != "")))
        {
            ObjectDataSource1.SelectParameters.Clear();
            ObjectDataSource1.SelectParameters.Add("pi_bastar", Convert.ToDateTime(Txt_bas_trh.Text).ToString("yyyy-MM-dd"));
            ObjectDataSource1.SelectParameters.Add("pi_bittar", Convert.ToDateTime(Txt_bit_trh.Text).ToString("yyyy-MM-dd"));
            GridView1.DataBind();
        }
    }
}
