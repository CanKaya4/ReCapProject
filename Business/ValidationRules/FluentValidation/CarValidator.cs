using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        //Car nesnelerimiz için doğrulama kuralları yazacağız.
        //Doğrulamma kuralları contrucator içerisine yazılır.
        //Rulefor : Kim için kural ?
        //Rulefor içerisine yazacağımız, AbstractValidator içerisinde ne varsa ona karışılık gelir. Burada Car var, yazacağımız kodlar car entitysine karşılık
        //gelecek
        public CarValidator()
        {
            //Rulefor kodlarını bitişik bir şekilde de yazabiliriz. Ancak bu SOLID'in S harfine uymuyor.
            //CarName boş geçilemez.
            RuleFor(c => c.CarName).NotEmpty();
            //CarName'e minumumm 2 karkter içermelidir.
            RuleFor(c => c.CarName).MinimumLength(2);
            //CarDailyprice boş olamaz.
            RuleFor(c => c.DailyPrice).NotEmpty();
            //CarDailtprice 0'dan büyük olmaldır.
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            //BrandId'si 1 olan araçların fiyatları 10'dan büyük olmalıdır.
            RuleFor(c => c.DailyPrice).GreaterThan(10).When(c => c.BrandID == 1);

            //Hazır Validation kodları ile çalıştığımız gibi kendi validation kuralımızı da yazabiliriz.
            //Kendi kuralımızı yazmak için Must özelliğini kullanıyoruz. Kendi oluşturacağım kural : Yeni eklenen car nesensinin CarName'i A ile başlamalı kuralı.
            //StartWithA ise benim oluşturduğum bir metod ismi.Türkçesi A ile başilamalı demek. Anlamlı olması açısından verdim.
            //StartWithA'nın üstüne gelip ctrl+. ile açılan pencere Generate Method diyerek metoda dönüştürelim. Özellikle bir hata mesajı vermek istersek .WithMessage kullanılır.
            RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Yeni eklenen arabanar A harfi ile başlamalıdır.");

            //Şimdi ise bu kuralları çalıştırmaya geçelim.
            //CarManager'a gidiyorum.

        }
        //Oluşturduğumuz metod burada.
        //bool olarak oluşturuluyor. Eğer true dönerse kurala uygun, false dönerse kurala uygun değil anlamında.
        //String arg : Üstte kuralımız yazarken CarName gönderiyoruz, arg'da carname'i ifade ediyor.
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");

        }
    }
}
