using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Kart tablosunun karşılığı
    public class Kart
    {
        #region Private Variables
        private Int32 kart_id = -1;
        private string kart_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Kart_id { get { return kart_id; } set { kart_id = value; } }
        public string Kart_adi { get { return kart_adi; } set { kart_adi = value; } }

        #endregion
    }
}
