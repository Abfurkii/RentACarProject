using Business.Abstract;
using Business.Concrete.Managers;
using Business.DependencyResolvers.Ninject;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleRentCarUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = InstanceFactory.GetInstance<ICarService>();
            IRentService rentService = InstanceFactory.GetInstance<IRentService>();

            ICustomerService customerService = InstanceFactory.GetInstance<ICustomerService>();
            IRentalService rentalService = InstanceFactory.GetInstance<IRentalService>();

            var cars = carService.GetCarDetailsWithIdsDtos();

            Console.WriteLine();
            Console.WriteLine("  Kayıtlı araçlar");
            Console.WriteLine();
            foreach (var car in cars.Data)
            {
                Console.WriteLine("Arabanın Id'si: {0}", car.Id);
                Console.WriteLine("Arabanın markası ve marka Id'si: {0} / {1} ", car.BrandName, car.BrandId);
                Console.WriteLine("Arabanın rengi ve renk Id'si: {0} / {1}", car.ColorName, car.ColorId);
                Console.WriteLine("Arabanın günlük fiyatı: {0}", car.DailyPrice);
                Console.WriteLine();
            }
            Console.WriteLine("\n-----------------------------\n");

            var customers = customerService.GetCustomerDetailDtos();

            Console.WriteLine();
            Console.WriteLine("  Müşteri bilgileri");
            Console.WriteLine();
            foreach (var customer in customers.Data)
            {
                Console.WriteLine("Müşteri Id'si: {0}", customer.Id);
                Console.WriteLine("Müşterinin adı soyadı: {0} {1} ", customer.FirstName, customer.LastName);
                Console.WriteLine("Müşterinin şirketi: {0}", customer.CompanyName);
                Console.WriteLine();
            }
            Console.WriteLine("\n-----------------------------\n");

            Console.WriteLine("Araba kiralamak için enter'a basın.");
            Console.ReadLine();
            Console.Title = "RentMyCar 7";
            Console.WriteLine("Lütfen kiralama bilgilerini giriniz: ");
            Console.Write("Arabanın Id'si: ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Müşteri Id'si: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Kiralama tarihi: \nYıl: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ay: ");
            int mounth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gün: ");
            int day = Convert.ToInt32(Console.ReadLine());
            var dateTime = new DateTime(year, mounth, day);

            Console.Write("Kiralama bitiş tarihi: \nYıl: ");
            int returnYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ay: ");
            int returnMounth = Convert.ToInt32(Console.ReadLine());
            Console.Write("Gün: ");
            int returnDay = Convert.ToInt32(Console.ReadLine());
            var returnDateTime = new DateTime(year, mounth, day);

            var result = rentalService.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = dateTime,
                ReturnDate = returnDateTime
            });

            Console.Clear();
            Console.WriteLine(result.Message);
        }
    }
}
