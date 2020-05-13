using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Common.Files;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Queries.GetWebsite
{
    public class GetWebsiteQueryHandler : IRequestHandler<GetWebsiteQuery, WebsiteDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IHostEnvironment hostingEnvironment;
        private readonly ImageProvider imageProvider;

        public GetWebsiteQueryHandler(IApplicationDbContext dbContext, ImageProvider imageProvider)
        {
            this.dbContext = dbContext;
            this.imageProvider = imageProvider;
        }

        public async Task<WebsiteDto> Handle(GetWebsiteQuery request, CancellationToken cancellationToken)
        {
            var website = await this.dbContext.Websites
                .FirstOrDefaultAsync(w => w.Id == request.WebsiteId && w.Deleted == false);
            if (website == null)
                throw new NotFoundException(nameof(Website), request.WebsiteId);

            var websiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
                ImageBase64 = this.imageProvider.GetBase64ImageFromPath(website.ImagePath),
                Email = website.Email,
                Password = website.Password
            };

            return websiteDto;
        }
    }
}
