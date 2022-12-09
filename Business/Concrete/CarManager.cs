using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarSevice
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public void Add(Car car)
        {
            if (car.Description.Length >2 && car.DailyPrice >0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Bilgileri kontrol ediniz.");
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorID == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
           return _carDal.GetAll(c=>c.BrandID == id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
