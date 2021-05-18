using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EticaretMVC.Entity;

namespace EticaretMVC.Models
{
    public class TablolarModel
    {
        public List<int> satilanadet { get; set; }
        public List<string> urunisim { get; set; }
        public List<int> urunid { get; set; }
        
        public List<Cart> Carts { get; set; }
        public List<Product> Products { get; set; }

    }
}