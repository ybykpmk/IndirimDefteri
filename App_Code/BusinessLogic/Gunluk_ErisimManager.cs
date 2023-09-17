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
    /// The gunluk_erisimPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class gunluk_erisimManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any gunluk_erisim person, or null otherwise.</returns> 

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static gunluk_erisimList GetList(string pi_ilgili_ay)
        {
            //şimdilik herkes seçebilir
            return gunluk_erisimDB.GetList(pi_ilgili_ay);
        }
        /// <summary> 
        /// Gets a single gunluk_erisimPerson from the database without its gunluk_erisim data.
        /// </summary>
        /// <param name="id">The ID of the gunluk_erisim person in the database.</param> 
        /// <returns>A gunluk_erisimPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single gunluk_erisimPerson from the database without its gunluk_erisim data.
        /// </summary>
        /// <param name="id">The ID of the gunluk_erisim person in the database.</param> 
        /// <returns>A gunluk_erisimPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static gunluk_erisim GetItem(string pi_gunluk_tarihi)
        {
            //şimdilik herkes seçebilir
            gunluk_erisim mygunluk_erisim = gunluk_erisimDB.GetItem(pi_gunluk_tarihi);
            return mygunluk_erisim;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static gunluk_erisim GetToplam()
        {
            //şimdilik herkes seçebilir
            gunluk_erisim mygunluk_erisim = gunluk_erisimDB.GetToplam();
            return mygunluk_erisim;
        }
        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="mygunluk_erisimPerson">The gunluk_erisimPerson instance to save.</param> 
        /// <returns>The new ID if the gunluk_erisimPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(gunluk_erisim mygunluk_erisim)
        {
            Int32 rows = gunluk_erisimDB.Insert(mygunluk_erisim);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="mygunluk_erisimPerson">The gunluk_erisimPerson instance to save.</param> 
        /// <returns>The new ID if the gunluk_erisimPerson is new in the database or the existing ID when an item was updated.</returns>

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static Int32 Update(gunluk_erisim mygunluk_erisim)
        {
            Int32 rows = gunluk_erisimDB.Update(mygunluk_erisim);

            return rows;
        }

        /// <summary>
        /// Deletes a gunluk_erisim person from the database. 
        /// </summary> 
        /// <param name="mygunluk_erisimPerson">The gunluk_erisimPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
   
        //[DataObjectMethod(DataObjectMethodType.Delete, true)]
        //public static bool Delete(gunluk_erisim mygunluk_erisim)
        //{
        //    return gunluk_erisimDB.Delete(mygunluk_erisim.gunluk_erisim_id);
        //}

        ////delete öğrenci given id
        //public static bool Delete(Int32 pi_gunluk_erisim_id)
        //{
        //    return gunluk_erisimDB.Delete(pi_gunluk_erisim_id);
        //}

        #endregion
    }
}