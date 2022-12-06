using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Models.Product
{
    public class ProductQueryModel
    {
        public int TotalProductCount { get; set; }

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();

    }
}
