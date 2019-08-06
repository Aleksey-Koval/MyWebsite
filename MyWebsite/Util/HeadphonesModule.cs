using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class HeadphonesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHeadphonesService>().To<HeadphonesService>();
        }
    }
}