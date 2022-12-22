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
 * 
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