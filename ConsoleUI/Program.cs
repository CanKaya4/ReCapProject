

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
        foreach (var item in carManager.GetCarDetails())
        {
            Console.WriteLine(item.CarName + " / " + item.BrandName);
        }
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine("Car ID : " + item.CarID + " Car name : " + item.CarName + " Brand ID : " + item.BrandID + " Color ID : " + item.ColorID + " Daily Price : " + item.DailyPrice + " ModelYear : " + item.ModelYear + " Description : " + item.Description);

        }
    }
}