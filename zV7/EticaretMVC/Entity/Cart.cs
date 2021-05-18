using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class Cart
    {
        public int Id { get; set; }//

        
        public string UserId { get; set; }//
        public int UrunId { get; set; }//

        [DisplayName("Fiyat")]
        public int Price { get; set; }//
        [DisplayName("Sipariş Tarihi")]
        public DateTime DateTime { get; set; }//
        [DisplayName("Ürün Adı")]
        public string UrunName { get; set; }//
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }//
        
        public string Tel { get; set; }//
        [DisplayName("Adres")]
        public string Address { get; set; }//

        [DisplayName("Ödendi Mi?")]
        public bool odendimi { get; set; }//öde butonuna tıkladığında sepetteki kayıtların bu sütunu true olsun ve true olan kayıtlar kullanıcının sepetinde gözükmesin 
                                          //false olan kayıtlar sepette gözüksün sadece ayarla onu
                                          //bu true ise kullanıcının önceki siparişler sayfasına düşsün
        [DisplayName("Kargoya Verildi Mi?")]
        public bool kargoyaverildimi { get; set; }//admin sayfasında gelen siparişler bölümünde kargoya verildiyse kargoya verildi true olsun. 

        //sorguyu controllerdan yap. cartmodel ile de gönder verileri. diğer sayfalarda örnekleri var


        [DisplayName("Ürün Fotoğrafı")]
        public string UrunImage { get; set; }
        
        






    }
}