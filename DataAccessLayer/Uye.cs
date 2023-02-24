using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Uye
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public DateTime KatılımTarihi { get; set; }
        public int YorumSayisi { get; set; }
        public bool Aktif { get; set; }
    }
}
