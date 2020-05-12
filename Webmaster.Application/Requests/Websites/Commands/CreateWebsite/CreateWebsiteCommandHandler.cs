using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IHostingEnvironment hostingEnvironment;

        public CreateWebsiteCommandHandler(IApplicationDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            this.dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<int> Handle(CreateWebsiteCommand request, CancellationToken cancellationToken)
        {
            var category = await this.dbContext.WebsitesCategories.FindAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException(nameof(WebsiteCategory), request.CategoryId);

            string filePath = await this.SaveImageAsync(request.Image);

            var website = new Website
            {
                Name = request.Name,
                Url = request.Url,
                CategoryId = request.CategoryId,
                ImagePath = filePath,
            };

            await this.dbContext.Websites.AddAsync(website);
            await this.dbContext.SaveChangesAsync();

            return website.Id;
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            string uploadPath = Path.Combine(this.hostingEnvironment.ContentRootPath, "Images");
            string filePath = Path.Combine(uploadPath, image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
