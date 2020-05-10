using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Domain.Entities;

namespace Webmaster.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Website> Websites { get; set; }
        
        DbSet<WebsiteCategory> WebsitesCategories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
