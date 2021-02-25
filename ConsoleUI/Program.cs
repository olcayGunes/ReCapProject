using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());

			Console.WriteLine("GetAll ile Listeleme");
			var result = carManager.GetAll();
			foreach (var car in result.Data)
			{
				Console.WriteLine(car.Name+"	"+car.DailyPrice);
			}
			Console.WriteLine("*******************************************************");

			Console.WriteLine("********** GetByBrandId ile Listeleme **********");
			var result2 = carManager.GetCarByBrandId(1);
			foreach (var car in result2.Data)
			{
				Console.WriteLine(car.BrandId+"	"+car.Name);
			}
			Console.WriteLine("*******************************************************");


			// Tablolar join edilerek araç bilgileri listeleme
			var result3 = carManager.GetCarDetails();
			foreach (var car in result3.Data)
			{
				
				Console.WriteLine("Name:"+car.CarName);
				Console.WriteLine("Brand Name:" + car.BrandName);
				Console.WriteLine("Color:" + car.ColorName);
				Console.WriteLine("Daily Price:" + car.DailyPrice);
				Console.WriteLine("------------------------------------");
			}
		}
	}
}
