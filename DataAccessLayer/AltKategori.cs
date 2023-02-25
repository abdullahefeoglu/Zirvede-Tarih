using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AltKategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public int Kategoriler_ID { get; set; }
        public string Kategori { get; set; }
    }
}
