using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQueryHandler : IRequestHandler<ListWebsitesQuery, IEnumerable<WebsiteDto>>
    {
        private readonly IApplicationDbContext dbContext;

        public ListWebsitesQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WebsiteDto>> Handle(ListWebsitesQuery request, CancellationToken cancellationToken)
        {
            var websites = await dbContext.Websites
                .Where(w => w.Deleted == false).ToListAsync();
            var websitesDtos = websites.Select(w => new WebsiteDto
            {
                Id = w.Id,
                Name = w.Name,
                Url = w.Url,
                CategoryId = w.Category.Id,
                Category = w.Category.Name
            });

            return websitesDtos;
        }
    }
}
