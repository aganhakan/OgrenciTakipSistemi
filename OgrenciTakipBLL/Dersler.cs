using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OgrenciTakipDAL;

namespace OgrenciTakipBLL
{
    public class Dersler : BLL
    {
        public enum Dersler1
        {
            Türkçe,
            Matematik,
            HayatBilgisi,
            GörselSanatlar,
            Müzik,
            Oyun,
            İngilizce
        }
        public string Ekle(string dersler, string id)
        {
            try
            {
                string sorgu = $"insert into Notlar (DersId, OgrenciId) " +
                    $"values ((select Id from Dersler where DersAdi = '{dersler}'),{id})";

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
