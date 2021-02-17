using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    
        class Program
        {
            static void Main(string[] args)
            {

            // CarTest();
            //BrandTest();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now }).Message);

             

        }

            private static void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            private static void CarTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName);
                }
            }
        }
}
