using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Models.Product
{
    public class ProductServiceModel
    {
        public int Id { get; set; }

        public string Title { get; init; } = null!;

        public string Address { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;

        [Display(Name = "Price")]
        public decimal Price { get; init; }

        [Display(Name = "Is Buyer")]
        public bool IsBuyer { get; set; }
    }
}
