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
    public class OzellikDB
    {
        public OzellikDB()
        {
            //
            // TODO: Add constructor Ozellikic here
            //
        }

        public static Ozellik GetItem(Int32 pi_ozellik_id)
        {
            Ozellik myOzellik = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_urun_ozellik where ozellik_id=@pi_ozellik_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_ozellik_id", pi_ozellik_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myOzellik = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myOzellik;
        }

         private static Ozellik FillDataRecord(IDataRecord myDataRecord)
        {
            Ozellik myOzellik = new Ozellik();
            myOzellik.Ozellik_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Ozellik_id"));
             if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ozellik_adi")))
            {
                myOzellik.Ozellik_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Ozellik_adi"));
            }
 
            return myOzellik;
        }

        public static OzellikList GetList()
        {
            OzellikList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_urun_ozellik", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new OzellikList();
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

    }
}