using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EticaretMVC.Entity;


namespace EticaretMVC.Controllers
{   //BU CONTROLLER; CONTROLLER SEÇİM EKRANINDAN 3.SÜ SEÇİLEREK HAZIRLANDI YANİ HAZIR GELDİ ÇOĞU ŞEY

    //Gönderilen bilgiler adres satırında görünmediği için daha güvenlidir ancak Get methoduna göre daha yavaştır. 
    //Get metodu sunucudan veri çekmek için tasarlanmış bir metodtur. 
    //Post (ve daha az bilinen arkadaşları olan Put ve Delete) ise sunucudaki veriyi düzenlemek için tasarlanmıştır.





    //[Authorize] //login olan herkes bu controller'a ulaşabilir.
    //[Authorize(Roles = "user")] //user rolündeki kullanıcılar bu controller'a ulaşabilir
    [Authorize(Roles ="admin")] //admin rolündeki kullanıcılar bu controller'a ulaşabilir
    public class CategoryController : Controller
    {
        private DataContext db = new DataContext(); 

        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }






        // GET: Category/Create
        //Get metodunun amacı Create sayfasını açmak
        //metodun üzerine [HttpPost] veya [HttpGet] yazmassan [HttpGet] olarak kabul eder. Yani bu metod [HttpGet] metodu 
        public ActionResult Create() 
        {   
            return View();
        }

        // POST: Category/Create
        //create sayfasında kaydete tıkladığım zaman girilen bilgiler bu metoda geliyor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)//Category entity'sine kısıtlama koyduk 20 karakteri geçmeyecek dedik o kuralları kontrol ediyor
            {   //kuralları kullanıcı doğyur yapmışsa 
                
                db.Categories.Add(category); //veritabanına kaydediliyor
                db.SaveChanges();  //veritabanına kaydediliyor
                return RedirectToAction("Index"); //Category/index sayfasına yolluyor bizi
            }

            return View(category); //kullanıcının girdiği verileri tekrar bulunduğu sayfaya yani Category/Create sayfasına yolluyor ve tekrar o sayfaya gidiyor. 
                                    //Peki ama neden? Çünkü kullanıcı yanlış yazmışsa; yazıları tekrar yazdığı yerde dursun. Yanlış yazdığı zaman kaydet butonuna tıkladığında verileri gitmesin
        }











        // GET: Category/Edit/5
        public ActionResult Edit(int? id)//get ile metoda veri geliyor yani arama kutusunda taşıyor veriyi
        {   // /Category/Index sayfasında edite tıkladığın zaman bu metod çalışıyor işte.
            if (id == null) //id nul ise
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//hata mesajı sayfasına yolla çünkü kayıt üzerine güncelleme yapacağız id gelmesi şart
            }
            Category category = db.Categories.Find(id); //gelen id'ye ait ilk kaydı category değişkenine atıyor
            if (category == null)//category değişkeni boşsa
            {
                return HttpNotFound(); //hata sayfasına gönderiyor
            }
            return View(category);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Category category)
        {   //edit sayfasındaki formu doldurup kaydet'e bastığımzı zaman veriler gizli gitmesi için HttpPost ile veriler buraya geliyor
            if (ModelState.IsValid) //Category entity'sine kısıtlama koyduk 20 karakteri geçmeyecek dedik o kuralları kontrol ediyor
            {
                db.Entry(category).State = EntityState.Modified;//veritabanına kaydediyor
                db.SaveChanges();//veritabanına kaydediyor
                return RedirectToAction("Index"); //Category/index sayfasına yolluyor bizi
            }
            return View(category);
        }








        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")] //yukarıdaki metodun ismi ve gelen değeri bu metod ile aynı olmasın diye böyle bir şey yapılıyor
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
