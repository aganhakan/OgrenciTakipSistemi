using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using OgrenciTakipDAL;
using System.IO;

namespace OgrenciTakipBLL
{
    public abstract class BLL : IDisposable
    {
        #region Değişkenler

        private string _AdSoyad;
        public string AdSoyad
        {
            get { return _AdSoyad; }
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
                    _AdSoyad = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Ad-Soyad içerisinde yalnızca harf olmalıdır!");
                }
            }
        }

        private string _TCNo;
        public string TCNo
        {
            get { return _TCNo; }
            set
            {
                byte digit = 0;
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }
                if (oldumu && digit == 11)
                {
                    _TCNo = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (!oldumu)
                {
                    throw new ArgumentException("TC No içerisinde yalnızca sayı olmalıdır!");
                }
                else
                {
                    throw new ArgumentException("TC No 11 haneli olmalıdır!");
                }
            }
        }

        private string _DogumYeri;
        public string DogumYeri
        {
            get { return _DogumYeri; }
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
                    _DogumYeri = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Doğum yeri içerisinde yalnızca harf olmalıdır!");
                }
            }
        }

        private string _DogumTarihi;
        public string DogumTarihi
        {
            get { return _DogumTarihi; }

            set
            {
                byte digit = 0;
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                }
                if (oldumu && digit == 8)
                {
                    _DogumTarihi = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Lütfen doğum tarihini istenilen şekilde giriniz!");
                }
            }
        }

        private string _Adres;
        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value; }
        }

        private string _isebaslama;
        public string isebaslama
        {
            get { return _isebaslama; }
            set
            {
                byte digit = 0;
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }
                if (oldumu && digit == 8)
                {
                    _isebaslama = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Lütfen doğum tarihini istenilen şekilde giriniz!");
                }
            }
        }

        private string _Sifre;
        public string Sifre
        {
            get { return _Sifre; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (value.Length <= 20)
                {
                    _Sifre = value;
                }
                else if (value.Length > 20)
                {
                    throw new ArgumentException("Şifre 20 karakterden uzun olamaz!!");
                }
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (value.Contains("@gmail.com") || value.Contains("@hotmail.com")
                    || value.Contains("@outlook.com") || value.Contains("@live.com"))
                {
                    _email = value;
                }
                else
                {
                    throw new ArgumentException("Lütfen geçerli bir mail adresi giriniz!");
                }
            }
        }

        private string _tel;
        public string tel
        {
            get { return _tel; }
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
                    _tel = value;
                }
                else
                {
                    throw new ArgumentException("lütfen telefon alanını istenilen şekilde doldurunuz.");
                }
            }
        }

        public object image;

        #endregion

        #region Metotlar

        public List<string> Giris(string sorgu, string ad, string sifre)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.GirisDB(sorgu, ad, sifre);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable Listeleme(string action,string procedure)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.ListelemeDB(action,procedure);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Listeleme(string sorgu)
        {
            try
            {
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

        public MemoryStream Fotograf(string no,string sorgu)
        {
            try
            {
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


        #endregion



        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
