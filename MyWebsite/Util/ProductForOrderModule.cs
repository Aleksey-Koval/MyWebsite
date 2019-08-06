using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class ProductForOrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductForOrderService>().To<ProductForOrderService>();
        }
    }
}