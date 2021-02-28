using Ecommerce_App.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }

        public List<ProductDTO> Products { get; set; }

        public bool ShippingStatus { get; set; }

        //Probably will change when we know what the payment info looks like:
        public string PaymentInfo { get; set; }

        public decimal TotalCost { get; set;  }
    }
}
