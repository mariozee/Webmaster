using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Commands.UpdateWebsite
{
    public class UpdateWebsiteCommand : IRequest<WebsiteDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int? CategoryId { get; set; }

        public IFormFile Image { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
