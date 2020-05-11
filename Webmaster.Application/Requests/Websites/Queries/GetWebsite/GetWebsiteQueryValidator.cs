using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Queries.GetWebsite
{
    public class GetWebsiteQueryValidator : AbstractValidator<GetWebsiteQuery>
    {
        public GetWebsiteQueryValidator()
        {
            this.RuleFor(w => w.WebsiteId)
                .GreaterThan(0);
        }
    }
}
