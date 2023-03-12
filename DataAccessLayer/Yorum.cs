﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int Uye_ID { get; set; }
        public string Uye { get; set; }
        public int Makale_ID { get; set; }
        public string Makale { get; set; }
        public int Yonetici_ID { get; set; }
        public string  Yonetici { get; set; }
        public DateTime YorumTarih { get; set; }
        public int YorumBegeni { get; set; }
        public string YorumIcerik { get; set; }
        public bool Aktiflik { get; set; }
        public string AktiflikStr { get; set; }
    }
}
