using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Queries.GetWebsite
{
    public class GetWebsiteQueryHandler : IRequestHandler<GetWebsiteQuery, WebsiteDto>
    {
        private readonly IApplicationDbContext dbContext;

        public GetWebsiteQueryHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WebsiteDto> Handle(GetWebsiteQuery request, CancellationToken cancellationToken)
        {
            var website = await this.dbContext.Websites
                .FirstOrDefaultAsync(w => w.Id == request.WebsiteId && w.Deleted == false);
            if (website == null)
                throw new NotFoundException(nameof(Website), request.WebsiteId);

            string base64Image = this.GetImageAsBase64(website.ImagePath);

            var websiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
                ImageBase64 = base64Image,
                Email = website.Credentials.Email,
                Password = website.Credentials.Password
            };

            return websiteDto;
        }

        public string GetImageAsBase64(string imagePath)
        {
            var bytes = File.ReadAllBytes(imagePath);
            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }
    }
}
