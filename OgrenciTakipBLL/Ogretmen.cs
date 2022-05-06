using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;

namespace OgrenciTakipBLL
{
    public class Ogretmen : BLL
    {
        public string Guncelle(string procedure, string dogumyeri, string dogumtarihi, string sifre,
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
                    return objDal.EkleDB(procedure, dogumyeri, dt, sifre, email, tel, adres, tc);
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
    }
}
