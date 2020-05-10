using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Commands.DeleteWebsite
{
    public class DeleteWebsiteCommand : IRequest<int>
    {
        public int WebsiteId { get; set; }
    }
}
