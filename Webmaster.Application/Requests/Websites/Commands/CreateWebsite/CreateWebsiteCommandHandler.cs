using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Common.Files;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Extentions;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.CreateWebsite
{
    public class CreateWebsiteCommandHandler : IRequestHandler<CreateWebsiteCommand, int>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly ImageProvider imageProvider;

        public CreateWebsiteCommandHandler(IApplicationDbContext dbContext, ImageProvider imageProvider)
        {
            this.dbContext = dbContext;
            this.imageProvider = imageProvider;
        }

        public async Task<int> Handle(CreateWebsiteCommand request, CancellationToken cancellationToken)
        {
            var category = await this.dbContext.WebsitesCategories.FindAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException(nameof(WebsiteCategory), request.CategoryId);

            string filePath = await request.Image.SaveToAsync(this.imageProvider.ImagesPath);

            var website = new Website
            {
                Name = request.Name,
                Url = request.Url,
                CategoryId = request.CategoryId,
                ImagePath = filePath,
                Email = request.Email,
                Password = request.Password
            };

            await this.dbContext.Websites.AddAsync(website);
            await this.dbContext.SaveChangesAsync();

            return website.Id;
        }
    }
}
