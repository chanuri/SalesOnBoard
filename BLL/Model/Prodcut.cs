using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.Model
{
    public class Product:Input
    {
        [StringLength(50, ErrorMessage ="Name cannot be greater than 50 characters"), Required(ErrorMessage ="Name Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public decimal Price { get; set; }
    }
}
