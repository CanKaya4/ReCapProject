/*
 * FluentValidation yapacağız.
Business kodları ayrı validation(doğrulama) kodları ayrı yazılır.

Validation : Add metodunda eklemeye çalıştığımız nesneyi iş kurallarına dahil etmek için bu nesnenin yapısal olarak uygun olup olmadığını kontrol etmeye validation(doğrulama) deniyor.
Validation'a örnek olarak, Bir sisteme kayıt olamaya çalışırken, kullanıcı adı min 2 karakter veya şifre max 15  karakter vs gibi kurallar  yani verinin yapısal durumu ile alakalı olan her şeye validation denir.

Business Code : İş gereksinimlerimize, iş ihtiyaçlarımıza uygunluktur.
Örneğin, Ehliyet alacak birine ehliyet verip vermemek için yaptığuınız kontrol Business COde'dur. İlk yardımdan 70 almısmı ? direksiyondan 80 almıs mı gibi

Validation kurallarımı ProductManager içerisine değil de merkezi bir yere yazıyoruz. Bu işlemi FluentValidation ile yapacağız.
Herşeyi klasörlediğimiz gibi fluentvalidationu da klasörleyeceğiz.
Business içerisinde ValidationRules klasörü açıyoruz. Bu bizim doğrulama kuralları için kullanacağımız validationları içerecek.
Kullacağımız paket/teknoloji ise fluentvalidation olduğu için ValidationRules altına bir de FluentValidation klasörü açıyoruz.
Business üzerined manage nuget packages diyerek fluentvalidation paketini projemize ekleyeceğiz.
Ekletikten sonra FluentValidation klasörü altında oluşturacağımız classları çalışacağımız dosya ile ilişiki isimlendiriyoruz.
Örneğin CarValidator veya ColorValidator gibi. CarValidator classı açıyoruz. Bu classın içerisinde CarName gibi Car için verilen propertylere ayar vereceğiz.
AbstractValidator sınıfından inherit etmemiz gerekiyor, FluentValidaton classlarımızı. AbstractValidator, kurduğumuz FluentValidation paketinden geliyor.
AbstractValidator'a hangi nesne ile çalışıyorsak onu vermemmiz lazım. Örneğin CarValidator için AbstractValidator<Car> gibi.
AOP : Örneğin metotlarınızı loglamak istiyorsunuz. Bir metot ya başında, sonunda veya hata verdiğinde loglanır. Uygulamanın başında sonunda veya hata verdiğinde çalışmasını istediğin kodların varsa
Onları AOP yöntemi ile dizayn edebiliriz. Dolayısıyla uygulamanın belli yerleride sürekli try catch yapısı kalmak zorunda kalmayız veya her yerde loglama kodlarını yazmak zorunda kalmayız.
Bu yönteme Interceptor deniyor. Interceptor kelime anlamı araya girmek demektir, metodun başında sonunda veya hata verdiğinde gibi.
Validation(Doğrulama),log,cache gibi yapıları, metotların üstüne Attribute olark ekleriz.
Attribute : Propertylere, metotlara, classlara vs anlam yüklemek için kullanılan yapılardır.
Projemize Core katmanı içerisine Utilities içerisine Interceptors klasörü ekleyeceğiz. Açıklama notları Interceptor içerisinde


Core katmanı içerisine Aspects isimli klasör ekle, altına da hangi teknloji kullnarak aspect yazılacaksa onu klasörle, Autofac ile yazağım için Autofac klasörü açıyorum.
Autofac içerisinde şuan Validation yazacağımız için Validation klasörü ekle
 * 
 * 
 * 
 */

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        //CustomerTest();
        //CarTest();
        //DtoTest();
    }

    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        var result = customerManager.GetAll();
        if (result.Success == true)
        {
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CompanyName + " " + item.Id);
            }
        }
        {

        }
    }

    private static void DtoTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetails();
        if (result.Success == true)
        {
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName + " / " + item.BrandName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetAll();

        if (result.Success == true)
        {
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

    }
}