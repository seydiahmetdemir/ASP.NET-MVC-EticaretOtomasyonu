using EticaretMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EticaretMVC.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Yorum> Yorums { get; set; }

    }
}