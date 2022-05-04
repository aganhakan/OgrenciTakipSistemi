using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;

namespace OgrenciTakipBLL
{
    public class Siniflar : BLL
    {
        public enum Subeler
        {
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H
        }
        public int[] sinif = { 1, 2, 3, 4 };
        public string Ekle(string sorgu)
        {
            try
            {
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
    }
}
