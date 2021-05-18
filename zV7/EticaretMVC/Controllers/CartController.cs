using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EticaretMVC.Entity;
using EticaretMVC.Models;
using Microsoft.AspNet.Identity;

namespace EticaretMVC.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();
        //static List<int> SepettekiUrunIdleri = new List<int>();

        // GET: Cart
        [Authorize(Roles = "user")]
        [HttpGet]
        public ActionResult Index()//Sepetim
        {
            
            string UserName = User.Identity.Name;
            string Idd = User.Identity.GetUserId();
            //string Idd = User.Identity.Name;
            var sepet = db.Carts
                .Where(i => i.UserName == UserName && i.odendimi==false).OrderByDescending(i => i.DateTime).ToList();
            

           
            //foreach (var item in sepet)
            //{
            //    SepettekiUrunIdleri.Add(item.Id);

                
            //}

            return View(sepet);

        }









        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(string Telefon, string Adres)//Sepetim sayfasında odeye tıkladığında
        {
            string UserName = User.Identity.Name;
            string Idd = User.Identity.GetUserId();
            //string Idd = User.Identity.Name;
            //var sepet = db.Carts
            //    .Where(i => i.UserName == UserName && i.odendimi == false).OrderByDescending(i => i.DateTime).ToList();

            //foreach (int item in SepettekiUrunIdleri)
            //{
            //    foreach (var i in db.Carts)
            //    {
            //        if (item == i.Id)
            //        {
            //            i.odendimi = true;
            //            i.Tel = Telefon;
            //            i.Address = Adres;
            //        }

            //    }
            //}

            ////////foreach (var i in db.Carts)
            ////////{
            ////////    if ( i.odendimi==false && i.UserName==UserName)
            ////////    {
            ////////        i.odendimi = true;
            ////////        i.Tel = Telefon;
            ////////        i.Address = Adres;
            ////////    }
            ////////}
            
                foreach (var i in db.Carts)
                {
                    if (i.odendimi == false && i.UserName == UserName )
                    {
                        i.odendimi = true;
                        i.Tel = Telefon;
                        i.Address = Adres;
                        foreach (var item in db.Products)
                        {
                            if (item.Id == i.UrunId)
                            {
                                item.Stock--;
                            }
                        }
                    }
                }
            
            
            db.SaveChanges();

            //foreach (var sepetId in SepettekiUrunIdleri)
            //{
            //    foreach (var ProId in db.Products)
            //    {

            //        if (ProId.Id == sepetId)
            //        {
            //            ProId.Stock = 555;
            //        }
            //    }
            //}





            //SepettekiUrunIdleri.Clear();
            return RedirectToAction("Index", "Cart");
            
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Ode()//kullanılmıyor bu metod
        {

            //foreach (int item in SepettekiUrunIdleri)
            //{
            //    foreach (var i in db.Carts)
            //    {
            //        if (item == i.Id)
            //        {
            //            i.odendimi = true;
            //        }
            //    }
            //}
            //db.SaveChanges();

            //foreach (var sepetId in SepettekiUrunIdleri)
            //{
            //    foreach (var ProId in db.Products)
            //    {
                    
            //        if (ProId.Id==sepetId)
            //        {
            //            ProId.Stock--;
            //        }
            //    }
            //}
            //db.SaveChanges();

            //SepettekiUrunIdleri.Clear();
            return RedirectToAction("Index", "Cart");
        }

        //KargolanacakSiparisler
        //KargolanmisSiparisler
        [Authorize(Roles = "admin")]
        public ActionResult KargolanacakSiparisler()
        {
            
            var kargo = db.Carts
                .Where(i => i.kargoyaverildimi == false && i.odendimi == true).OrderBy(i => new { i.UserName, i.DateTime }).ToList();
            return View(kargo);
        }

        [Authorize(Roles = "admin")]
        public ActionResult KargolanmisSiparisler()
        {
            var kargo = db.Carts
                .Where(i => i.kargoyaverildimi == true && i.odendimi == true).OrderBy(i => new {i.UserName, i.DateTime}).ToList();
            return View(kargo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KargoyaVerildi(int UrunIdd)
        {
            int CartKargolanacakId = UrunIdd;
            var CartKayitlar = db.Carts.ToList();
           
            
            foreach (var item in CartKayitlar)
            {
                if (item.Id == CartKargolanacakId)
                {
                    item.kargoyaverildimi = true;


                }
            }

            db.SaveChanges();




            return RedirectToAction("KargolanacakSiparisler", "Cart");
        }




        // GET: Cart/Details/5
        [Authorize(Roles = "user")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SepeteEkle(int UrunIdd)
        {
            int urunid = UrunIdd;
            var urun = db.Products.ToList();
            //var sepet = db.Products
            //    .Where(i => i.Id == Id)
            //    .Select(i => new CartModel()
            //    {
            //        UserId = User.Identity.GetUserId(),
            //        UrunId = i.Id,
            //        Price = (int)i.Price,
            //        UrunName = i.Name,
            //        UserName = User.Identity.Name,
            //        Tel = null,
            //        Address = null,
            //        odendimi = false,
            //        kargoyaverildimi = false,
            //        UrunImage = i.Image


            //    }).ToList();
            Cart entity = new Cart();
            foreach (var item in urun)
            {
                if (item.Id==urunid)
                {
                    entity.UserName = User.Identity.Name;
                    entity.UrunName = item.Name;
                    entity.UrunId = UrunIdd;
                    entity.UserId = User.Identity.GetUserId();
                    entity.Address = null;
                    entity.kargoyaverildimi = false;
                    entity.odendimi = false;
                    entity.Price = (int)item.Price;
                    entity.Tel = null;
                    entity.UrunImage = item.Image;
                    entity.DateTime = DateTime.Now;


                }
            }
            
            
            db.Carts.Add(entity);
            db.SaveChanges();
            

           

            return RedirectToAction("Index", "Cart");
        }

        [Authorize(Roles = "user")]
        public ActionResult OncekiSiparisler()
        {

            //var Siparisler = db.Carts.ToList();
            //foreach (var item in Siparisler)
            //{
            //    if (item.odendimi==true)
            //    {



            //    }
            //}
            string Idd = User.Identity.GetUserId();
            string UserName = User.Identity.Name;
            //var OdenenSiparisler = db.Carts.Where(i => i.UserId == Idd && i => i.odendimi == true).ToList();
            //return View();
            var urunler = db.Carts
               .Where(i => i.UserName == UserName && i.odendimi == true).OrderByDescending(i=>i.DateTime)
               .ToList();



            return View(urunler);
        }



        // GET: Cart/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,UserId,UrunId,Price,UrunName,UserName,Tel,Address,odendimi,kargoyaverildimi,UrunImage")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Carts.Add(cart);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(cart);
        //}

        // GET: Cart/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Cart cart = db.Carts.Find(id);
        //    if (cart == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cart);
        //}

        //// POST: Cart/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,UserId,UrunId,Price,UrunName,UserName,Tel,Address,odendimi,kargoyaverildimi,UrunImage")] Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cart).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cart);
        //}

        // GET: Cart/Delete/5
        [Authorize(Roles = "user")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Cart/Delete/5
        [Authorize(Roles = "user")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
