using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Doviz tablosunun karşılığı
    public class Odeme
    {
        #region Private Variables
        private Int32 odeme_id = -1;
        private string odeme_aciklamasi = String.Empty;
        private Int32 urun_id = -1;

        #endregion
        #region Public Properties
        public Int32 Odeme_id { get { return odeme_id; } set { odeme_id = value; } }
        public string Odeme_aciklamasi { get { return odeme_aciklamasi; } set { odeme_aciklamasi = value; } }
        public Int32 Urun_id { get { return urun_id; } set { urun_id = value; } }

        #endregion
    }
}
