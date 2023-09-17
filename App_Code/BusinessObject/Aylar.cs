using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Aylar tablosunun karşılığı
    public class Aylar
    {
        #region Private Variables
        private Int32 ay_id = -1;
        private string ay_bilgisi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Ay_id { get { return ay_id; } set { ay_id = value; } }
        public string Ay_bilgisi { get { return ay_bilgisi; } set { ay_bilgisi = value; } }

        #endregion
    }
}
