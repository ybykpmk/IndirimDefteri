using System;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.ComponentModel;
using Ybyk.Nurun.BO;

namespace Ybyk.Nurun.Dal
{
    [DataObjectAttribute()]
    public class LogDB
    {
        public LogDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static Log GetItem(Int32 pi_log_id)
        {
            Log myLog = null;
            
            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_log where log_id=@pi_log_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_log_id", pi_log_id);

                conn.Open();
                
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myLog = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myLog;
        }

        private static Log FillDataRecord(IDataRecord myDataRecord)
        {
            Log myLog = new Log();
            myLog.Log_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Log_id"));
            myLog.Kullanici_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kullanici_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem")))
            {
                myLog.Islem =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Islem"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem_host_ip")))
            {
                myLog.Islem_host_ip
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Islem_host_ip"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem_tarihi")))
            {
                myLog.Islem_tarihi=
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Islem_tarihi"));
            }

            return myLog;
        }

        public static LogList GetList()
        {
            LogList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select
ta_log.log_id,
ta_log.kullanici_id,
ta_log.islem,
ta_log.islem_host_ip,
ta_log.islem_tarihi,
ta_yonetici.yon_kullanici_adi
 from ta_log,ta_yonetici
where ta_log.kullanici_id=ta_yonetici.yonetici_id", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LogList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_forGetlist(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        private static Log FillDataRecord_forGetlist(IDataRecord myDataRecord)
        {
            Log myLog = new Log();
            myLog.Log_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Log_id"));
            myLog.Kullanici_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kullanici_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem")))
            {
                myLog.Islem =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Islem"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem_host_ip")))
            {
                myLog.Islem_host_ip
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Islem_host_ip"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yon_kullanici_adi")))
            {
                myLog.Yon_kullanici_adi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Yon_kullanici_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Islem_tarihi")))
            {
                myLog.Islem_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Islem_tarihi"));
            }

            return myLog;
        }

        public static LogList GetList(string pi_bastar,string pi_bittar)
        {
            LogList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
ta_log.log_id,
ta_log.kullanici_id,
ta_log.islem,
ta_log.islem_host_ip,
ta_log.islem_tarihi,
ta_yonetici.yon_kullanici_adi
 from ta_log,ta_yonetici
where ta_log.kullanici_id=ta_yonetici.yonetici_id
and DATEDIFF(ta_log.islem_tarihi,@pi_bastar)>=0 and DATEDIFF(@pi_bittar,ta_log.islem_tarihi)>=0", conn);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_bastar", pi_bastar);
                cmd.Parameters.AddWithValue("pi_bittar", pi_bittar);
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new LogList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_forGetlist(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static Int32 Insert(Log myLog)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ta_log", conn);  
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_islem", MySqlDbType.VarChar)).Value = myLog.Islem;
                cmd.Parameters.Add(new MySqlParameter("pi_islem_host_ip", MySqlDbType.VarChar)).Value = myLog.Islem_host_ip;
                cmd.Parameters.Add(new MySqlParameter("pi_islem_tarihi", MySqlDbType.DateTime)).Value = myLog.Islem_tarihi;

                if (myLog.Kullanici_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kullanici_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kullanici_id", MySqlDbType.Int32)).Value = myLog.Kullanici_id;
                }

                MySqlParameter myParameter = new MySqlParameter("po_log_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }
         
    }
}