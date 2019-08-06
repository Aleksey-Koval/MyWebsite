using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class TvModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITvService>().To<TvService>();
        }
    }
}