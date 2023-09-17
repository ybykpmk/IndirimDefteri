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
    public class OdemeDB
    {
        public OdemeDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static Odeme GetItem(Int32 pi_odeme_id)
        {
            Odeme myOdeme = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_odeme where odeme_id=@pi_odeme_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_odeme_id", pi_odeme_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myOdeme = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myOdeme;
        }

        private static Odeme FillDataRecord(IDataRecord myDataRecord)
        {
            Odeme myOdeme = new Odeme();
            myOdeme.Odeme_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Odeme_id"));
            myOdeme.Urun_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_id"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Odeme_aciklamasi")))
            {
                myOdeme.Odeme_aciklamasi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Odeme_aciklamasi"));
            }

            return myOdeme;
        }

        public static OdemeList GetList(Int32 pi_urun_id)
        {
            OdemeList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select * from ta_odeme where urun_id=@pi_urun_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_urun_id", pi_urun_id);
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new OdemeList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static Int32 Insert(Odeme myOdeme)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ta_odeme", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myOdeme.Urun_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_id", MySqlDbType.Int32)).Value = myOdeme.Urun_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_odeme_aciklamasi", MySqlDbType.VarChar)).Value = myOdeme.Odeme_aciklamasi;

                MySqlParameter myParameter = new MySqlParameter("po_odeme_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static bool Delete(Int32 pi_urun_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_ta_odeme", conn); //del_t_Odeme
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_urun_id", MySqlDbType.Int32)).Value = pi_urun_id;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                //pi_Urun_id         t_Urun.ID%TYPE,
                //po_rows      OUT   PLS_INTEGER
                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }
            return result > 0;
        }
    }
}