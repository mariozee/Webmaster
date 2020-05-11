using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQuery : IRequest<IEnumerable<WebsiteDto>>
    {
        public string SortBy { get; set; }

        public string SortDirection { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }
    }
}
