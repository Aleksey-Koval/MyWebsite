using MyWebsite.Models.BusinesLogic.Interfaces;
using MyWebsite.Models.BusinesLogic.Services;
using Ninject.Modules;

namespace MyWebsite.Util
{
    public class BookModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookService>();
        }
    }
}