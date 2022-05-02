using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                byte digit = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                }

                if (oldumu == true && digit <=3)
                {
                    _sinav1 = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (digit > 3)
                {
                    throw new ArgumentException("Sınav notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Sınav notu içerisinde harf olamaz!");
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
                byte digit = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                }

                if (oldumu == true && digit <= 3)
                {
                    _sinav2 = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (digit > 3)
                {
                    throw new ArgumentException("Sınav notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Sınav notu içerisinde harf olamaz!");
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
                byte digit = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (char.IsDigit(value[i]))
                    {
                        oldumu = true;
                        digit++;
                    }
                }

                if (oldumu == true && digit <= 3)
                {
                    _kanaat = value.Trim();
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else if (digit > 3)
                {
                    throw new ArgumentException("Kanaat notu en fazla 100 olabilir!");
                }
                else
                {
                    throw new ArgumentException("Kanaat notu içerisinde harf olamaz!");
                }
            }
        }
        public string ortalama()
        {
            return ((int.Parse(_sinav1) + int.Parse(_sinav2) + int.Parse(_kanaat)) / 3).ToString();
        }

    }
}
