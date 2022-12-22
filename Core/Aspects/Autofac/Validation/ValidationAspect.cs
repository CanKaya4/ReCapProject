using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    //
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        //Attribute'a bir validatorType ver diyor parametre de
        //Attribute'lara tipleri type keywordü ile atıyoruz.
        public ValidationAspect(Type validatorType)
        {
            //Gönderilen validatorType bir Ivalidator type değilse
            //IValidator : CarValidator'da FluentValidator paketinden gelen AbstractValidator'ın referansını tutan bir interface'idi
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        //MethodInterception içerisinde onbefore metodu vardı ancak içi boştu, o memtotu burada ovverride ederek dolduruyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection : Çalışma anında birşeyleri çalıştırabilmenizi sağlar.
            //Örneğin bir classı newliyoruz ama reflection ile newleme çalışma anında çalışıyor.
            //ProductValidator'un bir instance'sini oluştur çalışma anında demek.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ProductValidator'un çalışma tipini bul
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //invacation metot demek.ProductValidator'un parametrelerini bul, Parametlerini bul demek, örnek olarak add metodunda Car car parametresi var
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                //validationTool'u kullanarak validate et.
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
