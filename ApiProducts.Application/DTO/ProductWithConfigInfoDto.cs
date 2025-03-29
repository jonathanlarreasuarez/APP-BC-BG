using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Application.DTO
{
    public class ProductWithConfigInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal? lastNetValue { get; set; }
        public int ConfigCount { get; set; }
    }
}
