using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_App.Models.DTO
{
    public class CategoryDetailsDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public List<ProductDTO> Products { get; set; }
    }
}
