

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        //CarTest();
        DtoTest();
    }

    private static void DtoTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetails();
        if (result.Success==true)
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
        foreach (var item in carManager.GetAll().Data)
        {
            Console.WriteLine("Car ID : " + item.CarID + " Car name : " + item.CarName + " Brand ID : " + item.BrandID + " Color ID : " + item.ColorID + " Daily Price : " + item.DailyPrice + " ModelYear : " + item.ModelYear + " Description : " + item.Description);

        }
    }
}