using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OgrenciTakipDAL;
using System.Data;
using System.IO;

namespace OgrenciTakipBLL
{
    public class Yonetici : BLL
    {
        private string _gorev;

        public string gorev
        {
            get { return _gorev; }
            set
            {
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsLetter(value[i]) || value[i] == ' ')
                    {
                        oldumu = true;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }
                if (oldumu)
                {
                    _gorev = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("Görev Alanı Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Görev içerisinde yalnızca harf olmalıdır!");
                }
            }
        }
        public List<string> Giris(string tc, string sifre)
        {
            try
            {
                TCNo = tc;
                Sifre = sifre;
                string sorgu = "SELECT * FROM Yonetici Where TC = @p1";
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
        public DataTable Listeleme()
        {
            try
            {
                string sorgu = "Select * from Yonetici";
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
        public MemoryStream Fotograf(string no)
        {
            try
            {
                string sorgu = "SELECT Fotograf FROM Yonetici WHERE Id = @No";
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
        public string FotoGuncelle(string tc, byte[] resim)
        {
            try
            {
                string sorgu = "Update Yonetici set Fotograf = @p1 where TC = " + tc;

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
        public string Giris2(string tc, string ad, string dogumtarihi, string email, string tel)
        {
            try
            {
                TCNo = tc;
                AdSoyad = ad;
                DogumTarihi = dogumtarihi;
                this.email = email;
                this.tel = tel;
                string sorgu = "SELECT * FROM Yonetici Where TC = @p1";
                using (DAL objDal = new DAL())
                {
                    List<string> YoneticiBilgileri = Giris(sorgu, tc);

                    if (YoneticiBilgileri.Count != 0)
                    {
                        if (YoneticiBilgileri[1] == AdSoyad &&
                            YoneticiBilgileri[2] == TCNo &&
                            YoneticiBilgileri[4] == DogumTarihi + " 00:00:00" &&
                            YoneticiBilgileri[8] == this.email &&
                            YoneticiBilgileri[9] == this.tel
                            )
                        {
                            return ("Şifreniz: " + YoneticiBilgileri[6]);
                        }
                        else
                        {
                            return ("Bilgiler hatalıdır. Lütfen tekrar deneyiniz.");
                        }
                    }
                    else
                    {
                        return ("Yönetici bulunamadı!" +
                        "\nLütfen TC numaranızı kontrol ediniz.");
                    }
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Guncelle(string procedure, string adsoyad, string Tc, string dogumyeri, DateTime dogumtarihi,
        DateTime isebaslama, string sifre, string gorev, string email, string tel, string adres, string id)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB2(procedure, adsoyad, Tc, dogumyeri, dogumtarihi, isebaslama, sifre,
                        gorev, email, tel, adres, id);
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
                string sorgu = "Delete from Yonetici where TC = " + TCNo;
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
        public void YoneticiBilgiKontrol(string adsoyad, string tc, string dogumyeri, string dogumtarihi, string isebaslama,
            string sifre, string gorev, string email, string tel, string adres)
        {
            this.AdSoyad = adsoyad;
            this.TCNo = tc;
            this.DogumYeri = dogumyeri;
            this.DogumTarihi = dogumtarihi;
            this.isebaslama = isebaslama;
            this.Sifre = sifre;
            this.gorev = gorev;
            this.email = email;
            this.tel = tel;
            this.Adres = adres;
        }
    }
}
