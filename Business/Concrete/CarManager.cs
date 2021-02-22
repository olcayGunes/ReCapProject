using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public void Add(Car car)
		{
			if (car.Name.Length>=2 && car.DailyPrice>0)
			{
				_carDal.Add(car);
				Console.WriteLine("Araç Veritabanına Eklenmiştir.");
			}
			else
			{
				Console.WriteLine("Eklemek İstediğiniz Aracın Bilgileri Kayıt İçin Yeterli Değildir. Lütfen Düzeltip Tekrar Deneyiniz.");
			}
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public List<Car> GetCarByBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id);
		}

		public List<Car> GetCarByColorId(int id )
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			return _carDal.GetCarDetails();
		}
	}
}
