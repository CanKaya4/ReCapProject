using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            #region Spagetti kod
            //Bu en spagetti kod yönetimi, refoctor edilecek.
            //CarValidator içerisinde oluşturduğum Validation kurallarını buraya ekleyeceğim.
            //ValidationContext bir doğrula contexti, Car Türü için generic olarak oluştur. car'ı da Add metorundan gelen car olarak veriyoruz.
            //Yani Car için doğrulama yapacağım. çalışacağım tipte parametreden gelen car nesnesi.

            //var context =new  ValidationContext<Car>(car);

            //Oluşturduğum ProductValidator sınıfınındaki kuralları kullanabilmmek için burada newliyorum

            //CarValidator carValidator = new CarValidator();

            //Şimdi ise bir kural çalışıtıyorum. CarValidator'u validate et diyoruz ve burada bizden bir context istiyor. 
            //Contexi'de 2 satır üstte oluşturduğum contexti veriyorum.

            //var result = carValidator.Validate(context);

            //result eğer IsValid değilse yani geçersiz ise hata döndür.

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors); 
            //}


            //Test edildi çalışıyor ancak refactor edilmemsi gerekmekte.


            #endregion

            #region Tool
            //Spagetti kodu sürekli yazmak zahmetli ve bütün projelerimde kullanabileceğim bir tool haline getireceğim.
            //Bütün projelerimde yapacağım bir yapı yapacağımmız zaman bunu Core katmanında yaparız.
            //Yeni bir kavram.
            //Cross Cutting Concerns : Uygulamayı dikine kesen ilgi alanları.
            //Loglama, Loglamayı farklı katmanlarda da kullanabiliriz. Örnek olarak Arayüz logu veya DataAccess logu gibi.
            //Loglama her yerde kullanılabilir. Bu yaptığımız doğrulamanın arayüz versiyonu da var mesela. Bunlara Cross cutting Concenrs deniyor.
            //Cross Cutting Concerns : Nelerdir bunlar ? Log,Cache, Transaction, Authorization gibi bunlara Katmanlı mimarilerde Cross Cutting Concerns deniyor.
            //Validation da bir cross cutting concern olduğuna göre ve tüm katmanlarda işimize yarayabileceğine göre, Core katmanında ele alacağız.
            //Core katmanına CrossCuttingConcerns klasörü açıyoruz. 
            //Loglama,cash veya validation gibi yapılarımız olduğu için klasörlendiriyoruz. 
            //Validation klasörü açıyoruz.
            //Bunu bir tool haline getirip yazacağımmız kod aslında şu 
            //ValidationTool.Validate(new CarValidator(),car)
            //CarValidator ve car değişiyor sadece geri kalan bütün kodlar aynı.
            //carvalidator yerine brandvalidator veya car yerine brand gelebilir örnek olarak. Değişen yer sadece bu CarValidator ve car nesneleri.
            //Validation klasörüme ValidationTool isminde bir class açıyorum. Notların devamı ValidationTool classımmda.

            //ValidationTool isimli static bir class oluşturdum. Static olduğu için newlemeye gerek yok.
            //Class içerisine de Validate isimli bir metod oluşturdum. Spagetti kodu orada refactor ettim.
           // ValidationTool.Validate(new CarValidator(), car);
            //Test edildi çalışıyor.
            //Burada Business kodlarım olucak şimdi ise ben Validation kodlarımı Attribute olarak vermek isrityorum.
            //Yani Add metodumun üstne [Validate] eklediğimde bu validate gidip otmaatik olarak add metodumun paratmetresini okuyacak
            //İlgili validator'u ve car nesnesini bulup validate edicek. Böyle bir yapı kuracağım.
            #endregion
            #region Attribute
            /*Standart kodlar olduğu için EnginDemiroğ githundan alacağız.
             * https://github.com/engindemirog/NetCoreBackend kodları buradan alıyoruz.
             * 
             */
            #endregion


            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorID == id), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }
    }
}
