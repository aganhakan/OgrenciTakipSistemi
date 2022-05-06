using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace OgrenciTakipDAL
{
    public class DAL : IDisposable
    {
        string baglanticumlesi = "Data Source=.;Initial Catalog=OgrenciTakipSistemi;Integrated Security=True";
        public List<string> GirisDB(string sorgu, string ad)
        {
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                List<string> girislist = new List<string>();

                baglanti.Open();
                using (SqlCommand komut = new SqlCommand(sorgu, baglanti))
                {
                    komut.Parameters.AddWithValue("@p1", ad);
                    using (SqlDataReader dr = komut.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                girislist.Add(dr[i].ToString());
                            }
                        }
                        baglanti.Close();
                    }
                }
                return girislist;
            }
        }
        public DataTable ListelemeDB(string action, string procedure)
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
                {
                    baglanti.Open();

                    using (SqlCommand cmd = new SqlCommand(procedure, baglanti))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Action", action);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable ds = new DataTable())
                            {
                                da.Fill(ds);
                                baglanti.Close();
                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable ListelemeDB(string sorgu)
        {
            try
            {
                using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
                {
                    baglanti.Open();

                    using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable ds = new DataTable())
                            {
                                da.Fill(ds);
                                baglanti.Close();
                                return ds;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string EkleDB(string procedure, string ogrencino, string TC, string dogumyeri, DateTime dogumtarihi,
        string anneadi, string babaadi, string velitel, string adres)
        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(procedure, baglanti))
                {
                    kayit.CommandType = CommandType.StoredProcedure;

                    kayit.Parameters.AddWithValue("@OgrenciNo", ogrencino);
                    kayit.Parameters.AddWithValue("@Tc", TC);
                    kayit.Parameters.AddWithValue("@DogumYeri", dogumyeri);
                    kayit.Parameters.AddWithValue("@DogumTarihi", dogumtarihi);
                    kayit.Parameters.AddWithValue("@Anneadi", anneadi);
                    kayit.Parameters.AddWithValue("@Babaadi", babaadi);
                    kayit.Parameters.AddWithValue("@Velitel", velitel);
                    kayit.Parameters.AddWithValue("@Adres", adres);

                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string EkleDB(string procedure, string dogumyeri, DateTime dogumtarihi, string sifre,
        string email, string tel, string adres, string tc)

        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(procedure, baglanti))
                {
                    kayit.CommandType = CommandType.StoredProcedure;

                    kayit.Parameters.AddWithValue("@DogumYeri", dogumyeri);
                    kayit.Parameters.AddWithValue("@DogumTarihi", dogumtarihi);
                    kayit.Parameters.AddWithValue("@Sifre", sifre);
                    kayit.Parameters.AddWithValue("@EMail", email);
                    kayit.Parameters.AddWithValue("@Tel", tel);
                    kayit.Parameters.AddWithValue("@Adres", adres);
                    kayit.Parameters.AddWithValue("@Tc", tc);

                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string EkleDB(string sorgu)

        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(sorgu, baglanti))
                {
                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string EkleDB2(string procedure, string adsoyad, string Tc, string dogumyeri, DateTime dogumtarihi,
        DateTime isebaslama, string sifre, string sinif, string sube, string email, string tel, string adres, string id)
        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(procedure, baglanti))
                {
                    kayit.CommandType = CommandType.StoredProcedure;

                    kayit.Parameters.AddWithValue("@AdSoyad", adsoyad);
                    kayit.Parameters.AddWithValue("@TC", Tc);
                    kayit.Parameters.AddWithValue("@DogumYeri", dogumyeri);
                    kayit.Parameters.AddWithValue("@DogumTarihi", dogumtarihi);
                    kayit.Parameters.AddWithValue("@Isebaslama", isebaslama);
                    kayit.Parameters.AddWithValue("@Sifre", sifre);
                    kayit.Parameters.AddWithValue("@Sinif", sinif);
                    kayit.Parameters.AddWithValue("@Sube", sube);
                    kayit.Parameters.AddWithValue("@EMail", email);
                    kayit.Parameters.AddWithValue("@Tel", tel);
                    kayit.Parameters.AddWithValue("@Adres", adres);
                    kayit.Parameters.AddWithValue("@Id", id);

                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string EkleDB2(string procedure, string ogrencino, string ad, string TC, string dogumyeri, DateTime dogumtarihi,
        string sinif, string sube, string anneadi, string babaadi, string velitel, string adres,string id)
        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(procedure, baglanti))
                {
                    kayit.CommandType = CommandType.StoredProcedure;

                    kayit.Parameters.AddWithValue("@OgrenciNo", ogrencino);
                    kayit.Parameters.AddWithValue("@AdSoyad", ad);
                    kayit.Parameters.AddWithValue("@TC", TC);
                    kayit.Parameters.AddWithValue("@DogumYeri", dogumyeri);
                    kayit.Parameters.AddWithValue("@DogumTarihi", dogumtarihi);
                    kayit.Parameters.AddWithValue("@Sinif", sinif);
                    kayit.Parameters.AddWithValue("@Sube", sube);
                    kayit.Parameters.AddWithValue("@Annead", anneadi);
                    kayit.Parameters.AddWithValue("@Babaad", babaadi);
                    kayit.Parameters.AddWithValue("@Tel", velitel);
                    kayit.Parameters.AddWithValue("@Adres", adres);
                    kayit.Parameters.AddWithValue("@Id", id);

                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string EkleDB2(string procedure, string adsoyad, string Tc, string dogumyeri, DateTime dogumtarihi,
        DateTime isebaslama, string sifre, string gorev, string email, string tel, string adres, string id)
        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(procedure, baglanti))
                {
                    kayit.CommandType = CommandType.StoredProcedure;

                    kayit.Parameters.AddWithValue("@AdSoyad", adsoyad);
                    kayit.Parameters.AddWithValue("@TC", Tc);
                    kayit.Parameters.AddWithValue("@DogumYeri", dogumyeri);
                    kayit.Parameters.AddWithValue("@DogumTarihi", dogumtarihi);
                    kayit.Parameters.AddWithValue("@Isebaslama", isebaslama);
                    kayit.Parameters.AddWithValue("@Sifre", sifre);
                    kayit.Parameters.AddWithValue("@Gorev", gorev);
                    kayit.Parameters.AddWithValue("@EMail", email);
                    kayit.Parameters.AddWithValue("@Tel", tel);
                    kayit.Parameters.AddWithValue("@Adres", adres);
                    kayit.Parameters.AddWithValue("@Id", id);

                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string FotoGuncelle(string sorgu, byte[] resim)

        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(sorgu, baglanti))
                {
                    baglanti.Open();
                    kayit.Parameters.AddWithValue("@p1", resim);

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public string SilDB(string sorgu)

        {
            string mesaj = "";
            using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand kayit = new SqlCommand(sorgu, baglanti))
                {
                    baglanti.Open();

                    if (kayit.ExecuteNonQuery() > 0)
                        mesaj = ("İşlem başarılı");
                    else
                        mesaj = ("İşlem başarısız");
                }
                baglanti.Close();
            }
            return mesaj;
        }
        public MemoryStream Fotograf(string no, string sorgu)
        {
            try
            {
                MemoryStream mem = new MemoryStream();

                using (SqlConnection baglanti = new SqlConnection(baglanticumlesi))
                {
                    baglanti.Open();

                    using (SqlCommand cmd = new SqlCommand(sorgu, baglanti))
                    {

                        cmd.Parameters.AddWithValue("@No", no);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                da.Fill(ds);
                                baglanti.Close();
                                if (ds.Tables[0].Rows.Count == 1)
                                {
                                    Byte[] data = new Byte[0];
                                    data = (Byte[])(ds.Tables[0].Rows[0]["Fotograf"]);
                                    mem = new MemoryStream(data);                              
                                }
                            }
                        }
                    }
                }
                return mem;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
