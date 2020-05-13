using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Webmaster.Application.Domain.Entities;

namespace Webmaster.Persistence.EntitiesConfiguration
{
    public class WebsiteCredentialsConfiguration : IEntityTypeConfiguration<WebsiteCredentials>
    {
        public void Configure(EntityTypeBuilder<WebsiteCredentials> builder)
        {
            builder.ToTable(nameof(WebsiteCredentials));
            builder.HasKey(wc => new { wc.Id, wc.WebsiteId });

            builder.Property(wc => wc.Email).IsRequired();
            builder.Property(wc => wc.Password).IsRequired();

            builder.HasOne(wc => wc.Website).WithOne(w => w.Credentials).HasForeignKey<WebsiteCredentials>(wc => wc.WebsiteId);
        }
    }
}
