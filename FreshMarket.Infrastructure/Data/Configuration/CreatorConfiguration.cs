using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Infrastructure.Data.Configuration
{
    internal class CreatorConfiguration : IEntityTypeConfiguration<Creator>
    {
        public void Configure(EntityTypeBuilder<Creator> builder)
        {
            builder.HasData(new Creator()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082"
            });
        }
    }
}
