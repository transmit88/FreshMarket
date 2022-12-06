using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Models.Product
{
    public class ProductModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [Required]
        [Display(Name = "Price")]
        [Range(0.00, 2000.00, ErrorMessage = "Price must be a positive number and less than {2} leva")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 15)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required] // ?
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductCategoriesModel> ProductCategories { get; set; } = new List<ProductCategoriesModel>();
    }
}
