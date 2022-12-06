using FreshMarket.Core.Models.Creator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Models.Product
{
    public class ProductDetailsModel : ProductServiceModel
    {

        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public CreatorServiceModel  Creator { get; set; }
    }
}
