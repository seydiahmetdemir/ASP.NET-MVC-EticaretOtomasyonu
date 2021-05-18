using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EticaretMVC.Models
{
    public class Register
    {
        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Adınız")] // sitede text olarak Adınız gözüksün
        public string Name { get; set; }

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Soyadınız")] // sitede text olarak Soyadınız gözüksün
        public string SurName { get; set; }

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Kullanıcı Adı")] // sitede text olarak Kullaıcı Adı gözüksün gözüksün
        public string UserName { get; set; }

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("E-posta")] // sitede text olarak E-posta gözüksün
        [EmailAddress(ErrorMessage ="E-posta adresinizi düzgün giriniz.")] //email alsın
        public string Email { get; set; }

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Şifre")] // sitede text olarak Şifre gözüksün
        public string Password { get; set; }

        [Required] //kullanıcının bu sütuna değer girmesi zorunlu
        [DisplayName("Şifre Tekrar")] // sitede text olarak Şifre Tekrar gözüksün
        [Compare("Password",ErrorMessage="Şifreleriniz uyuşmuyor.")] //yukarıdaki Password alanını işaret ettik
        public string RePassword { get; set; }
    }
}