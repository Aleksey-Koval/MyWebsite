using MyWebsite.Models.Interfaces;
using MyWebsite.Models.Repositories;
using Ninject.Modules;

namespace MyWebsite.Models.BusinesLogic.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}