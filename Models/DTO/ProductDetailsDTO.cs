using Ecommerce_App.Auth.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models.DTO
{
    public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImgUrl { get; set; }
        public decimal ProductPrice { get; set; }

        public UserDTO User { get; set; }
    }
}
