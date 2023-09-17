using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Alt_kategori tablosunun karşılığı
    public class Alt_kategori
    {
        #region Private Variables
        private Int32 alt_kategori_id = -1;
        private string alt_kategori_adi = String.Empty;
        private Int32 kategori_id = -1;


        #endregion
        #region Public Properties
        public Int32 Alt_kategori_id { get { return alt_kategori_id; } set { alt_kategori_id = value; } }
        public string Alt_kategori_adi { get { return alt_kategori_adi; } set { alt_kategori_adi = value; } }
        public Int32 Kategori_id { get { return kategori_id; } set { kategori_id = value; } }

        #endregion
    }
}
