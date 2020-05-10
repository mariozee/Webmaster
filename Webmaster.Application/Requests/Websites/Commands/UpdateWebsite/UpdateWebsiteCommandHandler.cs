using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.UpdateWebsite
{
    public class UpdateWebsiteCommandHandler : IRequestHandler<UpdateWebsiteCommand, WebsiteDto>
    {
        private readonly IApplicationDbContext dbContext;

        public UpdateWebsiteCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WebsiteDto> Handle(UpdateWebsiteCommand request, CancellationToken cancellationToken)
        {
            var website = await this.dbContext.Websites
                .FirstOrDefaultAsync(w => w.Id == request.Id && w.Deleted == false);
            if (website == null)
                throw new NotFoundException(nameof(Website), request.Id);

            var category = await this.dbContext.WebsitesCategories.FindAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException(nameof(WebsiteCategory), request.CategoryId);

            website.Name = request.Name;
            website.Url = request.Url;
            website.CategoryId = request.CategoryId;

            var updatedWebsiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
            };

            await this.dbContext.SaveChangesAsync();

            return updatedWebsiteDto;
        }
    }
}
