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
	public class EfUserDal : EfEntityRepositoryBase<User, CarRentalContext>, IUserDal
	{
		public List<UserDetailDto> GetUserDetails()
		{
			using (CarRentalContext context = new CarRentalContext())
			{
				var result = from u in context.Users
							 join c in context.Customers
							 on u.Id equals c.UserId
							 select new UserDetailDto { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, CompanyName = c.CompanyName, EMail = u.EMail };
				return result.ToList();

			}
		}
	}
}
