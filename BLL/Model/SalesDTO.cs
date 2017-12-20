using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BLL.Model
{
    public class SalesDTO:Input
    {        
        [Required (ErrorMessage ="Customer field required" ) ]
        [Range (0,int.MaxValue, ErrorMessage = "Customer field required")]
        public int CustomerId {get; set;}
        [Required(ErrorMessage = "Store field required")]
        [Range(0, int.MaxValue, ErrorMessage = "Store field required")]
        public int StoreId{ get; set; }
        [Required(ErrorMessage = "Product field required")]
        [Range(0, int.MaxValue, ErrorMessage = "Product field required")]
        public int ProductId { get; set; }
        [DataType(DataType.Date)]
        [Required , DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public IEnumerable<Customer> CustomerList { get; set; }
        public IEnumerable<Store> StoreList { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
    }
}
