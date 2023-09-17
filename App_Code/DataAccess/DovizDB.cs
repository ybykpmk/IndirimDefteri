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
    public class DovizDB
    {
        public DovizDB()
        {
            //
            // TODO: Add constructor Dovizic here
            //
        }

         private static Doviz FillDataRecord(IDataRecord myDataRecord)
        {
            Doviz myDoviz = new Doviz();
            myDoviz.Doviz_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Doviz_id"));
             if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Doviz_adi")))
            {
                myDoviz.Doviz_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Doviz_adi"));
            }
 
            return myDoviz;
        }

         public static Doviz GetItem(Int32 pi_doviz_id)
         {
             Doviz myDoviz = null;

             using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
             {
                 MySqlCommand cmd = new MySqlCommand("select * from ty_doviz where doviz_id=@pi_doviz_id", conn);

                 cmd.CommandType = CommandType.Text;
                 cmd.Parameters.AddWithValue("pi_doviz_id", pi_doviz_id);

                 conn.Open();

                 using (MySqlDataReader myReader = cmd.ExecuteReader())
                 {
                     if (myReader.Read())
                     {
                         myDoviz = FillDataRecord(myReader);
                     }
                     myReader.Close();
                 }

                 conn.Close();
             }

             return myDoviz;
         }

        public static DovizList GetList()
        {
            DovizList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_doviz", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new DovizList();
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