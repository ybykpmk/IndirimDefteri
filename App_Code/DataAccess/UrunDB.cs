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
    public class UrunDB
    {
        public UrunDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DateTime GetilkKayitTarihi()
        {
            DateTime ilkayittarihi = Convert.ToDateTime("01.01.1901");

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select min(ta_urun.urun_kayit_tarihi) as urun_kayit_tarihi from ta_urun", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        ilkayittarihi = myReader.GetDateTime(myReader.GetOrdinal("urun_kayit_tarihi"));
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return ilkayittarihi;
        }

        public static Urun GetItem(Int32 pi_urun_id)
        {
            Urun myUrun = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select * from ta_urun where urun_id=@pi_urun_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_urun_id", pi_urun_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        myUrun = FillDataRecord(myReader);
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return myUrun;
        }

        private static Urun FillDataRecord(IDataRecord myDataRecord)
        {
            Urun myUrun = new Urun();
            myUrun.Urun_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_id"));
            myUrun.Alt_kategori_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Alt_kategori_id"));
            myUrun.Liste_fiyati_doviz_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Liste_fiyati_doviz_id"));
            myUrun.Indirim_fiyati_doviz_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Indirim_fiyati_doviz_id"));
            myUrun.Urun_onay = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_onay"));
            myUrun.Urun_ozellik_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_ozellik_id"));
            myUrun.Kargo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kargo"));
            myUrun.Kayit_yapan = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kayit_yapan"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_fiyati")))
            {
                myUrun.Indirim_fiyati =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Indirim_fiyati"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Liste_fiyati")))
            {
                myUrun.Liste_fiyati =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Liste_fiyati"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_saticisi_adi")))
            {
                myUrun.Urun_saticisi_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_saticisi_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Link")))
            {
                myUrun.Link =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Link"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_adi")))
            {
                myUrun.Urun_adi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not1")))
            {
                myUrun.Urun_not1
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not1"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not2")))
            {
                myUrun.Urun_not2
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not2"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not3")))
            {
                myUrun.Urun_not3
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not3"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not4")))
            {
                myUrun.Urun_not4
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not4"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not5")))
            {
                myUrun.Urun_not5
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not5"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_resim_adresi")))
            {
                myUrun.Urun_resim_adresi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_resim_adresi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_baslangic_tarihi")))
            {
                myUrun.Indirim_baslangic_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Indirim_baslangic_tarihi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_bitis_tarihi")))
            {
                myUrun.Indirim_bitis_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Indirim_bitis_tarihi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_kayit_tarihi")))
            {
                myUrun.Urun_kayit_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Urun_kayit_tarihi"));
            }

            return myUrun;
        }

        public static UrunList GetList()
        {
            UrunList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select ta_urun.alt_kategori_id,
ta_urun.indirim_baslangic_tarihi,
ta_urun.indirim_bitis_tarihi,
concat(ta_urun.indirim_fiyati,concat(' ', (select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.indirim_fiyati_doviz_id ))) indirim_fiyati,
ta_urun.indirim_fiyati_doviz_id,
ta_urun.kayit_yapan,
ta_urun.link,
concat(ta_urun.liste_fiyati,concat(' ',(select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.liste_fiyati_doviz_id) )) liste_fiyati,
ta_urun.liste_fiyati_doviz_id,
ta_urun.urun_adi,
ta_urun.urun_id,
ta_urun.urun_kayit_tarihi,
ta_urun.urun_not1,
ta_urun.urun_not2,
ta_urun.urun_not3,
ta_urun.urun_not4,
ta_urun.urun_not5,
ta_urun.urun_onay,
ta_urun.urun_ozellik_id,
ta_urun.urun_resim_adresi,
ta_urun.urun_saticisi_adi,
ta_urun.kargo,
ty_alt_kategori.alt_kategori_adi,
ty_kategori.kategori_adi,
ty_urun_ozellik.ozellik_adi,
ta_yonetici.yon_kullanici_adi
 from ta_urun,ty_alt_kategori,ty_urun_ozellik,ty_kategori,ta_yonetici
where ta_urun.alt_kategori_id=ty_alt_kategori.alt_kategori_id
and ta_urun.urun_ozellik_id=ty_urun_ozellik.ozellik_id
and ty_kategori.kategori_id=ty_alt_kategori.kategori_id
and ta_yonetici.yonetici_id=ta_urun.kayit_yapan
order by ta_urun.urun_kayit_tarihi desc", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UrunList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_GetList(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static UrunList GetList_ForSite()
        {
            UrunList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select ta_urun.alt_kategori_id,
ta_urun.indirim_baslangic_tarihi,
ta_urun.indirim_bitis_tarihi,
concat(ta_urun.indirim_fiyati,concat(' ', (select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.indirim_fiyati_doviz_id ))) indirim_fiyati,
ta_urun.indirim_fiyati_doviz_id,
ta_urun.kayit_yapan,
ta_urun.link,
concat(ta_urun.liste_fiyati,concat(' ',(select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.liste_fiyati_doviz_id) )) liste_fiyati,
ta_urun.liste_fiyati_doviz_id,
ta_urun.urun_adi,
ta_urun.urun_id,
ta_urun.urun_kayit_tarihi,
ta_urun.urun_not1,
ta_urun.urun_not2,
ta_urun.urun_not3,
ta_urun.urun_not4,
ta_urun.urun_not5,
ta_urun.urun_onay,
ta_urun.urun_ozellik_id,
ta_urun.urun_resim_adresi,
ta_urun.urun_saticisi_adi,
ta_urun.kargo,
ty_alt_kategori.alt_kategori_adi,
ty_kategori.kategori_adi,
ty_urun_ozellik.ozellik_adi,
ta_yonetici.yon_kullanici_adi
 from ta_urun,ty_alt_kategori,ty_urun_ozellik,ty_kategori,ta_yonetici
where ta_urun.alt_kategori_id=ty_alt_kategori.alt_kategori_id
and ta_urun.urun_ozellik_id=ty_urun_ozellik.ozellik_id
and ty_kategori.kategori_id=ty_alt_kategori.kategori_id
and ta_yonetici.yonetici_id=ta_urun.kayit_yapan
and DATEDIFF(ta_urun.indirim_bitis_tarihi,sysdate())>=0
and urun_onay=1
order by ta_urun.urun_kayit_tarihi desc", conn);

                cmd.CommandType = CommandType.Text;

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UrunList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_GetList(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static UrunList GetList_ForSite(Int32 pi_kategori_id, string pi_urun_adi)
        {
            UrunList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select ta_urun.alt_kategori_id,
ta_urun.indirim_baslangic_tarihi,
ta_urun.indirim_bitis_tarihi,
concat(ta_urun.indirim_fiyati,concat(' ', (select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.indirim_fiyati_doviz_id ))) indirim_fiyati,
ta_urun.indirim_fiyati_doviz_id,
ta_urun.kayit_yapan,
ta_urun.link,
concat(ta_urun.liste_fiyati,concat(' ',(select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.liste_fiyati_doviz_id) )) liste_fiyati,
ta_urun.liste_fiyati_doviz_id,
ta_urun.urun_adi,
ta_urun.urun_id,
ta_urun.urun_kayit_tarihi,
ta_urun.urun_not1,
ta_urun.urun_not2,
ta_urun.urun_not3,
ta_urun.urun_not4,
ta_urun.urun_not5,
ta_urun.urun_onay,
ta_urun.urun_ozellik_id,
ta_urun.urun_resim_adresi,
ta_urun.urun_saticisi_adi,
ta_urun.kargo,
ty_alt_kategori.alt_kategori_adi,
ty_kategori.kategori_adi,
ty_urun_ozellik.ozellik_adi,
ta_yonetici.yon_kullanici_adi
 from ta_urun,ty_alt_kategori,ty_urun_ozellik,ty_kategori,ta_yonetici
where ta_urun.alt_kategori_id=ty_alt_kategori.alt_kategori_id
and ta_urun.urun_ozellik_id=ty_urun_ozellik.ozellik_id
and ty_kategori.kategori_id=ty_alt_kategori.kategori_id
and ta_yonetici.yonetici_id=ta_urun.kayit_yapan
and DATEDIFF(ta_urun.indirim_bitis_tarihi,sysdate())>=0
and urun_onay=1", conn);

                cmd.CommandType = CommandType.Text;
                if (pi_kategori_id != 0)
                {
                    cmd.CommandText = cmd.CommandText + " and ty_kategori.kategori_id="+ pi_kategori_id;
                }
                if (pi_urun_adi != "")
                {
                    cmd.CommandText = cmd.CommandText + " and ta_urun.urun_adi like '%" + pi_urun_adi + "%'";
                }
                cmd.CommandText = cmd.CommandText + " order by ta_urun.urun_kayit_tarihi desc";
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UrunList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_GetList(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        public static UrunList GetList(string pi_bastar, string pi_bittar, string pi_siralama, string pi_orderby)
        {
            UrunList myList = null;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(@"select ta_urun.alt_kategori_id,
ta_urun.indirim_baslangic_tarihi,
ta_urun.indirim_bitis_tarihi,
concat(ta_urun.indirim_fiyati,concat(' ', (select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.indirim_fiyati_doviz_id ))) indirim_fiyati,
ta_urun.indirim_fiyati_doviz_id,
ta_urun.kayit_yapan,
ta_urun.link,
concat(ta_urun.liste_fiyati,concat(' ',(select ty_doviz.doviz_adi from ty_doviz where ty_doviz.doviz_id=ta_urun.liste_fiyati_doviz_id) )) liste_fiyati,
ta_urun.liste_fiyati_doviz_id,
ta_urun.urun_adi,
ta_urun.urun_id,
ta_urun.urun_kayit_tarihi,
ta_urun.urun_not1,
ta_urun.urun_not2,
ta_urun.urun_not3,
ta_urun.urun_not4,
ta_urun.urun_not5,
ta_urun.urun_onay,
ta_urun.urun_ozellik_id,
ta_urun.urun_resim_adresi,
ta_urun.urun_saticisi_adi,
ta_urun.kargo,
ty_alt_kategori.alt_kategori_adi,
ty_kategori.kategori_adi,
ty_urun_ozellik.ozellik_adi,
ta_yonetici.yon_kullanici_adi
 from ta_urun,ty_alt_kategori,ty_urun_ozellik,ty_kategori,ta_yonetici
where ta_urun.alt_kategori_id=ty_alt_kategori.alt_kategori_id
and ta_urun.urun_ozellik_id=ty_urun_ozellik.ozellik_id
and ty_kategori.kategori_id=ty_alt_kategori.kategori_id
and ta_yonetici.yonetici_id=ta_urun.kayit_yapan
and DATEDIFF(ta_urun.urun_kayit_tarihi,@pi_bastar)>=0 and DATEDIFF(@pi_bittar,ta_urun.urun_kayit_tarihi)>=0 order by", conn);

                cmd.CommandType = CommandType.Text;
                if (pi_orderby == "Urun_adi")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Urun_adi";
                }
                if (pi_orderby == "Kategori_adi")
                {
                    cmd.CommandText = cmd.CommandText + " ty_kategori.Kategori_adi";
                }
                if (pi_orderby == "Alt_kategori_adi")
                {
                    cmd.CommandText = cmd.CommandText + " ty_alt_kategori.Alt_kategori_adi";
                }
                if (pi_orderby == "Liste_fiyati")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Liste_fiyati";
                }
                if (pi_orderby == "Indirim_fiyati")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Indirim_fiyati";
                }
                if (pi_orderby == "Indirim_bitis_tarihi")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Indirim_bitis_tarihi";
                }
                if (pi_orderby == "Urun_onay")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Urun_onay";
                }
                if (pi_orderby == "Urun_kayit_tarihi")
                {
                    cmd.CommandText = cmd.CommandText + " ta_urun.Urun_kayit_tarihi";
                }
                if (pi_orderby == "Yon_kullanici_adi")
                {
                    cmd.CommandText = cmd.CommandText + " ta_yonetici.Yon_kullanici_adi";
                }
                cmd.CommandText = cmd.CommandText + " " + pi_siralama;
                cmd.Parameters.AddWithValue("pi_bastar", pi_bastar);
                cmd.Parameters.AddWithValue("pi_bittar", pi_bittar);
                //cmd.Parameters.AddWithValue("pi_orderby", pi_orderby);
                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.HasRows)
                    {
                        myList = new UrunList();
                        while (myReader.Read())
                        {
                            myList.Add(FillDataRecord_GetList(myReader));
                        }
                    }
                    myReader.Close();
                }
            }

            return myList;
        }

        private static Urun FillDataRecord_GetList(IDataRecord myDataRecord)
        {
            Urun myUrun = new Urun();
            myUrun.Urun_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_id"));
            myUrun.Alt_kategori_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Alt_kategori_id"));
            myUrun.Liste_fiyati_doviz_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Liste_fiyati_doviz_id"));
            myUrun.Indirim_fiyati_doviz_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Indirim_fiyati_doviz_id"));
            myUrun.Urun_onay = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_onay"));
            myUrun.Urun_ozellik_id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Urun_ozellik_id"));
            myUrun.Kargo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kargo"));
            myUrun.Kayit_yapan = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Kayit_yapan"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Yon_kullanici_adi")))
            {
                myUrun.Yon_kullanici_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Yon_kullanici_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Kategori_adi")))
            {
                myUrun.Kategori_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Kategori_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Alt_kategori_adi")))
            {
                myUrun.Alt_kategori_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Alt_kategori_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ozellik_adi")))
            {
                myUrun.Urun_ozellik_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Ozellik_adi"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_fiyati")))
            {
                myUrun.Indirim_fiyati =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Indirim_fiyati"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Liste_fiyati")))
            {
                myUrun.Liste_fiyati =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Liste_fiyati"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_saticisi_adi")))
            {
                myUrun.Urun_saticisi_adi =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_saticisi_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Link")))
            {
                myUrun.Link =
                    myDataRecord.GetString(myDataRecord.GetOrdinal("Link"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_adi")))
            {
                myUrun.Urun_adi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_adi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not1")))
            {
                myUrun.Urun_not1
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not1"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not2")))
            {
                myUrun.Urun_not2
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not2"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not3")))
            {
                myUrun.Urun_not3
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not3"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not4")))
            {
                myUrun.Urun_not4
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not4"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_not5")))
            {
                myUrun.Urun_not5
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_not5"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_resim_adresi")))
            {
                myUrun.Urun_resim_adresi
                    = myDataRecord.GetString(myDataRecord.GetOrdinal("Urun_resim_adresi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_baslangic_tarihi")))
            {
                myUrun.Indirim_baslangic_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Indirim_baslangic_tarihi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Indirim_bitis_tarihi")))
            {
                myUrun.Indirim_bitis_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Indirim_bitis_tarihi"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Urun_kayit_tarihi")))
            {
                myUrun.Urun_kayit_tarihi =
                myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Urun_kayit_tarihi"));
            }

            return myUrun;
        }

        public static Int32 Insert(Urun myUrun)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_ins_ta_urun", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (myUrun.Alt_kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = myUrun.Alt_kategori_id;
                }

                if (myUrun.Liste_fiyati_doviz_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati_doviz_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati_doviz_id", MySqlDbType.Int32)).Value = myUrun.Liste_fiyati_doviz_id;
                }

                if (myUrun.Indirim_fiyati_doviz_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati_doviz_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati_doviz_id", MySqlDbType.Int32)).Value = myUrun.Indirim_fiyati_doviz_id;
                }

                if (myUrun.Urun_ozellik_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_ozellik_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_ozellik_id", MySqlDbType.Int32)).Value = myUrun.Urun_ozellik_id;
                }

                if (myUrun.Urun_onay == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_onay", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_onay", MySqlDbType.Int32)).Value = myUrun.Urun_onay;
                }

                if (myUrun.Kargo== -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kargo", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kargo", MySqlDbType.Int32)).Value = myUrun.Kargo;
                }

                if (myUrun.Kayit_yapan == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kayit_yapan", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kayit_yapan", MySqlDbType.Int32)).Value = myUrun.Kayit_yapan;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_urun_adi", MySqlDbType.VarChar)).Value = myUrun.Urun_adi;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_saticisi_adi", MySqlDbType.VarChar)).Value = myUrun.Urun_saticisi_adi;
                cmd.Parameters.Add(new MySqlParameter("pi_link", MySqlDbType.VarChar)).Value = myUrun.Link;
                cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati", MySqlDbType.VarChar)).Value = myUrun.Liste_fiyati;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati", MySqlDbType.VarChar)).Value = myUrun.Indirim_fiyati;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not1", MySqlDbType.VarChar)).Value = myUrun.Urun_not1;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not2", MySqlDbType.VarChar)).Value = myUrun.Urun_not2;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not3", MySqlDbType.VarChar)).Value = myUrun.Urun_not3;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not4", MySqlDbType.VarChar)).Value = myUrun.Urun_not4;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not5", MySqlDbType.VarChar)).Value = myUrun.Urun_not5;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_resim_adresi", MySqlDbType.VarChar)).Value = myUrun.Urun_resim_adresi;

                cmd.Parameters.Add(new MySqlParameter("pi_urun_kayit_tarihi", MySqlDbType.DateTime)).Value = myUrun.Urun_kayit_tarihi;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_baslangic_tarihi", MySqlDbType.DateTime)).Value = myUrun.Indirim_baslangic_tarihi;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_bitis_tarihi", MySqlDbType.DateTime)).Value = myUrun.Indirim_bitis_tarihi;

                MySqlParameter myParameter = new MySqlParameter("po_urun_id", MySqlDbType.Int32);
                myParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(myParameter);

                conn.Open();
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(myParameter.Value);
                conn.Close();
            }

            return result;
        }

        public static Int32 Update(Urun myUrun)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_upd_ta_urun", conn);  //upd_t_Urun
                cmd.CommandType = CommandType.StoredProcedure;

                if (myUrun.Urun_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_id", MySqlDbType.Int32)).Value = myUrun.Urun_id;
                }

                if (myUrun.Alt_kategori_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_alt_kategori_id", MySqlDbType.Int32)).Value = myUrun.Alt_kategori_id;
                }


                if (myUrun.Liste_fiyati_doviz_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati_doviz_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati_doviz_id", MySqlDbType.Int32)).Value = myUrun.Liste_fiyati_doviz_id;
                }

                if (myUrun.Indirim_fiyati_doviz_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati_doviz_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati_doviz_id", MySqlDbType.Int32)).Value = myUrun.Indirim_fiyati_doviz_id;
                }

                if (myUrun.Urun_ozellik_id == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_ozellik_id", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_ozellik_id", MySqlDbType.Int32)).Value = myUrun.Urun_ozellik_id;
                }

                if (myUrun.Urun_onay == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_onay", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_urun_onay", MySqlDbType.Int32)).Value = myUrun.Urun_onay;
                }

                if (myUrun.Kargo == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kargo", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kargo", MySqlDbType.Int32)).Value = myUrun.Kargo;
                }

                if (myUrun.Kayit_yapan == -1)
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kayit_yapan", MySqlDbType.Int32)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("pi_kayit_yapan", MySqlDbType.Int32)).Value = myUrun.Kayit_yapan;
                }

                cmd.Parameters.Add(new MySqlParameter("pi_urun_adi", MySqlDbType.VarChar)).Value = myUrun.Urun_adi;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_saticisi_adi", MySqlDbType.VarChar)).Value = myUrun.Urun_saticisi_adi;
                cmd.Parameters.Add(new MySqlParameter("pi_link", MySqlDbType.VarChar)).Value = myUrun.Link;
                cmd.Parameters.Add(new MySqlParameter("pi_liste_fiyati", MySqlDbType.VarChar)).Value = myUrun.Liste_fiyati;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_fiyati", MySqlDbType.VarChar)).Value = myUrun.Indirim_fiyati;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not1", MySqlDbType.VarChar)).Value = myUrun.Urun_not1;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not2", MySqlDbType.VarChar)).Value = myUrun.Urun_not2;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not3", MySqlDbType.VarChar)).Value = myUrun.Urun_not3;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not4", MySqlDbType.VarChar)).Value = myUrun.Urun_not4;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_not5", MySqlDbType.VarChar)).Value = myUrun.Urun_not5;
                cmd.Parameters.Add(new MySqlParameter("pi_urun_resim_adresi", MySqlDbType.VarChar)).Value = myUrun.Urun_resim_adresi;

                cmd.Parameters.Add(new MySqlParameter("pi_urun_kayit_tarihi", MySqlDbType.DateTime)).Value = myUrun.Urun_kayit_tarihi;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_baslangic_tarihi", MySqlDbType.DateTime)).Value = myUrun.Indirim_baslangic_tarihi;
                cmd.Parameters.Add(new MySqlParameter("pi_indirim_bitis_tarihi", MySqlDbType.DateTime)).Value = myUrun.Indirim_bitis_tarihi;


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

        public static bool Delete(Int32 pi_urun_id)
        {
            Int32 result = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("pro_del_ta_urun", conn); //del_t_Urun
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

        public static Int32 GetKategoriCount(Int32 pi_kategori_id)
        {
            Int32 count = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select count(ta_urun.alt_kategori_id) as kategori_count from ta_urun where ta_urun.alt_kategori_id in (select ty_alt_kategori.alt_kategori_id from ty_alt_kategori where ty_alt_kategori.kategori_id=@pi_kategori_id)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_kategori_id", pi_kategori_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        count = myReader.GetInt32(myReader.GetOrdinal("kategori_count"));
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return count;
        }

        public static Int32 GetAltKategoriCount(Int32 pi_altkategori_id)
        {
            Int32 count = 0;

            using (MySqlConnection conn = new MySqlConnection(AppConfiguration.ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand("select count(ta_urun.alt_kategori_id) as altkategori_count from ta_urun where ta_urun.alt_kategori_id=@pi_altkategori_id", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("pi_altkategori_id", pi_altkategori_id);

                conn.Open();

                using (MySqlDataReader myReader = cmd.ExecuteReader())
                {
                    if (myReader.Read())
                    {
                        count = myReader.GetInt32(myReader.GetOrdinal("altkategori_count"));
                    }
                    myReader.Close();
                }

                conn.Close();
            }

            return count;
        }
    }
}