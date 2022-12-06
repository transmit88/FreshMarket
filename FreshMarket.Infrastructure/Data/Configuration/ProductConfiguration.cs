using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Infrastructure.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateProducts());
        }

        private List<Product> CreateProducts()
        {

            var products = new List<Product>()
            {
                 new Product()
                {
                    Id = 1,
                    Title = "Tomate",
                    Address = "BG(near the border)",
                    Description = "Sweet Tomate",
                    ImageUrl = "https://thumbs.dreamstime.com/b/big-boy-4412597.jpg",
                    Price = 3.20m ,
                    CategoryId = 2,
                    CreatorId = 1
                },

                new Product()
                {
                    Id = 2,
                    Title = "Cocumber",
                    Address  = "Bulgaria (garden in Burgas)",
                    Description = "Fresh Cocumber for your salad",
                    ImageUrl = "https://www.tasteofhome.com/wp-content/uploads/2018/06/shutterstock_1058462660.jpg?fit=700,700",
                    Price = 2.20m,
                    CategoryId = 2,
                    CreatorId = 1
                },

                new Product()
                {
                    Id = 3,
                    Title = "Green Apple",
                    Address  = "BG",
                    Description = "The Green apple's white flesh is hard, crispy, and juicy.",
                    ImageUrl = "https://i.pinimg.com/originals/8f/16/71/8f16713bc593575ad152ac7f2fcd3e44.jpg",
                    Price = 1.30m,
                    CategoryId = 1,
                    CreatorId = 1
                },
            };

            return products;
        }
    }
}
