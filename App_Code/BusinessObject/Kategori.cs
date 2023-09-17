using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Kategori tablosunun karşılığı
    public class Kategori
    {
        #region Private Variables
        private Int32 kategori_id = -1;
        private string kategori_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Kategori_id { get { return kategori_id; } set { kategori_id = value; } }
        public string Kategori_adi { get { return kategori_adi; } set { kategori_adi = value; } }

        #endregion
    }
}
