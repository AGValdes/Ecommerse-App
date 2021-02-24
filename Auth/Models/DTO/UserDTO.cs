using Ecommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Auth.Models.DTO
{
    public class UserDTO
    {
        public string ID { get; set; }
        public string Username { get; set; }
        public IList<string> Roles { get; set; }
       public UserCart Cart { get; set; }
  }
}
