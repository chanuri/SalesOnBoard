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
       
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
