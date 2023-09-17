using System.Configuration;

namespace Ybyk.Nurun.Dal
{
    /// <summary>
    /// The AppConfiguaration class contains read-only properties that are essentially short cuts to settings in the web.config file.
    /// </summary>
    public static class AppConfiguration
    {

        #region Public Properties

        /// <summary>
        /// Returns the connectionstring  for the application. 
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
            }
        }

        public static string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["UserName"].ToString();
            }
        }

        public static string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["Password"].ToString();
            }
        }

        public static string ServerName
        {
            get
            {
                return ConfigurationManager.AppSettings["ServerName"].ToString();
            }
        }

        public static string ProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ApplicationServices"].ProviderName;
            }
        }

        #endregion

    }
}