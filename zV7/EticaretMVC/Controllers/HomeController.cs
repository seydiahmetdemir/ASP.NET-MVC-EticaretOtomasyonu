using EticaretMVC.Entity;
using EticaretMVC.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace EticaretMVC.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext(); //_context adında DataContext tipinde bir nesne oluşturduk
        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsHome == true && i.IsApproved == true)
                .Select(i => new ProductModel()
                {
                    Id=i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description =i.Description.Length>50?i.Description.Substring(0,47)+"...":i.Description,
                    Price=i.Price,
                    Stock=i.Stock,
                    Image=i.Image,
                    CategoryId=i.CategoryId


                }).ToList(); 

            
            
            return View(urunler); 
        }





        static int yorumurunid;     
                        //       metodumuza view'den int türünde veri gelecek (kullanıcı index veya List  sayfasında bir ürüne tıkladığında hangi ürüne tıkladığını anlamak için. Daha sonrasında ise ürün sayfasında ürün gözükecek)
        public ActionResult Details(int? id)
        {
            //               dışarıdan gelen id verisi ürünün Id 'sine eşitse O Id'ye sahip ürün kaydını Details view'ine göndersin
            //return View(_context.Products.Where(i => i.Id==id).FirstOrDefault()); //eğer ki birden fazla kayıt gönderseydik .ToList() diyecektik
            //FirstOrDefault() anahtar sözcüğü koleksiyonda bulunan verilerin ilk değerini döner. Eğer koleksiyonda veri yok ise Default olarak null döndürür
            UrunVeYorumModel model = new UrunVeYorumModel();

            if (id==null)
            {
                ViewBag.Urununid = yorumurunid;


                model.Urunler = _context.Products.ToList();
                model.Yorumlar = _context.Yorums.ToList();

                return View(model);
            }

            ViewBag.Urununid = id;

            
            
            model.Urunler = _context.Products.ToList();
            model.Yorumlar = _context.Yorums.ToList();


            return View(model);
        }


        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Yorumm(int urunid,int rating, string yazi)
        {
            
            Yorum entity = new Yorum();
            entity.UserName= User.Identity.Name;
            entity.Yorumlar = yazi;
            entity.UrunPuan = rating;
            entity.ProductId = urunid;
            entity.Tarih= DateTime.Now;

            _context.Yorums.Add(entity);
            _context.SaveChanges();

            yorumurunid = urunid;
            //return View();
            return RedirectToAction("Details", "Home");
        }




        static int? KatagoriIDDD;

        public ActionResult List(int? id, int sayfa=1)// buradaki ? işareti metoda illaki birşeyin gelmesi şart değil demek. yani buradaki id değişkenin içerisi null olabilir
        {
            var urunler = _context.Products
                .Where(i => i.IsApproved == true)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image==null?"1.jpg":i.Image, //i.Image içerisi boşsa 1.jpg resmini yükle: doluysa i.Image resmini yükle
                    CategoryId = i.CategoryId


                }).AsQueryable();//AsQueryable: aşağıdaki sorgulamaya devam etmek için koydu

            if (id!=null)//id boş değilse
            {   //ürünler değişkenin içerisini CategoryId'si id'ye eşit olan ürünleri atsın
                urunler = urunler.Where(i => i.CategoryId == id);
            }
            ViewBag.kategoriid = id.ToString();
            KatagoriIDDD = id;
            ViewBag.urunsayisi = urunler.Count();
            //if (sayfalamaid==null)
            //{
            //    sayfalamaid = 0;
            //}


            //return View(urunler.OrderBy(i => i.Id).Skip((int)sayfalamaid).Take(3).ToList());
            //return View(urunler.OrderBy(i => i.Id).Skip((int)sayfalamaid*3).Take(3).ToList());
            return View (urunler.ToList().ToPagedList(sayfa,9));
        }


        //bu bir PartialView dir
        //yandaki Solution Explorer'da sağ tıklayıp oluşturmak yerine burada oluşturduk
        public PartialViewResult GetCategories()
        {
            ViewBag.secilikatagori = KatagoriIDDD;
            return PartialView(_context.Categories.ToList());
        }

       
















    }
}