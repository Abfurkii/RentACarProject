using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class RentManager : IRentService
    {
        public void RentACar(Car car)
        {
            if (car == null)
            {
                throw new Exception("Bu Id'ye sahip araç bulunamadı!");
            }
            Console.WriteLine("{0} {1} {2} {3} {4} {5} \nBilgilerine sahip araç kiralandı!", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description, car.ModelYear);
        }
    }
}
