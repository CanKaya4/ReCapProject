

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