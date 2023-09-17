using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Ozellik tablosunun karşılığı
    public class Ozellik
    {
        #region Private Variables
        private Int32 ozellik_id = -1;
        private string ozellik_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Ozellik_id { get { return ozellik_id; } set { ozellik_id = value; } }
        public string Ozellik_adi { get { return ozellik_adi; } set { ozellik_adi = value; } }

        #endregion
    }
}
