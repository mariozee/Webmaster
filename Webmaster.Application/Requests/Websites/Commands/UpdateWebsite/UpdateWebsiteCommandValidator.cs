using FluentValidation;
using Webmaster.Application.Domain.Constraints;

namespace Webmaster.Application.Requests.Websites.Commands.UpdateWebsite
{
    public class UpdateWebsiteCommandValidator : AbstractValidator<UpdateWebsiteCommand>
    {
        public UpdateWebsiteCommandValidator()
        {
            this.RuleFor(w => w.Id)
                .GreaterThan(0);

            this.RuleFor(w => w.Name)
                .MaximumLength(WebsiteConstraints.MAX_NAME_LENGHT);

            this.RuleFor(w => w.Url)
                .MinimumLength(WebsiteConstraints.MIN_URL_LENGHT)
                .MaximumLength(WebsiteConstraints.MAX_URL_LRNGHT)
                .Matches(WebsiteConstraints.URL_REGEX);

            this.RuleFor(w => w.CategoryId)
                .GreaterThan(0);
        }
    }
}
