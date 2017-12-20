using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class SalesSumaryDTO:Input
    {
        public string StoreName { get; set; }
        public int NoOfProducts { get; set; }
        public decimal TotalSales { get; set; }
    }
}

