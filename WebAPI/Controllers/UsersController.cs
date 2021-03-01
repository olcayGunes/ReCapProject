﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _userService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("Add")]
		public IActionResult Add(User user)
		{
			var result = _userService.Add(user);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("GetUserDetails")]
		public IActionResult GetUserDetails()
		{
			var result = _userService.GetUserDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
