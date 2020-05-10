using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.CreateWebsite
{
    public class CreateWebsiteCommandHandler : IRequestHandler<CreateWebsiteCommand, int>
    {
        private readonly IApplicationDbContext dbContext;

        public CreateWebsiteCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(CreateWebsiteCommand request, CancellationToken cancellationToken)
        {
            var category = await this.dbContext.WebsitesCategories.FindAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException(nameof(WebsiteCategory), request.CategoryId);

            var website = new Website
            {
                Name = request.Name,
                Url = request.Url,
                CategoryId = request.CategoryId
            };

            await this.dbContext.Websites.AddAsync(website);
            await this.dbContext.SaveChangesAsync();

            return website.Id;
        }
    }
}
