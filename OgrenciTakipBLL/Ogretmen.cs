using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;
using System.Data;

namespace OgrenciTakipBLL
{
    public class Ogretmen : BLL
    {
        public List<string> Giris(string tc, string sifre)
        {
            try
            {
                TCNo = tc;
                Sifre = sifre;
                string sorgu = "SELECT * FROM Ogretmen Where TC = @p1";
                using (DAL objDal = new DAL())
                {
                    return objDal.GirisDB(sorgu, tc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Giris2(string tc, string ad, string dogumtarihi, string email, string tel)
        {
            try
            {
                TCNo = tc;
                AdSoyad = ad;
                DogumTarihi = dogumtarihi;
                this.email = email;
                this.tel = tel;
                string sorgu = "SELECT * FROM Ogretmen Where TC = @p1";
                using (DAL objDal = new DAL())
                {
                    List<string> OgretmenBilgileri = objDal.GirisDB(sorgu, tc);
                    if (OgretmenBilgileri.Count != 0)
                    {
                        if (OgretmenBilgileri[1] == AdSoyad &&
                            OgretmenBilgileri[2] == TCNo &&
                            OgretmenBilgileri[4] == DogumTarihi + " 00:00:00" &&
                            OgretmenBilgileri[8] == this.email &&
                            OgretmenBilgileri[9] == this.tel
                            )
                        {
                            return ("Şifreniz: " + OgretmenBilgileri[6]);
                        }
                        else
                        {
                            return("Bilgiler hatalıdır. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        return("öğretmen bulunamadı!" +
                        "\nLütfen TC Numaranızı ediniz.");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> Sinif(string tc)
        {
            try
            {
                TCNo = tc;
                string sorgu = "Select Sinif + '/' + Sube from Siniflar s inner join Ogretmen o " +
                               "on o.SinifId = s.Id where o.TC = @p1";
                using (DAL objDal = new DAL())
                {
                    return objDal.GirisDB(sorgu, tc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Listeleme(string no,string ad)
        {
            try
            {
                string sorgu = "";
                if (!string.IsNullOrEmpty(no))
                {
                    ogrencino = no;
                    sorgu = $"Select o.* from Ogrenciler o inner join Siniflar s on s.Id = o.SinifId " +
                        $"inner join Ogretmen og on og.SinifId = s.Id where o.OgrenciNo = '{no}'";
                }
                else if (!string.IsNullOrEmpty(ad))
                {
                    AdSoyad = ad;
                    sorgu = $"Select o.* from Ogrenciler o inner join Siniflar s on s.Id = o.SinifId " +
                        $"inner join Ogretmen og on og.SinifId = s.Id where o.AdSoyad = '{ad}'";
                }
                else
                    throw new Exception("Lütfen aranacak öğrenci bilgisini giriniz!");

                using (DAL objDal = new DAL())
                {
                    return objDal.ListelemeDB(sorgu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Listeleme(string tc)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.ListelemeDB(tc, "OgretmenDetay");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListelemeYon( )
        {
            try
            {
                string sorgu = "Select o.*,Sinif + '/' + Sube as 'Sınıf' from Ogretmen o " +
                               "inner join Siniflar s on s.Id = o.SinifId";
                using (DAL objDal = new DAL())
                {
                    return objDal.ListelemeDB(sorgu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string FotoGuncelle(string tc, byte[] resim)
        {
            try
            {
                string sorgu = "Update Ogretmen set Fotograf = @p1 where TC = " + tc;

                using (DAL objDal = new DAL())
                {
                    return objDal.FotoGuncelle(sorgu, resim);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public MemoryStream Fotograf(string no)
        {
            try
            {
                string sorgu = "SELECT Fotograf FROM Ogretmen WHERE TC = @No";
                using (DAL objDal = new DAL())
                {
                    return objDal.Fotograf(no, sorgu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Guncelle(string dogumyeri, string dogumtarihi, string sifre,
        string email, string tel, string adres, string tc)
        {
            try
            {
                DogumYeri = dogumyeri;
                DogumTarihi = dogumtarihi;
                DateTime dt = Convert.ToDateTime(dogumtarihi);
                Sifre = sifre;
                this.email = email;
                this.tel = tel;
                this.Adres = adres;
                this.TCNo = tc;

                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB("OgretmenGuncelleme", dogumyeri, dt, sifre, email, tel, adres, tc);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Guncelle(string procedure, string adsoyad, string Tc, string dogumyeri, DateTime dogumtarihi,
        DateTime isebaslama, string sifre, string sinif, string sube, string email, string tel, string adres, string id)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB2(procedure, adsoyad, Tc, dogumyeri, dogumtarihi, isebaslama, sifre,
                        sinif, sube, email, tel, adres, id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Sil(string tc)
        {
            try
            {
                TCNo = tc;
                string sorgu = "Delete from Ogretmen where TC = " + TCNo;
                using (DAL objDal = new DAL())
                {
                    return objDal.SilDB(sorgu);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
