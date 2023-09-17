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
    public class KartDB
    {
        public KartDB()
        {
            //
            // TODO: Add constructor Kartic here
            //
        }

         private static Kart FillDataRecord(IDataRecord myDataRecord)
        {
            Kart myKart = new Kart();
            myKart.Kart_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kart_id"));
             if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Kart_adi")))
            {
                myKart.Kart_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Kart_adi"));
            }
 
            return myKart;
        }

        public static KartList GetList()
        {
            KartList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_kart", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new KartList();
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