using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;
using Webmaster.Application.Extentions;
using System.IO;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQueryHandler : IRequestHandler<ListWebsitesQuery, IEnumerable<WebsiteDto>>
    {
        private const int DefaultPageIndex = 1;
        private const int DefaultPageSize = 10;

        private readonly IApplicationDbContext dbContext;

        public ListWebsitesQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<WebsiteDto>> Handle(ListWebsitesQuery request, CancellationToken cancellationToken)
        {
            var websitesQuery = this.dbContext.Websites
                .Where(w => w.Deleted == false)
                .SortBy(request.SortBy, request.SortDirection);

            if (request.PageIndex.HasValue && request.PageSize.HasValue)
                websitesQuery = websitesQuery.Paginate(request.PageIndex.Value, request.PageSize.Value);
            else
                websitesQuery = websitesQuery.Paginate(DefaultPageIndex, DefaultPageSize);

            var websites = await websitesQuery.ToListAsync();

            var websitesDtos = websites.Select(w => new WebsiteDto
            {
                Id = w.Id,
                Name = w.Name,
                Url = w.Url,
                CategoryId = w.Category.Id,
                Category = w.Category.Name,
                ImageBase64 = this.GetImageAsBase64(w.ImagePath)
            });

            return websitesDtos;
        }

        public string GetImageAsBase64(string imagePath)
        {
            var bytes = File.ReadAllBytes(imagePath);
            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }
    }
}
