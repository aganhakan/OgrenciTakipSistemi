using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakipBLL
{
    public class Dersler : BLL
    {
        private string _ders;

        public string ders
        {
            get { return _ders; }
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
                    _ders = value;
                }
                else if (value == string.Empty)
                {
                    throw new ArgumentException("İşaretli alanlar Boş Olamaz!");
                }
                else
                {
                    throw new ArgumentException("Dersler içerisinde yalnızca harf olmalıdır!");
                }
            }
        }

    }
}
