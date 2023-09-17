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
    /// The AylarPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class AylarManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Aylar person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static AylarList GetList()
        {
            //şimdilik herkes seçebilir
            return AylarDB.GetList();
        }

        /// <summary> 
        /// Gets a single AylarPerson from the database without its Aylar data.
        /// </summary>
        /// <param name="id">The ID of the Aylar person in the database.</param> 
        /// <returns>A AylarPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single AylarPerson from the database without its Aylar data.
        /// </summary>
        /// <param name="id">The ID of the Aylar person in the database.</param> 
        /// <returns>A AylarPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>

        #endregion
    }
}