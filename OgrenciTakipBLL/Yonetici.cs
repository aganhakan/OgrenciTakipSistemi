using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OgrenciTakipDAL;

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
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException(" Görev içerisinde yalnızca harf olmalıdır!");
                }
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
    }
}
