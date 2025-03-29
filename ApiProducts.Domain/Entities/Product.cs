using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public string SKU { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        // Relación con ProductConfig
        public List<ProductConfig>? ProductConfigs { get; set; }
    }
}
