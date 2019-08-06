using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class ShoppingCartModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IShoppingCartServices>().To<ShoppingCartServices>();
        }
    }
}