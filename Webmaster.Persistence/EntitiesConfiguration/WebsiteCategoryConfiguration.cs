using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Webmaster.Application.Domain.Constraints;
using Webmaster.Application.Domain.Entities;

namespace Webmaster.Persistence.EntitiesConfiguration
{
    public class WebsiteCategoryConfiguration : IEntityTypeConfiguration<WebsiteCategory>
    {
        public void Configure(EntityTypeBuilder<WebsiteCategory> builder)
        {
            builder.ToTable(nameof(WebsiteCategory));
            builder.HasKey(wc => wc.Id);

            builder.Property(wc => wc.Name)
                .HasMaxLength(WebsiteCategoryConstraints.MAX_NAME_LENGHT)
                .IsRequired();

            builder.HasData
            (
                new WebsiteCategory { Id = 1, Name = "Arts and Entertainment" },
                new WebsiteCategory { Id = 2, Name = "Business and Consumer Services" },
                new WebsiteCategory { Id = 3, Name = "Community and Society" },
                new WebsiteCategory { Id = 4, Name = "Computers Electronics and Technology" },
                new WebsiteCategory { Id = 5, Name = "E commerce and Shopping" },
                new WebsiteCategory { Id = 6, Name = "Finance" },
                new WebsiteCategory { Id = 7, Name = "Food and Drink" },
                new WebsiteCategory { Id = 8, Name = "Gambling" },
                new WebsiteCategory { Id = 9, Name = "Games" },
                new WebsiteCategory { Id = 10, Name = "Health" },
                new WebsiteCategory { Id = 11, Name = "Hobbies and Leisure" },
                new WebsiteCategory { Id = 12, Name = "Home and Garden" },
                new WebsiteCategory { Id = 13, Name = "Jobs and Career" },
                new WebsiteCategory { Id = 14, Name = "Law and Government" },
                new WebsiteCategory { Id = 15, Name = "Lifestyle" },
                new WebsiteCategory { Id = 16, Name = "News and Media" },
                new WebsiteCategory { Id = 17, Name = "Pets and Animals" },
                new WebsiteCategory { Id = 18, Name = "Reference Materials" },
                new WebsiteCategory { Id = 19, Name = "Science and Education" },
                new WebsiteCategory { Id = 20, Name = "Sports" },
                new WebsiteCategory { Id = 21, Name = "Travel and Tourism" },
                new WebsiteCategory { Id = 22, Name = "Vehicles" },
                new WebsiteCategory { Id = 23, Name = "Adult" }    
            );
        }
    }
}
