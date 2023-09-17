using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Web.Security;
using MySql.Data.MySqlClient;

using Ybyk.Nurun.BO;
using Ybyk.Nurun.Dal;

namespace Ybyk.Nurun.Bll
{
    /// <summary>
    /// The OzellikPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class OzellikManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Ozellik person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static OzellikList GetList()
        {
            //şimdilik herkes seçebilir
            return OzellikDB.GetList();
        }

        /// <summary> 
        /// Gets a single OzellikPerson from the database without its Ozellik data.
        /// </summary>
        /// <param name="id">The ID of the Ozellik person in the database.</param> 
        /// <returns>A OzellikPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Ozellik GetItem(Int32 pi_ozellik_id)
        {
            //şimdilik herkes seçebilir
            Ozellik myOzellik = OzellikDB.GetItem(pi_ozellik_id);
            return myOzellik;
        }
        /// <summary> 
        /// Gets a single OzellikPerson from the database without its Ozellik data.
        /// </summary>
        /// <param name="id">The ID of the Ozellik person in the database.</param> 
        /// <returns>A OzellikPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>

        #endregion
    }
}