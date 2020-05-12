using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Webmaster.Application.Domain.Constraints;
using Webmaster.Application.Domain.Entities;

namespace Webmaster.Persistence.EntitiesConfiguration
{
    public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            builder.ToTable(nameof(Website));
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .HasMaxLength(WebsiteConstraints.MAX_NAME_LENGHT)
                .IsRequired();

            builder.Property(w => w.Url)
                .HasMaxLength(WebsiteConstraints.MAX_URL_LRNGHT)
                .IsRequired();

            builder.Property(w => w.ImagePath)
                .HasMaxLength(WebsiteConstraints.MAX_IMAGE_PATH_LENGHT)
                .IsRequired();

            builder.HasOne(w => w.Category).WithMany(wc => wc.Websites).HasForeignKey(w => w.CategoryId);
        }
    }
}
