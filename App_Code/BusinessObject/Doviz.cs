using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Doviz tablosunun karşılığı
    public class Doviz
    {
        #region Private Variables
        private Int32 doviz_id = -1;
        private string doviz_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Doviz_id { get { return doviz_id; } set { doviz_id = value; } }
        public string Doviz_adi { get { return doviz_adi; } set { doviz_adi = value; } }

        #endregion
    }
}
