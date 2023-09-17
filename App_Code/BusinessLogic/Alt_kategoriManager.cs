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
    /// The Alt_kategoriPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class Alt_kategoriManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Alt_kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Alt_kategoriList GetList()
        {
            //şimdilik herkes seçebilir
            return Alt_kategoriDB.GetList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Alt_kategoriList GetList(Int32 pi_kategori_id)
        {
            //şimdilik herkes seçebilir
            return Alt_kategoriDB.GetList(pi_kategori_id);
        }

        /// <summary> 
        /// Gets a single Alt_kategoriPerson from the database without its Alt_kategori data.
        /// </summary>
        /// <param name="id">The ID of the Alt_kategori person in the database.</param> 
        /// <returns>A Alt_kategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single Alt_kategoriPerson from the database without its Alt_kategori data.
        /// </summary>
        /// <param name="id">The ID of the Alt_kategori person in the database.</param> 
        /// <returns>A Alt_kategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Alt_kategori GetItem(Int32 pi_alt_kategori_id)
        {
            //şimdilik herkes seçebilir
            Alt_kategori myAlt_kategori = Alt_kategoriDB.GetItem(pi_alt_kategori_id);
            return myAlt_kategori;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetItem(string pi_alt_kategori_adi)
        {
            //şimdilik herkes seçebilir
            Int32 Alt_kategorisonuc = Alt_kategoriDB.GetItem(pi_alt_kategori_adi);
            return Alt_kategorisonuc;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Alt_kategori myAlt_kategori)
        {
            Int32 rows = Alt_kategoriDB.Insert(myAlt_kategori);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to save.</param> 
        /// <returns>The new ID if the Alt_kategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Alt_kategori myAlt_kategori)
        {
            Int32 rows = Alt_kategoriDB.Update(myAlt_kategori);

            return rows;
        }

        /// <summary>
        /// Deletes a Alt_kategori person from the database. 
        /// </summary> 
        /// <param name="myAlt_kategoriPerson">The Alt_kategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Alt_kategori myAlt_kategori)
        {
            return Alt_kategoriDB.Delete(myAlt_kategori.Alt_kategori_id);
        }

        //delete öğrenci given id
        public static bool Delete(Int32 pi_alt_kategori_id)
        {
            return Alt_kategoriDB.Delete(pi_alt_kategori_id);
        }

        #endregion
    }
}