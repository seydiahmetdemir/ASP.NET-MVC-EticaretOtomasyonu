using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models
{
    public class KarModel
    {
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public int SatisAdet { get; set; }
        public int Fiyat { get; set; }
        public string UrunFoto { get; set; }
    }
}