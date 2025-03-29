using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Application.DTO
{
    public class ProductRequestDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "El SKU no puede tener más de 10 caracteres.")]
        public string SKU { get; set; } = string.Empty;

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9999.99, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "La descripción no puede exceder los 100 caracteres.")]
        public string Description { get; set; } = string.Empty;
    }
}
