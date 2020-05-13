using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Common.Files;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Extentions;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.UpdateWebsite
{
    public class UpdateWebsiteCommandHandler : IRequestHandler<UpdateWebsiteCommand, WebsiteDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly ImageProvider imageProvider;

        public UpdateWebsiteCommandHandler(IApplicationDbContext dbContext, ImageProvider imageProvider)
        {
            this.dbContext = dbContext;
            this.imageProvider = imageProvider;
        }

        public async Task<WebsiteDto> Handle(UpdateWebsiteCommand request, CancellationToken cancellationToken)
        {
            var website = await this.dbContext.Websites
                .FirstOrDefaultAsync(w => w.Id == request.Id && w.Deleted == false);
            if (website == null)
                throw new NotFoundException(nameof(Website), request.Id);            

            if (!string.IsNullOrWhiteSpace(request.Name))
                website.Name = request.Name;

            if (!string.IsNullOrWhiteSpace(request.Url))
                website.Url = request.Url;

            if (request.CategoryId.HasValue)
            {
                var category = await this.dbContext.WebsitesCategories.FindAsync(request.CategoryId);
                if (category == null)
                    throw new NotFoundException(nameof(WebsiteCategory), request.CategoryId);

                website.CategoryId = request.CategoryId.Value;
            }

            if (request.Image != null)
            {
                string filePath = await request.Image.SaveToAsync(this.imageProvider.ImagesPath);
                website.ImagePath = filePath;
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
                website.Email = request.Email;

            if (!string.IsNullOrWhiteSpace(request.Password))
                website.Password = request.Password;

            await this.dbContext.SaveChangesAsync();

            var updatedWebsiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
                ImageBase64 = this.imageProvider.GetBase64ImageFromPath(website.ImagePath),
                Email = request.Email,
                Password = request.Password,
            };

            return updatedWebsiteDto;
        }
    }
}
