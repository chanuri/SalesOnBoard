using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class TotalSalesDTO:Input
    {

        //public virtual Customer customer { get; set; }
        //public virtual Product product { get; set; }
        //public virtual Store store { get; set; }
        public string StoreName { get; set; }
        public string ProductName{ get; set; }
        public virtual int TotalQty { get; set; }
    }
}
