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
    /// The UrunPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class UrunManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Urun person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DateTime GetilkKayitTarihi()
        {
            //şimdilik herkes seçebilir
            return UrunDB.GetilkKayitTarihi();
        }
        
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UrunList GetList()
        {
            //şimdilik herkes seçebilir
            return UrunDB.GetList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UrunList GetList_ForSite()
        {
            //şimdilik herkes seçebilir
            return UrunDB.GetList_ForSite();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UrunList GetList_ForSite(Int32 pi_kategori_id, string pi_urun_adi)
        {
            //şimdilik herkes seçebilir
            return UrunDB.GetList_ForSite(pi_kategori_id, pi_urun_adi);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UrunList GetList(string pi_bastar, string pi_bittar, string pi_siralama, string pi_orderby)
        {
            //şimdilik herkes seçebilir
            return UrunDB.GetList(pi_bastar, pi_bittar, pi_siralama, pi_orderby);
        }
        /// <summary> 
        /// Gets a single UrunPerson from the database without its Urun data.
        /// </summary>
        /// <param name="id">The ID of the Urun person in the database.</param> 
        /// <returns>A UrunPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single UrunPerson from the database without its Urun data.
        /// </summary>
        /// <param name="id">The ID of the Urun person in the database.</param> 
        /// <returns>A UrunPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Urun GetItem(Int32 pi_urun_id)
        {
            //şimdilik herkes seçebilir
            Urun myUrun = UrunDB.GetItem(pi_urun_id);
            return myUrun;
        }

        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myUrunPerson">The UrunPerson instance to save.</param> 
        /// <returns>The new ID if the UrunPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Urun myUrun)
        {
            Int32 rows = UrunDB.Insert(myUrun);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myUrunPerson">The UrunPerson instance to save.</param> 
        /// <returns>The new ID if the UrunPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(Urun myUrun)
        {
            Int32 rows = UrunDB.Update(myUrun);

            return rows;
        }

        /// <summary>
        /// Deletes a Urun person from the database. 
        /// </summary> 
        /// <param name="myUrunPerson">The UrunPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Urun myUrun)
        {
            return UrunDB.Delete(myUrun.Urun_id);
        }

        //delete öğrenci given id
        public static bool Delete(Int32 pi_urun_id)
        {
            return UrunDB.Delete(pi_urun_id);
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetKategoriCount(Int32 pi_kategori_id)
        {
            //şimdilik herkes seçebilir
            Int32 count = UrunDB.GetKategoriCount(pi_kategori_id);
            return count;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Int32 GetAltKategoriCount(Int32 pi_altkategori_id)
        {
            //şimdilik herkes seçebilir
            Int32 count = UrunDB.GetAltKategoriCount(pi_altkategori_id);
            return count;
        }
        #endregion
    }
}