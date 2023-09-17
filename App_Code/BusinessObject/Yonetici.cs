using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_yonetici tablosunun karşılığı
    public class yonetici
    {
        #region Private Variables
        private Int32 yonetici_id = -1;
        private string yonetici_adi = String.Empty;
        private string yonetici_soyadi = String.Empty;
        private string yon_kullanici_adi = String.Empty;
        private string yon_kullanici_parola = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Yonetici_id { get { return yonetici_id; } set { yonetici_id = value; } }
        public string Yonetici_adi { get { return yonetici_adi; } set { yonetici_adi = value; } }
        public string Yonetici_soyadi { get { return yonetici_soyadi; } set { yonetici_soyadi = value; } }
        public string Yon_kullanici_adi { get { return yon_kullanici_adi; } set { yon_kullanici_adi = value; } }
        public string Yon_kullanici_parola { get { return yon_kullanici_parola; } set { yon_kullanici_parola = value; } }

        #endregion
    }
}
