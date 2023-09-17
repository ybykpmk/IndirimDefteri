using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_gunluk_erisim tablosunun karşılığı
    public class gunluk_erisim
    {
        #region Private Variables
        private DateTime gunun_tarihi = DateTime.MinValue;
        private Int32 erisim_sayisi = -1;

        private string yon_kullanici_adi = String.Empty;

        #endregion
        #region Public Properties
        public DateTime Gunun_tarihi { get { return gunun_tarihi; } set { gunun_tarihi = value; } }
        public Int32 Erisim_sayisi { get { return erisim_sayisi; } set { erisim_sayisi = value; } }

        #endregion
    }
}
