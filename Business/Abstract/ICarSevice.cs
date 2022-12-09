using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarSevice
    {
        List<Car> GetAll();
        void Add(Car car);
        List<Car> GetCarsByColorId(int id);
        List<Car> GetCarsByBrandId(int id);
    }
}
