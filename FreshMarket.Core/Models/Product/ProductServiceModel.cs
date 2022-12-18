using FreshMarket.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace FreshMarket.Core.Models.Product
{
    public class ProductServiceModel : IProductModel
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
