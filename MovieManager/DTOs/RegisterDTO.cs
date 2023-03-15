﻿using System;
namespace MovieManager.DTOs
{
	public class RegisterDTO
	{
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public int RoleId { get; set; }
    }
}

