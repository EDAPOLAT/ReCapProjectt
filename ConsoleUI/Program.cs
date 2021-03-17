using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    
        class Program
        {
            static void Main(string[] args)
        {
            // UserTest(); 
            // CarTest();
            //BrandTest(); 
            //CustomerTest();
           // RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 2, CustomerId =1, RentDate = DateTime.Now ,ReturnDate=new DateTime(2021,3,1 )});
            Console.WriteLine(rentalManager.GetAll().Data);
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 2, CompanyName = "bilsoft" });
            Console.WriteLine(customerManager.GetAll().Success);
        }

        //private static void UserTest()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User { FirstName = "EDA", LastName = "POLAT", Email = "edaaypolat@gmail.com", Password = "XYZ" });
        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.FirstName + "" + user.LastName);
        //    }
        //}

        private static void BrandTest()
            {
                BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Yeşil" });
                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }

            private static void CarTest()
            {
                CarManager carManager = new CarManager(new EfCarDal());  
                carManager.Add(new Car
                {
                        BrandId = 6,
                        ColorId = 4,
                        CarName = "KIA",
                        DailyPrice = 800,
                        ModelYear = "2021",
                        Description = "Otomatik vites"

            });
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
