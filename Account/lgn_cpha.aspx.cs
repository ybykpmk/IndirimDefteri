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
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;


public partial class lgn_cpha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            Bitmap objBMP = new System.Drawing.Bitmap(195, 42);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.BlueViolet);
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            //' Configure font to use for text
            Font objFont = new Font("Bradley Hand ITC", 24, FontStyle.Regular);
            string randomlgnStr = "";
            string[] secilecekArray = { "a", "b", "c", "d", "e", "f", "h", "i", "j", "k", "n", "p", "r", "t", "u", "v", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8" };
            string[] mystrArray = new string[8];
            Int32 x;
            //That is to create the random # and add it to our string
            Random autoRand = new Random();
            for (x = 0; x < 8; x++)
            {
                mystrArray[x] = secilecekArray[System.Convert.ToInt32(autoRand.Next(0, 26))];
                randomlgnStr += (mystrArray[x].ToString());
            }
            //This is to add the string to session cookie, to be compared later
            Session.Add("randomlgnStr", randomlgnStr);
            //' Write out the text
            objGraphics.DrawString(randomlgnStr, objFont, Brushes.White, 20, -2);
            //' Set the content type and return the image
            Response.ContentType = "image/GIF";
            objBMP.Save(Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            objGraphics.Dispose();
            objBMP.Dispose();

    } 

   
}
   
   

