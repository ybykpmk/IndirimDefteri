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
    /// The LogPersonManager class is responsible for managing BO.UrunPerson objects in the system. 
    /// </summary>
    [DataObjectAttribute()]
    public class LogManager
    {
        #region Public Methods

        /// <summary>
        /// Gets a list with all UrunPerson objects in the database. 
        /// </summary>
        /// <returns>A list with all ayrilan öğrenci from the database when the database contains any Log person, or null otherwise.</returns> 
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LogList GetList()
        {
            //şimdilik herkes seçebilir
            return LogDB.GetList();
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static LogList GetList(string pi_bastar, string pi_bittar)
        {
            //şimdilik herkes seçebilir
            return LogDB.GetList(pi_bastar,pi_bittar);
        }
        /// <summary> 
        /// Gets a single LogPerson from the database without its Log data.
        /// </summary>
        /// <param name="id">The ID of the Log person in the database.</param> 
        /// <returns>A LogPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>


        /// <summary> 
        /// Gets a single LogPerson from the database without its Log data.
        /// </summary>
        /// <param name="id">The ID of the Log person in the database.</param> 
        /// <returns>A LogPerson object when the ID exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Log GetItem(Int32 pi_log_id)
        {
            //şimdilik herkes seçebilir
            Log myLog = LogDB.GetItem(pi_log_id);
            return myLog;
        }

        /// <summary>
        /// inserts a öğrenci in the database.
        /// </summary>
        /// <param name="myLogPerson">The LogPerson instance to save.</param> 
        /// <returns>The new ID if the LogPerson is new in the database or the existing ID when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static Int32 Insert(Log myLog)
        {
            Int32 rows = LogDB.Insert(myLog);

            return rows;
        }

        /// <summary>
        /// updates öğrenci in the database.
        /// </summary>
        /// <param name="myLogPerson">The LogPerson instance to save.</param> 
        /// <returns>The new ID if the LogPerson is new in the database or the existing ID when an item was updated.</returns>
      
        //[DataObjectMethod(DataObjectMethodType.Update, true)]
        //public static Int32 Update(Log myLog)
        //{
        //    Int32 rows = LogDB.Update(myLog);

        //    return rows;
        //}

        /// <summary>
        /// Deletes a Log person from the database. 
        /// </summary> 
        /// <param name="myLogPerson">The LogPerson instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns> 
   
        //[DataObjectMethod(DataObjectMethodType.Delete, true)]
        //public static bool Delete(Log myLog)
        //{
        //    return LogDB.Delete(myLog.Log_id);
        //}

        ////delete öğrenci given id
        //public static bool Delete(Int32 pi_log_id)
        //{
        //    return LogDB.Delete(pi_log_id);
        //}

        #endregion
    }
}