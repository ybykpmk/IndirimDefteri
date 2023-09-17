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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DateTime ilkayittarihi = UrunManager.GetilkKayitTarihi();
            Int32 dongu_i = 0;
            Int32 col_i = 1;
            if (ilkayittarihi.Year == DateTime.Now.Year)
                dongu_i = ilkayittarihi.Month;
            else
                dongu_i = 1;
            Table CalenderTable = new Table();
            CalenderTable.CssClass = "dinamic_table";
            form1.Controls.Add(CalenderTable);
            TableRow caltbrow = new TableRow();
            CalenderTable.Controls.Add(caltbrow);
            for (int i = dongu_i; i <= 12; i++)
            {
                TableCell caltbcell = new TableCell();
                caltbcell.HorizontalAlign = HorizontalAlign.Center;
                caltbrow.Controls.Add(caltbcell);
                Calendar takvim = new Calendar();
                takvim.ID = "cal_" + i.ToString();
                takvim.ShowNextPrevMonth = false;
                takvim.TitleFormat = TitleFormat.Month;
                takvim.Attributes.Add("onselectionchanged", "Calendar_SelectionChanged");
                //takvim.Attributes["onselectionchanged"].
                if (i < 10)
                {
                    takvim.SelectMonthText = Convert.ToString("01.0" + i.ToString() + "." + DateTime.Now.Year.ToString());
                    takvim.VisibleDate = Convert.ToDateTime("01.0" + i.ToString() + "." + DateTime.Now.Year.ToString());
                }
                else
                {
                    takvim.SelectMonthText = Convert.ToString("01." + i.ToString() + "." + DateTime.Now.Year.ToString());
                    takvim.VisibleDate = Convert.ToDateTime("01." + i.ToString() + "." + DateTime.Now.Year.ToString());
                }
                caltbcell.Controls.Add(takvim);
                col_i++;
                if (col_i == 4)
                {
                    col_i = 1;
                    caltbrow = new TableRow();
                    CalenderTable.Controls.Add(caltbrow);
                }
            }
        }
    }


    protected void Calendar_SelectionChanged()
    {
        Response.Write ("tamam");
        Response.End();
    }
}
