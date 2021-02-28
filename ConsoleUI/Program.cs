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
			//CarManagerTest();
			//CustomerManagerTest();
			RentalManagerTest();
		}

		private static void RentalManagerTest()
		{
			RentalManager rentalManager = new RentalManager(new EfRentalDal());
			rentalManager.Add(new Rental { CustomerId = 1, CarId = 3, RentDate = new DateTime(2021, 01, 15), ReturnDate = DateTime.Now });
			rentalManager.Add(new Rental { CustomerId = 2, CarId = 1, RentDate = new DateTime(2021, 01, 17), ReturnDate = DateTime.Now });
			rentalManager.Add(new Rental { CustomerId = 2, CarId = 5, RentDate = new DateTime(2021, 01, 16), ReturnDate = DateTime.Now });
			Console.WriteLine("********** KİRALAMA DETAYLARI LİSTELEME **********");
			var result = rentalManager.GetRentalDetails();
			foreach (var rentalDetails in result.Data)
			{
				Console.WriteLine(rentalDetails.Id + " " + rentalDetails.CustomerName + " " + rentalDetails.CustomerLastName + " " + rentalDetails.CustomerEMail + " " + rentalDetails.CustomerCompanyName + " " + rentalDetails.CarName);
				Console.WriteLine("----------------------------------------------------------------------------------------");
			}
			Console.WriteLine("********** TÜMÜNÜ LİSTELEME **********");
			var result2 = rentalManager.GetAll();
			foreach (var rental in result2.Data)
			{
				Console.WriteLine(rental.RentDate + " " + rental.ReturnDate + " " + rental.CarId);
				Console.WriteLine("----------------------------------------------------------------------------------------");

			}
		}

		private static void CustomerManagerTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			customerManager.Add(new Customer { Id = 1, UserId = 1, CompanyName = "Kardeşler Kundura" });
			customerManager.Add(new Customer { Id = 2, UserId = 2, CompanyName = "Hakan Plastik" });
			var result = customerManager.GetAll();
			foreach (var customer in result.Data)
			{
				Console.WriteLine(customer.Id + " " + customer.CompanyName);
			}
		}

		private static void CarManagerTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			/*
			Console.WriteLine("GetAll ile Listeleme");
			var result = carManager.GetAll();
			foreach (var car in result.Data)
			{
				Console.WriteLine(car.Name + "	" + car.DailyPrice);
			}
			Console.WriteLine("*******************************************************");

			Console.WriteLine("********** GetByBrandId ile Listeleme **********");
			var result2 = carManager.GetCarByBrandId(1);
			foreach (var car in result2.Data)
			{
				Console.WriteLine(car.BrandId + "	" + car.Name);
			}
			Console.WriteLine("*******************************************************");
			
			*/
			// Tablolar join edilerek araç bilgileri listeleme
			var result3 = carManager.GetCarDetails();
			foreach (var car in result3.Data)
			{

				Console.WriteLine("Name:" + car.CarName);
				Console.WriteLine("Brand Name:" + car.BrandName);
				Console.WriteLine("Color:" + car.ColorName);
				Console.WriteLine("Daily Price:" + car.DailyPrice);
				Console.WriteLine("Model Year:" + car.ModelYear);
				Console.WriteLine("------------------------------------");
			}
		}
	}
}
