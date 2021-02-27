﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class RentalDetailDto:CustomerDetailDto,IDto
	{
		public string CarName { get; set; }
		public DateTime RentDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
