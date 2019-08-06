using MyWebsite.Models;
using MyWebsite.Models.BusinesLogic.Infrastructure;
using MyWebsite.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            NinjectModule orderModule = new OrderModule();
            NinjectModule shoppingCartModule = new ShoppingCartModule();
            NinjectModule productForOrderModule = new ProductForOrderModule();
            NinjectModule phoneModule = new PhoneModule();
            NinjectModule bookModule = new BookModule();
            NinjectModule tvModule = new TvModule();
            NinjectModule headphonesModule = new HeadphonesModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(orderModule, shoppingCartModule, productForOrderModule,
                phoneModule, bookModule, tvModule, headphonesModule, serviceModule);

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
