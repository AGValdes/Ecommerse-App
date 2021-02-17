﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Auth.Models.DTO
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }
        

        [Required]
        public string Password { get; set; }
    }
}
