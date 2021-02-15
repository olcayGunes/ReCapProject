using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new InMemoryCarDal());

			InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();

			inMemoryCarDal.Add(new Car() { Id = 5, BrandId = 3, ColorId = 1, DailyPrice = 500, ModelYear = 2021, Description = "Lux Class" });
			inMemoryCarDal.Add(new Car() { Id = 6, BrandId = 2, ColorId = 2, DailyPrice = 300, ModelYear = 2020, Description = "High Class" });

			var resultGetById=inMemoryCarDal.GetById(6);
			foreach (var result in resultGetById)
			{
				Console.WriteLine(result.BrandId + " " + result.Description);
			}

			Console.WriteLine("---------------------------");

			var resultGetAll=inMemoryCarDal.GetAll();
			foreach (var result in resultGetAll)
			{
				Console.WriteLine(result.BrandId+" "+result.Description);
			}
		}
	}
}
