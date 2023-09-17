<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["ActiveUsers"] = 0;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        Application.Lock();
        Application["ActiveUsers"] = (int)Application["ActiveUsers"] + 1;
        Application.UnLock();
        string bugun = DateTime.Now.ToShortDateString();
        Ybyk.Nurun.BO.gunluk_erisim bugunku_erisim=Ybyk.Nurun.Bll.gunluk_erisimManager.GetItem(bugun);
        if (bugunku_erisim == null)
        {
            bugunku_erisim = new Ybyk.Nurun.BO.gunluk_erisim();
            bugunku_erisim.Gunun_tarihi = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            bugunku_erisim.Erisim_sayisi = 0;
            try
            {
                Ybyk.Nurun.Bll.gunluk_erisimManager.Insert(bugunku_erisim);
            }
            catch (Exception exc1)
            {
                Response.Write("Hata1! " + exc1.Message);
                return;
            }
        }
        else
        {
            bugunku_erisim.Erisim_sayisi = bugunku_erisim.Erisim_sayisi + 1;
            try
            {
                Ybyk.Nurun.Bll.gunluk_erisimManager.Update(bugunku_erisim);
            }
            catch (Exception exc2)
            {
                Response.Write("Hata2! " + exc2.Message);
                return;
            }
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["ActiveUsers"] = (int)Application["ActiveUsers"] - 1;
        Application.UnLock();
    }
       
</script>
