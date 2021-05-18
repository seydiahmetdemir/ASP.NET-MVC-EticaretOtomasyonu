using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class Product
    {
        public int Id { get; set; }
        
        [DisplayName("Ürün Adı")] //admin sayfasındaki sütun adını Name yerine Ürün Adı yaptık görünüşünü değiştirdik yani
        public string Name { get; set; }

        [DisplayName("Ürün Açıklama")]
        public string Description { get; set; }
        [DisplayName("Fiyat")]
        public double Price { get; set; }
        [DisplayName("Stok Adedi")]
        public int  Stock { get; set; } //stokta kaç adet o üründen var onu tutacak
        [DisplayName("Fotoğraf")]
        public string Image { get; set; }
        [DisplayName("Satışta Mı?")]
        public bool IsApproved { get; set; }  //stokta var mı yok mu
        [DisplayName("Anasayfada Gözüksün Mü?")]
        public bool IsHome { get; set; }  //anasayfada gösterilecek mi



        //her bir ürünün bir kategorisi olma zorunluluğu yoksa  alttaki CategoryId nin tipi olan int yerine int? kullannm
        //sınıf adı+Id
        public int CategoryId { get; set; }//Product tablosuna böyle bir sütun ekledik
        public Category Category { get; set; }  // bu da ilişki için eklendi


        public List<Yorum> Yorums { get; set; }

    }
}