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
    public class AylarDB
    {
        public AylarDB()
        {
            //
            // TODO: Add constructor Aylaric here
            //
        }

         private static Aylar FillDataRecord(IDataRecord myDataRecord)
        {
            Aylar myAylar = new Aylar();
            myAylar.Ay_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Ay_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ay_bilgisi")))
            {
                myAylar.Ay_bilgisi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Ay_bilgisi"));
            }
 
            return myAylar;
        }

        public static AylarList GetList()
        {
            AylarList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_aylar", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new AylarList();
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