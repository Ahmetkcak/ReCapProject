using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //CarDetailtTest();

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + "/" + car.ColorName + "/" + car.CarName);
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

            Car newCar = new Car() { Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 300000, ModelYear = 2009, Description = "Güzel" };
            carManager.Add(newCar);

            var result1 = carManager.GetAll();

            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.Id);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());


            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName + " - " + color.ColorId);
            }
            //colorManager.Delete(new Color() { ColorId = 1, ColorName = "Beyaz" });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName + " - " + color.ColorId);
            }
        }
        private static void CarDetailtTest()
        {
            CarManager carmanager = new CarManager(new EfCarDal());

            var result = carmanager.GetCarDetails();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " - " + car.ColorName + " - " + car.BrandName + " - " + car.DailyPrice);
            }
        }
        
    }
}
