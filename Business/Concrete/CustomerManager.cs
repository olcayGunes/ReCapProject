using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public IResult Add(Customer customer)
		{
			if (customer.CompanyName.Length>=2)
			{
				_customerDal.Add(customer);
				return new SuccessResult(Messages.CustomerAdded);
			}
			else
			{
				return new ErrorResult(Messages.CompanyNameInvalid);
			}
			
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
		}

		public IDataResult<List<CustomerDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
		}
	}
}