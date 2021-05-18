using EticaretMVC.Identity;
using EticaretMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretMVC.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }



        // GET: Account
        public ActionResult Register() //bu metod kayıt ol sayfasını getirecek
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//güvenlik için: sayfayı çağıran kullanıcı ile sayfayı post eden kullanıcı aynı kişi mi diye bakıyor
        public ActionResult Register(Register model) //bu metod ise katıt ol sayfasında kayıt ol butonuna tıkladığımızda çalışacak. Kayıt olma formundaki veriler buraya gelecek 
        {
            if (ModelState.IsValid) //register modelinde koyduğumuz kurallara uyuyorsa
            {
                //kayıt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabiliriz
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası.");
                }
            }
            return View(model); //kurallara uymuyorsa zaten kullanıcının girdiği bilgileri tekrar göndersin kullanıcıya anlatmıştım burayı daha önce
        }









        public ActionResult Login() //bu metod login sayfasını getirecek
        {
            //aşşağıdaki if yapısını kurmamdaki neden oturum açıkken kullanıcı tekrar login sayfasına ulaşamasın, anasayfaya yönlendirsin
            if (Request.IsAuthenticated) //eğer oturum açmışsa kullanıcı
            {
                //oluşturduğumuz cookie'yi sistemden siliyoruz ve kullanıcının oturumu kapanıyor 
                //var authManager = HttpContext.GetOwinContext().Authentication;
                //authManager.SignOut();

                return RedirectToAction("Index", "Home"); //bu metodu çalıştırsın
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//güvenlik için: sayfayı çağıran kullanıcı ile sayfayı post eden kullanıcı aynı kişi mi diye bakıyor
        public ActionResult Login(Login model, string ReturnUrl) //bu metod ise login sayfasında giriş butonuna tıkladığımızda çalışacak. login formundaki veriler buraya gelecek 
        {

            if (ModelState.IsValid) //register modelinde koyduğumuz kurallara uyuyorsa
            {
                //login işlemleri
                var user = UserManager.Find(model.UserName, model.Password);

                if (user!= null)//kullanıcı veritabanında varsa
                {
                    //var olan kullanıcıyı sisteme dahil et
                    //ApplicationCookie oluşturup sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok.");
                }
            }
            return View(model);
        }



        public ActionResult Logout() //bu metod login sayfasını getirecek
        {
            //oluşturduğumuz cookie'yi sistemden siliyoruz
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }




    }
}