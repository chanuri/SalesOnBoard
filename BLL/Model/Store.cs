using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class Store:Input
    {
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}
