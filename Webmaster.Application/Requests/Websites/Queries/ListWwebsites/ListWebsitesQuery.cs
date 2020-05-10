using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQuery : IRequest<IEnumerable<WebsiteDto>>
    {
    }
}
