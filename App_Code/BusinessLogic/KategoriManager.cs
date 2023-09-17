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
    /// The KategoriPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class KategoriManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Kategori person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static KategoriList GetList()
        {
            //şimdilik herkes seçebilir
            return KategoriDB.GetList();
        }

        /// <summary> 
        /// Gets a single KategoriPerson from the database without its Kategori data.
        /// </summary>
        /// <param name="id">The ID of the Kategori person in the database.</param> 
        /// <returns>A KategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single KategoriPerson from the database without its Kategori data.
        /// </summary>
        /// <param name="id">The ID of the Kategori person in the database.</param> 
        /// <returns>A KategoriPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Kategori GetItem(Int32 pi_kategori_id)
        {
            //şimdilik herkes seçebilir
            Kategori myKategori = KategoriDB.GetItem(pi_kategori_id);
            return myKategori;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetItem(string pi_kategori_adi)
        {
            //şimdilik herkes seçebilir
            Int32 kategorisonuc = KategoriDB.GetItem(pi_kategori_adi);
            return kategorisonuc;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myKategoriPerson">The KategoriPerson instance to save.</param> 
        /// <returns>The new ID if the KategoriPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Kategori myKategori)
        {
            Int32 rows = KategoriDB.Insert(myKategori);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myKategoriPerson">The KategoriPerson instance to save.</param> 
        /// <returns>The new ID if the KategoriPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Kategori myKategori)
        {
            Int32 rows = KategoriDB.Update(myKategori);

            return rows;
        }

        /// <summary>
        /// Deletes a Kategori person from the database. 
        /// </summary> 
        /// <param name="myKategoriPerson">The KategoriPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Kategori myKategori)
        {
            return KategoriDB.Delete(myKategori.Kategori_id);
        }

        //delete öğrenci given id
        public static bool Delete(Int32 pi_kategori_id)
        {
            return KategoriDB.Delete(pi_kategori_id);
        }

        #endregion
    }
}