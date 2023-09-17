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
    public class gunluk_erisimDB
    {
        public gunluk_erisimDB()
        {
            //
            // TODO: Add constructor gunluk_erisimic here
            //
        }

        public static gunluk_erisim GetItem(string pi_gunun_tarihi)
        {
            gunluk_erisim mygunluk_erisim = null;
            
            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_gunluk_erisim where gunun_tarihi=@pi_gunun_tarihi", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_gunun_tarihi", Convert.ToDateTime(pi_gunun_tarihi).ToString("yyyy-MM-dd"));

                conn.Open();
                
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        mygunluk_erisim = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return mygunluk_erisim;
        }

        public static gunluk_erisim GetToplam()
        {
            gunluk_erisim mygunluk_erisim = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select  SUM(ta_gunluk_erisim.erisim_sayisi) as erisim_sayisi,min(ta_gunluk_erisim.gunun_tarihi) as gunun_tarihi from ta_gunluk_erisim", conn);

                cmd.CommandType = CommandType.Text;                

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        mygunluk_erisim = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return mygunluk_erisim;
        }

        private static gunluk_erisim FillDataRecord(IDataRecord myDataRecord)
        {
            gunluk_erisim mygunluk_erisim = new gunluk_erisim();
            mygunluk_erisim.Erisim_sayisi = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Erisim_sayisi"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gunun_tarihi")))
            {
                mygunluk_erisim.Gunun_tarihi=
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Gunun_tarihi"));
            }

            return mygunluk_erisim;
        }

        public static gunluk_erisimList GetList(string pi_ilgili_ay)
        {
            gunluk_erisimList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select 
gunun_tarihi,
erisim_sayisi 
from ta_gunluk_erisim
where DATEDIFF(gunun_tarihi,@pi_ilgili_ay)>=0 and DATEDIFF(@pi_ilgili_ay,gunun_tarihi)>=0", conn);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_ilgili_ay", pi_ilgili_ay);
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new gunluk_erisimList();
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

        public static Int32 Insert(gunluk_erisim mygunluk_erisim)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ta_gunluk_erisim", conn);  
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("pi_gunun_tarihi", MySqlDbType.DateTime)).Value = mygunluk_erisim.Gunun_tarihi;

                if (mygunluk_erisim.Erisim_sayisi == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_erisim_sayisi", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_erisim_sayisi", MySqlDbType.Int32)).Value = mygunluk_erisim.Erisim_sayisi;
                }

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(gunluk_erisim mygunluk_erisim)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_ta_gunluk_erisim", conn);  //upd__ta_gunluk_erisim
                cmd.CommandType = CommandType.StoredProcedure;

                if (mygunluk_erisim.Erisim_sayisi == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_erisim_sayisi", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_erisim_sayisi", MySqlDbType.Int32)).Value = mygunluk_erisim.Erisim_sayisi;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_gunun_tarihi", MySqlDbType.DateTime)).Value = mygunluk_erisim.Gunun_tarihi;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);

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