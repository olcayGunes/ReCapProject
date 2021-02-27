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
	public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
	{
		public List<CustomerDetailDto> GetCustomerDetails()
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from u in context.Users
							 join c in context.Customers
							 on u.Id equals c.UserId
							 select new CustomerDetailDto { Id = u.Id, CustomerName = u.FirstName, CustomerLastName = u.LastName, CustomerCompanyName = c.CompanyName, CustomerEMail = u.EMail };
				return result.ToList();
			}
		}
	}
}
