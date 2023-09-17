using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Ybyk.Nurun.BO
{

    // Veri tabanındaki Ta_Urun tablosunun karşılığı
    public class Urun
    {
        #region Private Variables
        private Int32 urun_id = -1;
        private string urun_adi = String.Empty;
        private Int32 alt_kategori_id = -1;
        private string liste_fiyati = String.Empty;
        private Int32 liste_fiyati_doviz_id = -1;
        private string indirim_fiyati = String.Empty;
        private Int32 indirim_fiyati_doviz_id = -1;
        private DateTime indirim_baslangic_tarihi = DateTime.MinValue;
        private DateTime indirim_bitis_tarihi = DateTime.MinValue;
        private string urun_saticisi_adi = String.Empty;
        private Int32 urun_ozellik_id = -1;
        private string link = String.Empty;
        private string urun_not1 = String.Empty;
        private string urun_not2 = String.Empty;
        private string urun_not3 = String.Empty;
        private string urun_not4 = String.Empty;
        private string urun_not5 = String.Empty;
        private string urun_resim_adresi = String.Empty;
        private Int32 urun_onay = -1;
        private DateTime urun_kayit_tarihi = DateTime.MinValue;
        private Int32 kayit_yapan = -1;
        private Int32 kargo = -1;

        private string alt_kategori_adi = String.Empty;
        private string kategori_adi = String.Empty;
        private string urun_ozellik_adi = String.Empty;
        private string yon_kullanici_adi = String.Empty;

        #endregion
        #region Public Properties
        public Int32 Urun_id { get { return urun_id; } set { urun_id = value; } }
        public string Urun_adi { get { return urun_adi; } set { urun_adi = value; } }
        public Int32 Alt_kategori_id { get { return alt_kategori_id; } set { alt_kategori_id = value; } }
        public string Liste_fiyati { get { return liste_fiyati; } set { liste_fiyati = value; } }
        public Int32 Liste_fiyati_doviz_id { get { return liste_fiyati_doviz_id; } set { liste_fiyati_doviz_id = value; } }
        public string Indirim_fiyati { get { return indirim_fiyati; } set { indirim_fiyati = value; } }
        public Int32 Indirim_fiyati_doviz_id { get { return indirim_fiyati_doviz_id; } set { indirim_fiyati_doviz_id = value; } }
        public DateTime Indirim_baslangic_tarihi { get { return indirim_baslangic_tarihi; } set { indirim_baslangic_tarihi = value; } }
        public DateTime Indirim_bitis_tarihi { get { return indirim_bitis_tarihi; } set { indirim_bitis_tarihi = value; } }
        public string Urun_saticisi_adi { get { return urun_saticisi_adi; } set { urun_saticisi_adi = value; } }
        public Int32 Urun_ozellik_id { get { return urun_ozellik_id; } set { urun_ozellik_id = value; } }
        public string Link { get { return link; } set { link = value; } }
        public string Urun_not1 { get { return urun_not1; } set { urun_not1 = value; } }
        public string Urun_not2 { get { return urun_not2; } set { urun_not2 = value; } }
        public string Urun_not3 { get { return urun_not3; } set { urun_not3 = value; } }
        public string Urun_not4 { get { return urun_not4; } set { urun_not4 = value; } }
        public string Urun_not5 { get { return urun_not5; } set { urun_not5 = value; } }
        public string Urun_resim_adresi { get { return urun_resim_adresi; } set { urun_resim_adresi = value; } }
        public Int32 Urun_onay { get { return urun_onay; } set { urun_onay = value; } }
        public DateTime Urun_kayit_tarihi { get { return urun_kayit_tarihi; } set { urun_kayit_tarihi = value; } }
        public Int32 Kayit_yapan { get { return kayit_yapan; } set { kayit_yapan = value; } }
        public Int32 Kargo { get { return kargo; } set { kargo = value; } }

        public string Alt_kategori_adi { get { return alt_kategori_adi; } set { alt_kategori_adi = value; } }
        public string Kategori_adi { get { return kategori_adi; } set { kategori_adi = value; } }
        public string Urun_ozellik_adi { get { return urun_ozellik_adi; } set { urun_ozellik_adi = value; } }
        public string Yon_kullanici_adi { get { return yon_kullanici_adi; } set { yon_kullanici_adi = value; } }

        #endregion
    }
}
