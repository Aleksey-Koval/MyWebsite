using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class PhoneModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneService>().To<PhoneService>();
        }
    }
}