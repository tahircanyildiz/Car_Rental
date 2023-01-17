

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
ColorManager colorManager = new ColorManager(new EfColorDal());

//AracListele(carManager);

//CarByIdList(carManager);

//CarByColorId(carManager);

//AddCar(carManager);

//UpdateCar(carManager);

//AddColor(colorManager);

static void AracListele(CarManager carManager)
{
    Console.WriteLine("********** Araç Listeleme **********");
    foreach (var car in carManager.GetCarDetailDtos())
    {
        Console.WriteLine("Marka : " + car.BrandName + " " + car.Model);
        Console.WriteLine("Renk : " + car.ColorName);
        Console.WriteLine("Günlük Fiyat : " + car.DailyPrice);
        Console.WriteLine("Açıklama : " + car.Description + "\n");

    }
}
static void CarByIdList(CarManager carManager)
{
    Console.WriteLine("********** Marka ID'sine Göre Araç Listeleme **********");
    foreach (var car in carManager.GetCarsByBrandId(1))
    {
        Console.WriteLine(car.Model);
    }
}
static void CarByColorId(CarManager carManager)
{
    Console.WriteLine("********** Renk ID'sine Göre Araç Listeleme **********");
    foreach (var car in carManager.GetCarsByColorId(2))
    {
        Console.WriteLine(car.Description);
    }
}
static void AddCar(CarManager carManager)
{
    Console.WriteLine("********** Araç Ekleme **********");
    carManager.Add(new Car
    {
        CarId = 11,
        BrandId = 10,
        ColorId = 2,
        ModelYear = 2019,
        Model = "208",
        DailyPrice = 550,
        Description = "Dizel"
    });
}
static void UpdateCar(CarManager carManager)
{
    Console.WriteLine("********** Araç Güncelle **********");
    carManager.Update(new Car { CarId = 1, BrandId = 1, ColorId = 1002, ModelYear = 2020, DailyPrice = 1200, Description = "M5", Model = "BMW" });
}
static void AddColor(ColorManager colorManager)
{
    Console.WriteLine("********** Renk Ekleme **********");
    colorManager.Add(new Color { ColorId = 11, ColorName = "Pembe" });
}