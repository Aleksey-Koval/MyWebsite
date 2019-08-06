using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MyWebsite.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            var role3 = new IdentityRole { Name = "manager" };
            var role4 = new IdentityRole { Name = "deliveryManager" };


            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);


            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            string password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);

            var user = new ApplicationUser { Email = "user@mail.ru", UserName = "user@mail.ru" };
            string password2 = "ad46D_ewr3";
            var result2 = userManager.Create(user, password2);

            var manager = new ApplicationUser { Email = "manager@mail.ru", UserName = "manager@mail.ru" };
            string password3 = "ad46D_ewr3";
            var result3 = userManager.Create(manager, password3);

            var deliveryManager = new ApplicationUser { Email = "deliveryManager@mail.ru", UserName = "deliveryManager@mail.ru" };
            string password4 = "ad46D_ewr3";
            var result4 = userManager.Create(deliveryManager, password4);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            if (result2.Succeeded)
            {
                userManager.AddToRole(user.Id, role2.Name);
            }
            if (result3.Succeeded)
            {
                userManager.AddToRole(manager.Id, role3.Name);
            }

            if (result3.Succeeded)
            {
                userManager.AddToRole(deliveryManager.Id, role4.Name);
            }

            base.Seed(context);
        }

    }
}