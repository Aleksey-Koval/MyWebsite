using MyWebsite.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext("DefaultConnection"))
            {
                return View(db.Users.Include("ShoppingCart").ToList());
            }
        }

        [Authorize(Roles = "manager")]
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}