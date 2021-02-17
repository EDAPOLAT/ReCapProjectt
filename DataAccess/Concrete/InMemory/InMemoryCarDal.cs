using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal :ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{  CarId=1, CarName="BMW",BrandId=1,ColorId=1,ModelYear="1994",DailyPrice=1000000, Description="Manüel vites" },
            new Car{  CarId=2, CarName="RENAULT",BrandId=2,ColorId=2,ModelYear="2000",DailyPrice=500000, Description="Otomatik vites" },
            new Car{  CarId=3,CarName="PEUGEOT",BrandId=3,ColorId=3,ModelYear="1987",DailyPrice=3000000, Description="Manüel vites" },
            new Car{  CarId=4,CarName="VOLKSWAGEN",BrandId=4,ColorId=4,ModelYear="2021",DailyPrice=2500000, Description="Otomatik vites " },
            new Car{  CarId=5,CarName="CHEVROLET",BrandId=5,ColorId=5,ModelYear="2021",DailyPrice=6000000, Description="Otomatik vites" },


            };
        }

        public void Add(Car car)
        { if(car.CarName.Length>=2 && car.DailyPrice>0) { 
            _cars.Add(car);
            }
        }

        public void Delete(Car car)
        {

            Car carToDelete = null;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c. CarId ==  Id).ToList();
        }

       



        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
    }





 
 
