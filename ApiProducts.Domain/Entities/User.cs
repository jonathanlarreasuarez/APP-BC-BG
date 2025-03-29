using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Domain.Entities
{
    [Table("Users")] // Nombre de la tabla en la BD
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Puedes almacenar la contraseña de forma segura (hashing)
        public string Email { get; set; }
    }
}
