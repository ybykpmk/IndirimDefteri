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
    public class Alt_kategoriDB
    {
        public Alt_kategoriDB()
        {
            //
            // TODO: Add constructor Alt_kategoriic here
            //
        }

        public static Alt_kategori GetItem(Int32 pi_alt_kategori_id)
        {
            Alt_kategori myAlt_kategori = null;
            
            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_alt_kategori where alt_kategori_id=@pi_alt_kategori_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_alt_kategori_id", pi_alt_kategori_id);

                conn.Open();
                
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myAlt_kategori = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myAlt_kategori;
        }


        public static Int32 GetItem(string pi_alt_kategori_adi)
        {
            Int32 Alt_kategorisonuc = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_alt_kategori where alt_kategori_adi=@pi_alt_kategori_adi", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_alt_kategori_adi", pi_alt_kategori_adi);

                conn.Open();

                MySqlDataReader myReader = cmd.ExecuteReader();
                
                    if (myReader.Read())
                    {
                        Alt_kategorisonuc = 1;
                    }
                    myReader.Close();
                

                conn.Close();
            }

            return Alt_kategorisonuc;
        }

        private static Alt_kategori FillDataRecord(IDataRecord myDataRecord)
        {
            Alt_kategori myAlt_kategori = new Alt_kategori();
            myAlt_kategori.Alt_kategori_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Alt_kategori_id"));
            myAlt_kategori.Kategori_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kategori_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Alt_kategori_adi")))
            {
                myAlt_kategori.Alt_kategori_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Alt_kategori_adi"));
            }
 
            return myAlt_kategori;
        }

        public static Alt_kategoriList GetList()
        {
            Alt_kategoriList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_alt_kategori", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Alt_kategoriList();
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

        public static Alt_kategoriList GetList(Int32 pi_kategori_id)
        {
            Alt_kategoriList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_alt_kategori where kategori_id=@pi_kategori_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_kategori_id", pi_kategori_id);
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new Alt_kategoriList();
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

        public static Int32 Insert(Alt_kategori myAlt_kategori)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ty_alt_kategori", conn); 
                cmd.CommandType = CommandType.StoredProcedure;

                if (myAlt_kategori.Kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = myAlt_kategori.Kategori_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_adi", MySqlDbType.VarChar)).Value = myAlt_kategori.Alt_kategori_adi;

                MySqlParameter myParameter = new MySqlParameter("po_alt_kategori_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Alt_kategori myAlt_kategori)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_ty_alt_kategori", conn); 
                cmd.CommandType = CommandType.StoredProcedure;

                if (myAlt_kategori.Alt_kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = myAlt_kategori.Alt_kategori_id;
                }

                if (myAlt_kategori.Kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = myAlt_kategori.Kategori_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_adi", MySqlDbType.VarChar)).Value = myAlt_kategori.Alt_kategori_adi;

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

        public static bool Delete(Int32 pi_alt_kategori_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_ty_alt_kategori", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = pi_alt_kategori_id;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                //pi_Alt_kategori_id         t_Alt_kategori.ID%TYPE,
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