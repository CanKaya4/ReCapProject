

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine("Car ID : " +item.CarID + " Brand ID : " + item.BrandID + " Color ID : " + item.ColorID + " Daily Price : " + item.DailyPrice + " ModelYear : " + item.ModelYear + " Description : " + item.Description);
         
        }
    }
}