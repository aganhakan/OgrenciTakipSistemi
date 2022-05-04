using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;

namespace OgrenciTakipBLL
{
    public class Ogrenci : BLL
    {
        private string _ogrencino;
        public string ogrencino
        {
            get { return _ogrencino; }
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
                if (oldumu && digit == 5)
                {
                    _ogrencino = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (digit != 5)
                {
                    throw new ArgumentException("Öğrenci no 5 haneli olmalıdır!");
                }
                else
                {
                    throw new ArgumentException("Öğrenci numarası içerisinde harf olmamalıdır!");
                }
            }
        }

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

        public string Guncelle(string procedure, string ogrencino, string TC, string dogumyeri, DateTime dogumtarihi,
        string anneadi, string babaadi, string velitel, string adres)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB(procedure, ogrencino, TC, dogumyeri, dogumtarihi, anneadi, babaadi, velitel, adres);
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
    }
}
