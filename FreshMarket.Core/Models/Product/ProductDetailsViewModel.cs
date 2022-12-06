using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Models.Product
{
    public class ProductDetailsViewModel
    {

        public string Title { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }
    }
}
