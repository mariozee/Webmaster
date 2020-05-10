using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Persistence
{
    public class WebmasterDbContext : DbContext, IApplicationDbContext
    {
        public WebmasterDbContext(DbContextOptions<WebmasterDbContext> options)
            : base(options)
        { }

        public DbSet<Website> Websites { get; set; }

        public DbSet<WebsiteCategory> WebsitesCategories { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebmasterDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
