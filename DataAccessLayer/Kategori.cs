using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kategori
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public int Altkategori_ID { get; set; }
        public string altKategori { get; set; }
        public string kategoriAciklama { get; set; }
        public int begeniSayisi { get; set; }
        public int makaleSayisi { get; set; }
    }
}
