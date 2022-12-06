﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "fruits"
                },

                new Category()
                {
                    Id = 2,
                    Name = "vegetable"
                },

                new Category()
                {
                    Id = 3,
                    Name = "fruit import"
                },
                 new Category()
                {
                    Id = 4,
                    Name = "leafy vegetables"
                },
                   new Category()
                {
                    Id = 5,
                    Name = "others"
                },
            };

            return categories;
        }
    }
}
