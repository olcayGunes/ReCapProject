﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
	public class CustomerDetailDto:IDto
	{
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string CustomerLastName { get; set; }
		public string CustomerEMail { get; set; }
		public string CustomerCompanyName { get; set; }
	}
}
