using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;
using System.Data;

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
        public string Ekle(string sinif, string sube)
        {
            try
            {
                string sorgu = $"Insert Into Siniflar(Sinif,Sube) Values ('{sinif}','{sube}')";
                using (DAL objdal = new DAL())
                {
                    return objdal.EkleDB(sorgu);
                }
            }
            catch (Exception)
            {
                return "Bu sınıfı silemezsiniz. Bu sınıfta öğretmen veya öğrenciler bulunmaktadır.";
            }
        }
        public string Delete(string sinif, string sube)
        {
            try
            {
                string sorgu = $"Delete from Siniflar Where Sinif = '{sinif}' and Sube = '{sube}'";
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
        public DataTable Listeleme()
        {
            try
            {
                string sorgu = "Select Sinif + ' / ' + Sube as 'Mevcut Sınıflar' from Siniflar order by Sinif asc";
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
    }
}
