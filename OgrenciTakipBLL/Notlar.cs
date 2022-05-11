using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;

namespace OgrenciTakipBLL
{
    public class Notlar : BLL
    {
        private string _sinav1;
        public string sinav1
        {
            get { return _sinav1; }
            set
            {
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }

                if (oldumu == true && int.Parse(value) <= 100)
                {
                    _sinav1 = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("1.Sınav Boş Olamaz!");
                }
                else if (oldumu == true && int.Parse(value) > 100)
                {
                    throw new ArgumentException("Sınav notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Sınav notu pozitif tam sayı olmalıdır.!");
                }
            }
        }

        private string _sinav2;
        public string sinav2
        {
            get { return _sinav2; }
            set
            {
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }

                if (oldumu == true && int.Parse(value) <= 100)
                {
                    _sinav2 = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("2. Sınav Boş Olamaz!");
                }
                else if (oldumu == true && int.Parse(value) > 100)
                {
                    throw new ArgumentException("Sınav notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Sınav notu pozitif tam sayı olmalıdır.!");
                }
            }
        }

        private string _kanaat;
        public string kanaat
        {
            get { return _kanaat; }
            set
            {
                bool oldumu = false;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                    }
                    else
                    {
                        oldumu = false;
                        break;
                    }
                }

                if (oldumu == true && int.Parse(value) <= 100)
                {
                    _kanaat = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("Kanaat Notu Boş Olamaz!");
                }
                else if (oldumu == true && int.Parse(value) >100)
                {
                    throw new ArgumentException("Kanaat notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Kanaat notu pozitif tam sayı olmalıdır.");
                }
            }
        }
        public string Ortalama(string sinav1, string sinav2, string sinav3)
        {
            this.sinav1 = sinav1;
            this.sinav2 = sinav2;
            this.kanaat = sinav3;

            return Math.Round(((double.Parse(_sinav1) + double.Parse(_sinav2) + double.Parse(_kanaat)) / 3),2).ToString();
        }
        public string Durum(string ort)
        {
            try
            {
                if (!string.IsNullOrEmpty(ort))
                {
                    if (float.Parse(ort) >= 50)
                        return "Geçti";
                    else
                        return "Kaldı";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Ekle(string sinav1, string sinav2, string kanaat, string ortalama, string durum, string id, string ders)
        {
            try
            {
                string sorgu = $"Update Notlar set Sinav1 = {sinav1}, Sinav2 = '{sinav2}', " +
                          $"KanaatNot = '{kanaat}', Ortalama = '{ortalama}', Durum = '{durum}' " +
                          $" where OgrenciId = {id} and " +
                          $"DersId = (Select Id from Dersler where DersAdi = '{ders}')";

                using (DAL objdal = new DAL())
                {
                    return objdal.EkleDB(sorgu);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string Kanaat(string sinav1, string sinav2, string kanaat)
        {
            try
            {

                string ortalama = null;
                if (!string.IsNullOrEmpty(sinav1) && !string.IsNullOrEmpty(sinav2) && !string.IsNullOrEmpty(kanaat))
                {
                    ortalama = this.Ortalama(sinav1, sinav2, kanaat);
                }
                else if (!string.IsNullOrEmpty(sinav1) && !string.IsNullOrEmpty(sinav2))
                {
                    this.sinav1 = sinav1;
                    this.sinav2 = sinav2;
                }
                else if (!string.IsNullOrEmpty(sinav1))
                {
                    this.sinav1 = sinav1;
                }
                else if (!string.IsNullOrEmpty(sinav2))
                {
                    this.sinav2 = sinav2;
                }

                return Durum(ortalama);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
