using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
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
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(w => w.Url)
                .HasMaxLength(1000)
                .IsRequired();

            builder.HasOne(w => w.Category).WithMany(wc => wc.Websites).HasForeignKey(w => w.CategoryId);
        }
    }
}
