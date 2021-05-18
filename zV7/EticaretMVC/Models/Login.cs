using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models
{
    public class Login
    {
        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Kullanıcı Adı")] // sitede text olarak Kullaıcı Adı gözüksün gözüksün
        public string UserName { get; set; }

        

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Şifre")] // sitede text olarak Şifre gözüksün
        public string Password { get; set; }

       
        [DisplayName("Beni Hatırla")] // sitede text olarak Beni Hatırla gözüksün
        public bool RememberMe { get; set; }
    }
}