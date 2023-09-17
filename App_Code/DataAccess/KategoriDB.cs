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
    public class KategoriDB
    {
        public KategoriDB()
        {
            //
            // TODO: Add constructor Kategoriic here
            //
        }

        public static Kategori GetItem(Int32 pi_kategori_id)
        {
            Kategori myKategori = null;
            
            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_kategori where kategori_id=@pi_kategori_id", conn);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_kategori_id", pi_kategori_id);

                conn.Open();
                
                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myKategori = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myKategori;
        }

        public static Int32 GetItem(string pi_kategori_adi)
        {
            Int32 kategorisonuc = -1;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_kategori where kategori_adi=@pi_kategori_adi", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_kategori_adi", pi_kategori_adi);

                conn.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                
                    if (myReader.Read())
                    {
                        kategorisonuc = 1;
                    }
                    myReader.Close();
                

                conn.Close();
            }

            return kategorisonuc;
        }

        private static Kategori FillDataRecord(IDataRecord myDataRecord)
        {
            Kategori myKategori = new Kategori();
            myKategori.Kategori_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kategori_id"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Kategori_adi")))
            {
                myKategori.Kategori_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Kategori_adi"));
            }
 
            return myKategori;
        }

        public static KategoriList GetList()
        {
            KategoriList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ty_kategori", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new KategoriList();
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

        public static Int32 Insert(Kategori myKategori)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ty_kategori", conn);  
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_kategori_adi", MySqlDbType.VarChar)).Value = myKategori.Kategori_adi;

                MySqlParameter myParameter = new MySqlParameter("po_kategori_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Kategori myKategori)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_ty_kategori", conn); 
                cmd.CommandType = CommandType.StoredProcedure;

                if (myKategori.Kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = myKategori.Kategori_id;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_kategori_adi", MySqlDbType.VarChar)).Value = myKategori.Kategori_adi;

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

        public static bool Delete(Int32 pi_kategori_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_ty_kategori", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("pi_kategori_id", MySqlDbType.Int32)).Value = pi_kategori_id;

                MySqlParameter myParameter = new MySqlParameter("po_rows", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                //pi_Kategori_id         t_Kategori.ID%TYPE,
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