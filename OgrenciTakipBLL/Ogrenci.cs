using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;
using System.IO;
using System.Data;

namespace OgrenciTakipBLL
{
    public class Ogrenci : BLL
    {
        private string _annead;
        public string annead
        {
            get { return _annead; }
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
                    _annead = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException(" Ad-Soyad içerisinde yalnızca harf olmalıdır!");
                }
            }
        }

        private string _babaad;
        public string babaad
        {
            get { return _babaad; }
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
                    _babaad = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException(" Ad-Soyad içerisinde yalnızca harf olmalıdır!");
                }
            }
        }

        private string _velitel;
        public string velitel
        {
            get { return _velitel; }
            set
            {
                byte digit = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        digit++;
                    }
                }
                if (digit == 10)
                {
                    _velitel = value;
                }
                else
                {
                    throw new ArgumentException("lütfen telefon alanını istenilen şekilde doldurunuz.");
                }
            }
        }
        public List<string> Giris(string tc, string dogumtarihi)
        {
            try
            {
                TCNo = tc;
                DogumTarihi = dogumtarihi;

                string sorgu = "SELECT * FROM Ogrenciler o inner join Siniflar s on s.Id = o.SinifId Where TC = @p1";
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
        public string FotoGuncelle(string no, byte[] resim)
        {
            try
            {
                string sorgu = "Update Ogrenciler set Fotograf = @p1 where OgrenciNo = " + no;

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
        public DataTable Listeleme(string action)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.ListelemeDB(action, "OgrenciNotlar");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListelemeYon()
        {
            try
            {
                string sorgu = "Select o.*,Sinif + '/' + Sube as 'Sınıf' from Ogrenciler o " +
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
        public DataTable Listeleme1(string no)
        {
            try
            {
                string sorgu = "Select o.OgrenciNo as 'Öğrenci No', o.AdSoyad as 'Ad Soyad',d.DersAdi as 'Ders Adı'," +
                               "n.Sinav1 as '1. Sınav',n.Sinav2 as '2. Sınav',n.KanaatNot as 'Kanaat Notu'," +
                               "n.Ortalama as 'Ortalama',n.Durum as 'Durumu'from Ogrenciler o inner join Notlar n" +
                               " on n.OgrenciId = o.Id inner join Dersler d on d.Id = n.DersId Where o.Id = " + no;
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
                string sorgu = "SELECT Fotograf FROM Ogrenciler WHERE OgrenciNo = @No";

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
        public string Guncelle(string ogrencino, string TC, string dogumyeri, string dogumtarihi,
        string anneadi, string babaadi, string velitel, string adres)
        {
            try
            {
                this.TCNo = TC;
                this.DogumYeri = dogumyeri;
                this.DogumTarihi = dogumtarihi;
                this.annead = annead;
                this.velitel = babaad;
                this.Adres = adres;
                DateTime dt = Convert.ToDateTime(dogumtarihi);

                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB("OgrenciGuncelleme", ogrencino, TC, dogumyeri, dt, anneadi, babaadi, velitel, adres);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Guncelle2(string procedure, string ogrencino, string ad, string TC, string dogumyeri, DateTime dogumtarihi,
        string sinif, string sube, string anneadi, string babaadi, string velitel, string adres,string id)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB2(procedure, ogrencino, ad, TC, dogumyeri, dogumtarihi,
                        sinif, sube, anneadi, babaadi, velitel, adres,id);
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
                string sorgu = "Delete from Ogrenciler where TC = " + TCNo;
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
