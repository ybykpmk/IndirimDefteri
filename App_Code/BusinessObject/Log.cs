using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Log tablosunun karşılığı
    public class Log
    {
        #region Private Variables
        private Int32 log_id = -1;
        private Int32 kullanici_id = -1;
        private string islem_host_ip = String.Empty;
        private DateTime islem_tarihi = DateTime.MinValue;
        private string islem = String.Empty;

        private string yon_kullanici_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Log_id { get { return log_id; } set { log_id = value; } }
        public Int32 Kullanici_id { get { return kullanici_id; } set { kullanici_id = value; } }
        public string Islem_host_ip { get { return islem_host_ip; } set { islem_host_ip = value; } }
        public DateTime Islem_tarihi { get { return islem_tarihi; } set { islem_tarihi = value; } }
        public string Islem { get { return islem; } set { islem = value; } }

        public string Yon_kullanici_adi { get { return yon_kullanici_adi; } set { yon_kullanici_adi = value; } }

        #endregion
    }
}
