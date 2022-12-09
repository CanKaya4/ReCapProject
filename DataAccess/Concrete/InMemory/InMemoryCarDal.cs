using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Car {CarID = 1, BrandID = 1, ColorID = 1, Description = "TOFAŞ"},
                new Car {CarID = 2, BrandID = 2, ColorID = 2, Description = "BMW",},
                new Car {CarID = 3, BrandID = 1, ColorID = 2, Description = "TOFAŞ"},
                new Car {CarID = 4, BrandID = 3, ColorID = 3, Description = "MERCEDES"},
                new Car {CarID = 5, BrandID = 3, ColorID = 5, Description = "MERCEDES"},
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
            Car carToDeleted = _car.SingleOrDefault(p => p.CarID == car.CarID);
            _car.Remove(carToDeleted);
        }

        public Car Get(Expression<Func<Car, bool>> fiter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.CarID == car.CarID);
            
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;

        }

        List<CarDetailsDto> ICarDal.GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
