using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car {CarId = 1, BrandId = 1, ColorId = 1, Description = "TOFAŞ", ModelYear = new DateTime(2002,12,12)},
                new Car {CarId = 2, BrandId = 2, ColorId = 2, Description = "BMW", ModelYear = new DateTime(2012,12,12)},
                new Car {CarId = 3, BrandId = 1, ColorId = 2, Description = "TOFAŞ", ModelYear = new DateTime(2014,12,12)},
                new Car {CarId = 4, BrandId = 3, ColorId = 3, Description = "MERCEDES", ModelYear = new DateTime(2022,12,12)},
                new Car {CarId = 5, BrandId = 3, ColorId = 5, Description = "MERCEDES", ModelYear = new DateTime(2021,12,12)},
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //1. kullanım
            //Car carToDeleted= null;
            //foreach (var item in _car)
            //{
            //    if (item.CarId == car.CarId)
            //    {
            //        carToDeleted = item;
            //    }
            //}
            //_car.Remove(carToDeleted);
            //linq kullanımı
            Car carToDeleted = _car.SingleOrDefault(p => p.CarId == car.CarId);
            _car.Remove(carToDeleted);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p=>p.CarId == car.CarId);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
           
        }
    }
}
