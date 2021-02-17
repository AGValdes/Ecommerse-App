using Ecommerce_App.Auth.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Auth.Models
{
    public class BadRegisterVM
    {
        public string error { get; set; }

        public BadRegisterVM (string e)
        {
            error = e;
        }
    }
}
