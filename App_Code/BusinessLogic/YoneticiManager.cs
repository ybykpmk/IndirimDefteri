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
    /// The yoneticiPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class yoneticiManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any yonetici person, or null otherwise.</returns> 
        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static yoneticiList GetList()
        //{
        //    //şimdilik herkes seçebilir
        //    return yoneticiDB.GetList();
        //}

        /// <summary> 
        /// Gets a single yoneticiPerson from the database without its yonetici data.
        /// </summary>
        /// <param name="id">The ID of the yonetici person in the database.</param> 
        /// <returns>A yoneticiPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single yoneticiPerson from the database without its yonetici data.
        /// </summary>
        /// <param name="id">The ID of the yonetici person in the database.</param> 
        /// <returns>A yoneticiPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static yonetici GetItem(string pi_user_name, string pi_pass_word)
        {
            //şimdilik herkes seçebilir
            yonetici myyonetici = yoneticiDB.GetItem(pi_user_name, pi_pass_word);
            return myyonetici;
        }   

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static yonetici GetItem(Int32 pi_yonetici_id)
        {
            //şimdilik herkes seçebilir
            yonetici myyonetici = yoneticiDB.GetItem(pi_yonetici_id);
            return myyonetici;
        }

        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myyoneticiPerson">The yoneticiPerson instance to save.</param> 
        /// <returns>The new ID if the yoneticiPerson is new in the database or the existing ID when an item was updated.</returns>
        //[DataObjectMethod(DataObjectMethodType.Insert, true)]
        //public static Int32 Insert(yonetici myyonetici)
        //{
        //    Int32 rows = yoneticiDB.Insert(myyonetici);

        //    return rows;
        //}

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myyoneticiPerson">The yoneticiPerson instance to save.</param> 
        /// <returns>The new ID if the yoneticiPerson is new in the database or the existing ID when an item was updated.</returns>
      
        //[DataObjectMethod(DataObjectMethodType.Update, true)]
        //public static Int32 Update(yonetici myyonetici)
        //{
        //    Int32 rows = yoneticiDB.Update(myyonetici);

        //    return rows;
        //}

        /// <summary>
        /// Deletes a yonetici person from the database. 
        /// </summary> 
        /// <param name="myyoneticiPerson">The yoneticiPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
   
        //[DataObjectMethod(DataObjectMethodType.Delete, true)]
        //public static bool Delete(yonetici myyonetici)
        //{
        //    return yoneticiDB.Delete(myyonetici.yonetici_id);
        //}

        ////delete öğrenci given id
        //public static bool Delete(Int32 pi_yonetici_id)
        //{
        //    return yoneticiDB.Delete(pi_yonetici_id);
        //}

        #endregion
    }
}