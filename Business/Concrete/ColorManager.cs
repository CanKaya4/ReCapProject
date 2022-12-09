using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorService _colorService;
        public ColorManager(IColorService colorService)
        {
            _colorService = colorService;
        }

        public void Add(Brand brand)
        {
           _colorService.Add(brand);
       }

        public void Delete(Brand brand)
        {
            _colorService.Delete(brand);
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _colorService.GetAll(filter);
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            return _colorService.GetById(filter);
        }

        public void Update(Brand brand)
        {
           _colorService.Update(brand);
        }
    }
}
