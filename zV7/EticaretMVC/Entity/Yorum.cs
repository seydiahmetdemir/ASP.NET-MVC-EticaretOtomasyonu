using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class Yorum
    {

        public int Id { get; set; }

        public string UserName { get; set; }//

        public string Yorumlar { get; set; }//

        public int  UrunPuan { get; set; }//

        public DateTime Tarih { get; set; }//

        public int ProductId { get; set; }//
        public Product Product { get; set; }  
    }
}