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

        public int CustomerId { get; set; }
        public int StoreId{ get; set; }
        public int ProductId { get; set; }        

        public IEnumerable<Customer> CustomerList { get; set; }
        public IEnumerable<Store> StoreList { get; set; }
        public IEnumerable<Product> ProductList { get; set; }
    }
}
