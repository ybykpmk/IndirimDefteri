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
    public class yoneticiDB
    {
        public yoneticiDB()
        {
            //
            // TODO: Add constructor yoneticiic here
            //
        }

        public static yonetici GetItem(Int32 pi_yonetici_id)
        {
            yonetici myyonetici = null;
            
            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_yonetici where yonetici_id=@pi_yonetici_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_yonetici_id", pi_yonetici_id);

                conn.Open();
                
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myyonetici = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myyonetici;
        }

        public static yonetici GetItem(string pi_user_name, string pi_pass_word)
        {
            yonetici myyonetici = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_yonetici where yon_kullanici_adi=@pi_user_name and yon_kullanici_parola=@pi_pass_word", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_user_name", pi_user_name);
                cmd.Parameters.AddWithValue("pi_pass_word", pi_pass_word);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myyonetici = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myyonetici;
        }

        private static yonetici FillDataRecord(IDataRecord myDataRecord)
        {
            yonetici myyonetici = new yonetici();
            myyonetici.Yonetici_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Yonetici_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yonetici_adi")))
            {
                myyonetici.Yonetici_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Yonetici_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yonetici_soyadi")))
            {
                myyonetici.Yonetici_soyadi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Yonetici_soyadi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yon_kullanici_adi")))
            {
                myyonetici.Yon_kullanici_adi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Yon_kullanici_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yon_kullanici_parola")))
            {
                myyonetici.Yon_kullanici_parola
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Yon_kullanici_parola"));
            }

            return myyonetici;
        }

 


    }
}