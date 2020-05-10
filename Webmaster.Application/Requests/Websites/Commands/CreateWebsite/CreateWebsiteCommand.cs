using MediatR;

namespace Webmaster.Application.Requests.Websites.Commands.CreateWebsite
{
    public class CreateWebsiteCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public int CategoryId { get; set; }
    }
}
