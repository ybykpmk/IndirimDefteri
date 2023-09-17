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
    /// The DovizPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class DovizManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Doviz person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DovizList GetList()
        {
            //şimdilik herkes seçebilir
            return DovizDB.GetList();
        }

        /// <summary> 
        /// Gets a single DovizPerson from the database without its Doviz data.
        /// </summary>
        /// <param name="id">The ID of the Doviz person in the database.</param> 
        /// <returns>A DovizPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Doviz GetItem(Int32 pi_doviz_id)
        {
            //şimdilik herkes seçebilir
            Doviz myDoviz = DovizDB.GetItem(pi_doviz_id);
            return myDoviz;
        }
        /// <summary> 
        /// Gets a single DovizPerson from the database without its Doviz data.
        /// </summary>
        /// <param name="id">The ID of the Doviz person in the database.</param> 
        /// <returns>A DovizPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>

        #endregion
    }
}