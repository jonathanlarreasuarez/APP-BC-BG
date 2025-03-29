using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Domain.Entities
{
    public class ProductConfig
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal NetPrice { get; set; }
        public DateTime BatchDate { get; set; }

        public string Observation { get; set; } = string.Empty;

        // Relación con Product
        public Product? Product { get; set; }
    }
}
