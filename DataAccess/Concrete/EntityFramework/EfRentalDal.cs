using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails()
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from r in context.Rentals
							 join ca in context.Cars
							 on r.CarId equals ca.Id
							 join cu in context.Customers
							 on r.CustomerId equals cu.Id
							 join u in context.Users
							 on cu.UserId equals u.Id
							 select new RentalDetailDto { Id = r.Id, CarName = ca.Name, CustomerName = u.FirstName, CustomerLastName = u.LastName, CustomerCompanyName = cu.CompanyName, CustomerEMail = u.EMail, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
				return result.ToList();

			}
		}
	}
}