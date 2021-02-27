﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		public IResult Add(Color color)
		{
			if (color.Name.Length < 2)
			{
				return new ErrorResult(Messages.ColorNameInvalid);
			}
			else
			{
				_colorDal.Add(color);
				return new SuccessResult(Messages.ColorAdded);
			}
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
		}
	}
}
