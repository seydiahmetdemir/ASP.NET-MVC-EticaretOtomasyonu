using EticaretMVC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models
{
    public class UrunVeYorumModel
    {
        public List<Yorum> Yorumlar { get; set; }
        public List<Product> Urunler { get; set; }
    }
}