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
        public string Guncelle(string procedure, string dogumyeri, DateTime dogumtarihi, string sifre,
        string email, string tel, string adres, byte[] resim, string tc)
        {
            try
            {
                using (DAL objDal = new DAL())
                {
                    return objDal.EkleDB(procedure, dogumyeri, dogumtarihi, sifre, email, tel, adres, resim, tc);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
