using MediatR;
using Microsoft.EntityFrameworkCore;
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

            var websiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
            };

            return websiteDto;
        }
    }
}
