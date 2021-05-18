using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EticaretMVC.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Roller v
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() {Name="admin", Description="admin rolü"};

                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" }; ;

                manager.Create(role);
            }
            //userlar
            if (!context.Roles.Any(i => i.Name == "seydiahmetdemir"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "seydiahmet", Surname = "demir", UserName = "seydiahmetdemir", Email="seydiahmetdemir@gmail.com"};

                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Roles.Any(i => i.Name == "ramazandemir"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "ramazan", Surname = "demir", UserName = "ramazandemir", Email = "ramazandemir@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
                
            }

            if (!context.Roles.Any(i => i.Name == "mertdemir"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "mert", Surname = "demir", UserName = "mertdemir", Email = "mertdemir@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");

            }

            base.Seed(context);
        }
    }
}