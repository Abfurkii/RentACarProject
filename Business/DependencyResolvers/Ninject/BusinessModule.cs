using Business.Abstract;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarManager>().InSingletonScope();
            Bind<ICarDal>().To<EfCarDal>().InSingletonScope();
            Bind<IRentService>().To<RentManager>();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IRentalService>().To<RentalManager>().InSingletonScope();
            Bind<IRentalDal>().To<EfRentalDal>().InSingletonScope();
        }
    }
}
