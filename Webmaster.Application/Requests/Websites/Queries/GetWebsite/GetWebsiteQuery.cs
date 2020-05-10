using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Queries.GetWebsite
{
    public class GetWebsiteQuery : IRequest<WebsiteDto>
    {
        public int WebsiteId { get; set; }
    }
}
