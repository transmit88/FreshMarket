using System.ComponentModel.DataAnnotations;

namespace FreshMarket.Infrastructure.Data
{
    public class Category
    {

        public Category()
        {
            Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}
