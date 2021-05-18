using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models
{
    public class CartModel
    {

        public string UserId { get; set; }//
        public int UrunId { get; set; }//
        public int Price { get; set; }//

        public string UrunName { get; set; }//
        public string UserName { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }

        public bool odendimi { get; set; }//öde butonuna tıkladığında sepetteki kayıtların bu sütunu true olsun ve true olan kayıtlar kullanıcının sepetinde gözükmesin 
                                          //false olan kayıtlar sepette gözüksün sadece ayarla onu
                                          //bu true ise kullanıcının önceki siparişler sayfasına düşsün

        public bool kargoyaverildimi { get; set; }//admin sayfasında gelen siparişler bölümünde kargoya verildiyse kargoya verildi true olsun. 

        //sorguyu controllerdan yap. cartmodel ile de gönder verileri. diğer sayfalarda örnekleri var

        public string UrunImage { get; set; }
    }
}