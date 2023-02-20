using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yonetici
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Mail { get; set; }
        public string  Sifre { get; set; }
        public bool Aktif { get; set; }
    }
}
