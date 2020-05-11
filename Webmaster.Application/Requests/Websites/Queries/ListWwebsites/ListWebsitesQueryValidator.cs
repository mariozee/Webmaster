using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Queries.ListWwebsites
{
    public class ListWebsitesQueryValidator : AbstractValidator<ListWebsitesQuery>
    {
        public ListWebsitesQueryValidator()
        {
            this.RuleFor(x => x.PageIndex)
                .GreaterThan(0);

            this.RuleFor(x => x.PageSize)
                .GreaterThan(0);
        }
    }
}
