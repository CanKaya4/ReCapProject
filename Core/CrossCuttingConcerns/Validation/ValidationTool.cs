using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    //Bu tip tool'lar yani araçlar genellikle static olarak yapılır.
    //Tek bir instance oluşturulu ve hep o kullanılır. Boşu boşuna her seferinde bellekte Tool nesnei oluşturulmaz.
    //Static bir sınıfın metotları da static olmak zorundadır.
    public static class ValidationTool
    {
        //IValidator FluentValidator paketinden geliyor.
        //Ben buraya Entity,Dto vbs gibi her şeyi ekleyebilirim.O yüzden object diyorum. Hepsinin basesi objecttir.
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            //IValidator bir interface' yani benim CarVallidator classımı newlememe gerek yok. O yüzden o satırı commentledim.
            //CarValidator carValidator = new CarValidator();
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
