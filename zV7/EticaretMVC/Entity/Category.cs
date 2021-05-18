using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class Category
    {
        public int Id { get; set; }

        
        [DisplayName("Kategori Adı")] //Name sütunu sitede Kategori Adı olarak görünecek (sadece görünümünü değiştirdik)
        [StringLength(maximumLength:20,ErrorMessage ="En fazla 20 karakter girebilirsiniz.")] //Name sütununa kural getirdik
        public string Name { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; } 

        // her bir kategori birden fazla ürün barındıracağı için
        //bire çok ilişki yaptık
        public List<Product> Products { get; set; }

    }
}