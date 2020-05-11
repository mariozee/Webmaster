using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Webmaster.Application.Requests.Websites.Commands.DeleteWebsite
{
    public class DeleteWebsiteCommandValidator : AbstractValidator<DeleteWebsiteCommand>
    {
        public DeleteWebsiteCommandValidator()
        {
            this.RuleFor(w => w.WebsiteId)
                .GreaterThan(0);
        }
    }
}
