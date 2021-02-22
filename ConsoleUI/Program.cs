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
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Name+"	"+car.DailyPrice);
			}
			Console.WriteLine("*******************************************************");

			Console.WriteLine("********** GetByBrandId ile Listeleme **********");
			foreach (var car in carManager.GetCarByBrandId(1))
			{
				Console.WriteLine(car.BrandId+"	"+car.Name);
			}
			Console.WriteLine("*******************************************************");


			// Tablolar join edilerek araç bilgileri listeleme
			foreach (var car in carManager.GetCarDetails())
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
