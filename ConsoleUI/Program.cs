

using Business.Concrete;
using DataAccess.Concrete.InMemory;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());
        foreach (var item in carManager.GetAll())
        {
            Console.WriteLine(item.Description);
        }
    }
}