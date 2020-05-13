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
using Webmaster.Application.Common.Files;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQueryHandler : IRequestHandler<ListWebsitesQuery, IEnumerable<WebsiteDto>>
    {
        private const int DefaultPageIndex = 1;
        private const int DefaultPageSize = 10;

        private readonly IApplicationDbContext dbContext;
        private readonly ImageProvider imageProvider;

        public ListWebsitesQueryHandler(IApplicationDbContext dbContext, ImageProvider imageProvider)
        {
            this.dbContext = dbContext;
            this.imageProvider = imageProvider;
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
                ImageBase64 = this.imageProvider.GetBase64ImageFromPath(w.ImagePath),
                Email = w.Email,
                Password = w.Password
            }).ToList();

            return websitesDtos;
        }
    }
}
