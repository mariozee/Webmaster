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
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.UpdateWebsite
{
    public class UpdateWebsiteCommandHandler : IRequestHandler<UpdateWebsiteCommand, WebsiteDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IHostingEnvironment hostingEnvironment;

        public UpdateWebsiteCommandHandler(IApplicationDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            this.dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
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
                website.ImagePath = await this.SaveImageAsync(request.Image);

            if (!string.IsNullOrWhiteSpace(request.Email))
                website.Credentials.Email = request.Email;

            if (!string.IsNullOrWhiteSpace(request.Password))
                website.Credentials.Password = request.Password;

            await this.dbContext.SaveChangesAsync();

            var updatedWebsiteDto = new WebsiteDto
            {
                Id = website.Id,
                Name = website.Name,
                Url = website.Url,
                CategoryId = website.Category.Id,
                Category = website.Category.Name,
                ImageBase64 = this.GetImageAsBase64(website.ImagePath),
                Email = website.Credentials.Email,
                Password = website.Credentials.Password,
            };

            return updatedWebsiteDto;
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

        public string GetImageAsBase64(string imagePath)
        {
            var bytes = File.ReadAllBytes(imagePath);
            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }
    }
}
