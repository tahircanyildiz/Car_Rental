

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
BrandManager brandManager = new BrandManager(new EfBrandDal());
ColorManager colorManager = new ColorManager(new EfColorDal());
CustomerManager customerManager=new CustomerManager(new EfCustomerDal());
RentalManager rentalManager=new RentalManager(new EfRentalDal());


foreach (var customer in customerManager.GetAll().Data)
{
    Console.WriteLine(customer.FirstName+" "+customer.LastName);
}
Customer customer1 = new Customer() {  Id=5,FirstName = "Berkay", LastName = "Karatas", Email = "berkay@gmail.com", Password = "12345", CompanyName = "Berkay Ticaret" };
customerManager.Add(customer1);

Console.WriteLine("\n --------------------------------");
foreach (var customer in customerManager.GetAll().Data)
{
    Console.WriteLine(customer.FirstName + " " + customer.LastName);
}
static void CarDetailList(CarManager carManager)
{
    foreach (var car in carManager.GetCarDetailDtos().Data)
    {
        Console.WriteLine("Marka : " + car.BrandName + " " + car.Model);
        Console.WriteLine("Renk : " + car.ColorName);
        Console.WriteLine("Günlük Fiyat : " + car.DailyPrice);
        Console.WriteLine("Açıklama : " + car.Description + "\n");

    }
}