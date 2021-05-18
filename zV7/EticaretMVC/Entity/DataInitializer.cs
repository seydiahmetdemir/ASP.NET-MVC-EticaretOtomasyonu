using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //TEST VERİLERİMİZİ EKLİYORUZ !!!

            var kategoriler = new List<Category>()//Category tipinde kategoriler adında bir liste oluşturduk
            {
                new Category(){Name="Kamera", Description="Kamera ürünleri"},
                new Category(){Name="Laptop", Description="Laptop ürünleri"},
                new Category(){Name="Mouse", Description="Mouse ürünleri"},
                new Category(){Name="Klavye", Description="Klavye ürünleri"},
                new Category(){Name="Monitör", Description="Monitör ürünleri"},

            };

            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();










            var urunler = new List<Product>()
            {                                                                                                                                                                                                                          //IsHome=ture diye yazmassak o sütun false olarak kaydedilir veritabanına
                new Product() {Name="Sony Fdr-Ax100e 4K Ultra Hd Video Kamera", Description="Sony Fdr-Ax100e 4K Ultra Hd Video Kamera ( Sony Eurasia Garantilidir ) Sony FDR-AX100E 4K Ultra HD Video Kamera",Price=9595, Stock=50,IsApproved=true,CategoryId=1,IsHome=false,Image="kamera1.jpg"},
                new Product() {Name="Canon LEGRIA HF R806 Video Kamera (Canon Eurasia Garantili)",
                    Description="Canon LEGRIA HF R806 Video Kamera (Canon Eurasia Garantili) Canon LEGRIA HF R806 Aile anılarınızı, en iyi görüntüye ve sese sahip mükemmel kaliteli filmlere çekmek için kolay, uygun fiyatlı ve güçlü zuma sahip video kamera. 57x Gelişmiş Zum kolaylığı ile eğlenceli aile filmleri Kullanımı kolay ve eğlenceli olan bu kompakt video kamera, aile filmlerinizin mükemmel bir görüntü ve ses kalitesine sahip olmasını sağlayan 57x Gelişmiş Zum özelliğine, basit dokunmatik ekran kontrolüne ve güçlü teknolojilere sahiptir. Uzun ömürlü pil ile saatlerce çekim yapın.",
                    Price=2125,
                    Stock=45,
                    IsApproved=true,
                    CategoryId=1,
                    IsHome=false,
                    Image="kamera2.jpg"},
                new Product() {Name="Toshiba Camileo H20 Video Kamera", 
                    Description=" Toshiba Camileo H20 Video Kamera Sensör çözünürlüğü : 5 MP CMOS Sensor LCD Monitör: 3.0 TFT LCD Odak aralığı : 1 - 30 cm(makro) / 30 cm(normal) / sonsuz modu Zoom : 5x Optik zoom, 4x Dijital zoom Dosya formatı: MPEG 4 AVI Dahili bellek: 128 MB Nand Flash Memory Fotoğraf çözünürlüğü : Yüksek: 3200x2400 / Standart: 2592x1944 / Düşük:2048x1536 Film çözünürlüğü: HD1(1080p / 30fps) / HD2(720p / 30fps) / WVGA(848x480 / 60fps), VGA(30fps) / QVGA(30fps)",
                    Price=1234, 
                    Stock=50,
                    IsApproved=true,
                    CategoryId=1,
                    IsHome=false,
                    Image="kamera3.jpg"},
                
                new Product() {Name="Panasonic AG-UX180 4K Profesyonel Video Kamera", 
                    Description="Yeni Geliştirilmiş 24mm ile Sektörün En Geniş Açılı 20x Optik Zoom Lensi1.0 tipi Sensörlü Kayıt Kamerasında Dünyada İlk Kez 20x Optik Zoom Özelliği: Söz konusu 20x optik zum lensi, geniş açıda 24mm’den teleskopik açıda 480mm’ye kadar olan bir aralığı kapsar (4K 24p’de 35mm’lik film eşdeğeri). ",
                    Price=36100, 
                    Stock=25,
                    IsApproved=true,
                    CategoryId=1,
                    IsHome=false,
                    Image="kamera4.jpg"},
                



                new Product() {Name="Monster Abra A5 V15.8.4 Intel Core i7 10750H 16GB 500GB SSD GTX1650Ti Freedos 15.6'' FHD Taşınabilir Bilgisayar", Description="  Monster Abra A5 V15.8.4 Intel Core i7 10750H 16GB 500GB SSD GTX1650Ti Freedos 15.6'' FHD Taşınabilir Bilgisayar INTEL CORE İ7-10750H; 16 GB DDR4 2666MHZ; 500GB M.2 SSD PCIE 3.0; 4GB NVİDİA GEFORCE GTX 1650Tİ; INTEL® Wİ - Fİ 6 AX201, 2X2 AX +BLUETOOTH 5.1 M.2 2230(2, 4 GBPS); HD KAMERA; KART OKUYUCU; FREEDOS; SIRT ÇANTASI ",Price=8999, Stock=65,IsApproved=true,CategoryId=2,IsHome=false,Image="laptop1.jpg"},
                new Product() {Name="Lenovo IdeaPad 5 AMD Ryzen 7 5700U 8GB 512GB SSD Freedos 14 FHD Taşınabilir Bilgisayar 82LM006ETX", Description="Lenovo IdeaPad 5 AMD Ryzen 7 5700U 8GB 512GB SSD Freedos 14 FHD Taşınabilir Bilgisayar 82LM006ETX",Price=1500, Stock=200,IsApproved=true,CategoryId=2,IsHome=false,Image="laptop2.jpg"},
                new Product() {Name="Lenovo V14 IGL Intel Celeron N4020 8GB 256GB SSD Windows 10 Home 14 FHD Taşınabilir Bilgisayar 82C2001MTX", Description="Lenovo V14 IGL Intel Celeron N4020 8GB 256GB SSD Windows 10 Home 14 FHD Taşınabilir Bilgisayar 82C2001MTX ",Price=3499, Stock=100,IsApproved=true,CategoryId=2,IsHome=false,Image="laptop3.jpg"},
                new Product() {Name="Asus X540UA-GQ1394 Intel Core i3 7020U 4GB 256GB SSD Freedos 15.6 Taşınabilir Bilgisayar", Description=" Verimlilik ve Eğlence için Tasarlandı ASUS X540UA Intel Core i3 işlemci desteğine sahiptir. Günlük bilgi işlem ve eğlence ihtiyacınız için ideal bir dizüstü bilgisayardır.",Price=3500, Stock=43,IsApproved=true,CategoryId=2,IsHome=false,Image="laptop4.jpg"},
               




                new Product() {Name="Logitech G G102 Lightsync Gaming Mouse", Description="Logitech G G102 Lightsync Gaming Mouse",Price=198, Stock=230,IsApproved=true,CategoryId=3,IsHome=true,Image="mouse1.jpg"},
                new Product() {Name="Logitech M170 Kablosuz Mouse-Gri", Description="GÜVENİLİR 2,4 GHZ KABLOSUZ 10 metre (33 feet) mesafeye kadar güçlü, istikrarlı kablosuz bağlantı. Neredeyse hiç gecikme veya kesinti olmadan güvenle çalışabilir ve oyun oynayabilirsiniz. 10 metreye kadar test edilen kablosuz aralık, bilgisayar kullanım koşullarına ve çevresel koşullara bağlı olarak küçük değişiklikler gösterebilir.",Price=94, Stock=200,IsApproved=true,CategoryId=3,IsHome=false,Image="mouse2.jpg"},
                new Product() {Name="Lenovo 400 Kablosuz Mouse GY50R91293", Description="Lenovo 400 Kablosuz Mouse GY50R91293",Price=83, Stock=50,IsApproved=true,CategoryId=3,IsHome=true,Image="mouse3.jpg"},
                new Product() {Name="Microsoft Mobile 1850 Kablosuz Siyah Mouse (7MM-00002)", Description="Microsoft Mobile 1850 Kablosuz Siyah Mouse (7MM-00002) Konfor ve Taşınabilirlik için Tasarlandı Benzersiz bir hareket özgürlüğü için kablosuz özelliği ve yerleşik alıcı-verici depolama sunan Wireless Mobile Mouse 1850, hareket halinde kullanım için tasarlandı. Her iki elle de kullanımı kolaydır ve kolay gezinme sağlayan kaydırma tekeri bu fareyi modern, hareketli yaşam tarzınız için ideal cihaz haline getirir.",Price=89, Stock=500,IsApproved=true,CategoryId=3,IsHome=false,Image="mouse4.jpg"},
               



                new Product() {Name=" Lenovo Preferred Pro Iı USB Klavye Beyaz 4Y40V27488 ", Description="Lenovo Preferred Pro Iı USB Klavye Beyaz 4Y40V27488",Price=139, Stock=250,IsApproved=true,CategoryId=4,IsHome=false,Image="klavye1.jpg"},
                new Product() {Name="HP Slim Business USB F Klavye N3R87A6-AR4", Description=" Birden çok işletim sistemiyle uyumlu Birden çok işletim sistemiyle kullanılmak üzere optimize edilen tam boyutlu klavyeyle sorun yaşamadan çalışın.USB bağlantısı Klavyeyi bilgisayarınızdaki USB bağlantı noktalarından birine kolayca takın.",Price=99, Stock=200,IsApproved=true,CategoryId=4,IsHome=false,Image="klavye2.jpg"},
                new Product() {Name="Bloody B640 Q Türkçe Multimedya USB Aydınlatmalı Mekanik Oyuncu Klavye", Description="Bloody B640 Q Türkçe Multimedya USB Aydınlatmalı Mekanik Oyuncu Klavye",Price=453, Stock=50,IsApproved=true,CategoryId=4,IsHome=false,Image="klavye3.jpg"},
                new Product() {Name="Rampage KB-R206 Rainbow Aydınlatmalı Switch Mekanik Gaming Oyuncu Klavyesi", Description="Rampage KB-R206 Rainbow Aydınlatmalı Switch Mekanik Gaming Oyuncu Klavyesi",Price=269, Stock=38,IsApproved=true,CategoryId=4,IsHome=false,Image="klavye4.jpg"},
               



            };
            foreach (var item in urunler)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();











            var sepetler = new List<Cart>()//Category tipinde kategoriler adında bir liste oluşturduk
            {
                new Cart(){UserId="74afa923-b67c-45a8-9e1b-8b5d2ac5bb31", UrunId=4,UserName="ramazandemir",Tel="05356663345",Address="Mustafa Paşa Mahallesi 55. Sokak No:7 Samsun/Kavak",Price=36100,UrunName="Panasonic AG-UX180 4K Profesyonel Video Kamera",UrunImage="kamera4.jpg",kargoyaverildimi=false,odendimi=false,DateTime=new DateTime(2020, 8, 30, 0, 0, 0)},
                new Cart(){UserId="74afa923-b67c-45a8-9e1b-8b5d2ac5bb31", UrunId=5,UserName="ramazandemir",Tel="05356663345",Address="Mustafa Paşa Mahallesi 55. Sokak No:7 Samsun/Kavak",Price=8999,UrunName="Monster Abra A5 V15.8.4 Intel Core i7 10750H 16GB 500GB SSD GTX1650Ti Freedos 15.6'' FHD Taşınabilir Bilgisayar",UrunImage="laptop1.jpg",kargoyaverildimi=false,odendimi=false,DateTime=new DateTime(2021, 4, 15, 0, 0, 0)},
                new Cart(){UserId="57d23011-84d0-481d-b548-0d1668617917", UrunId=3,UserName="seydiahmetdemir",Tel="11111111111",Address="adres adres adres adres adres adres ",Price=1234,UrunName="Toshiba Camileo H20 Video Kamera",UrunImage="kamera3.jpg",kargoyaverildimi=false,odendimi=false,DateTime=new DateTime(2021, 3, 9, 0, 0, 0)},
            };

            foreach (var item in sepetler)
            {
                context.Carts.Add(item);
            }
            context.SaveChanges();





            var yorumlar = new List<Yorum>()//Category tipinde kategoriler adında bir liste oluşturduk
            {
                new Yorum(){UserName="seydiahmetdemir",ProductId=1,UrunPuan=5,Yorumlar="Bence ürün çok kaliteli almayan pişman olur.",Tarih=new DateTime(2020, 8, 30, 0, 0, 0)},
                new Yorum(){UserName="seydiahmetdemir",ProductId=2,UrunPuan=3,Yorumlar="İdare eder. Keşke almadan önce araştırıp daha iyisini bulsaydım.",Tarih=new DateTime(2020, 6, 30, 0, 0, 0)},
                new Yorum(){UserName="ramazandemir",ProductId=3,UrunPuan=1,Yorumlar="Ürün çok kötü. 1 haftada bozuldu. Ömrü çok kısa. Beğenmedim.",Tarih=new DateTime(2020, 7, 30, 0, 0, 0)},
            };

            foreach (var item in yorumlar)
            {
                context.Yorums.Add(item);
            }
            context.SaveChanges();





            base.Seed(context);
        }
    }
}