using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Webmaster.Application.Domain.Constraints;

namespace Webmaster.Application.Requests.Websites.Commands.CreateWebsite
{
    public class CreateWebsiteCommandValidator : AbstractValidator<CreateWebsiteCommand>
    {
        public CreateWebsiteCommandValidator()
        {
            this.RuleFor(w => w.Name)
                .MaximumLength(WebsiteConstraints.MAX_NAME_LENGHT)
                .NotEmpty()
                .NotNull();

            this.RuleFor(w => w.Url)
                .MinimumLength(WebsiteConstraints.MIN_URL_LENGHT)
                .MaximumLength(WebsiteConstraints.MAX_URL_LRNGHT)
                .Matches(WebsiteConstraints.URL_REGEX)
                .NotEmpty()
                .NotNull();

            this.RuleFor(w => w.CategoryId)
                .GreaterThan(0);

            this.RuleFor(w => w.Image)
                .NotNull();
        }
    }
}
