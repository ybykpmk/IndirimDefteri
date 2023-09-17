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
    /// The OdemePersonManager class is responsible for managing BO.OdemePerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class OdemeManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all OdemePerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Odeme person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static OdemeList GetList(Int32 pi_urun_id)
        {
            //şimdilik herkes seçebilir
            return OdemeDB.GetList(pi_urun_id);
        }

        /// <summary> 
        /// Gets a single OdemePerson from the database without its Odeme data.
        /// </summary>
        /// <param name="id">The ID of the Odeme person in the database.</param> 
        /// <returns>A OdemePerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single OdemePerson from the database without its Odeme data.
        /// </summary>
        /// <param name="id">The ID of the Odeme person in the database.</param> 
        /// <returns>A OdemePerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Odeme GetItem(Int32 pi_odeme_id)
        {
            //şimdilik herkes seçebilir
            Odeme myOdeme = OdemeDB.GetItem(pi_odeme_id);
            return myOdeme;
        }

        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myOdemePerson">The OdemePerson instance to save.</param> 
        /// <returns>The new ID if the OdemePerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Odeme myOdeme)
        {
            Int32 rows = OdemeDB.Insert(myOdeme);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myOdemePerson">The OdemePerson instance to save.</param> 
        /// <returns>The new ID if the OdemePerson is new in the database or the existing ID when an item was updated.</returns>

        /// <summary>
        /// Deletes a Odeme person from the database. 
        /// </summary> 
        /// <param name="myOdemePerson">The OdemePerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Odeme myOdeme)
        {
            return OdemeDB.Delete(myOdeme.Urun_id);
        }

        //delete öğrenci given id
        public static bool Delete(Int32 pi_urun_id)
        {
            return OdemeDB.Delete(pi_urun_id);
        }

        #endregion
    }
}