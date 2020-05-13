using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Requests.Websites.Queries.GetWebsite;
using Webmaster.Application.Requests.Websites.Queries.ListWwebsites;

namespace Webmaster.Tests.Application.Requests.Websites.Queries
{
    using static TestsSetup;

    public class GetWebsiteTests : TestBase
    {
        [Test]
        public async Task ShouldReturnWebsite()
        {
            Website website = new Website
            {
                Name = "test",
                Url = "test.com",
                CategoryId = 1,
                ImagePath = "e:\\fake\\path\\image.jpg",
                Email = "test@email.com",
                Password = "123456"
            };

            await AddAsync(website);

            var query = new GetWebsiteQuery { WebsiteId = 1 };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Name.Should().Be(website.Name);
        }

        [Test]
        public async Task ShouldRequireExisitingWebsite()
        {
            Website website = new Website
            {
                Name = "test",
                Url = "test.com",
                CategoryId = 1,
                ImagePath = "e:\\fake\\path\\image.jpg",
                Email = "test@email.com",
                Password = "123456"
            };

            await AddAsync(website);

            var query = new GetWebsiteQuery { WebsiteId = 10 };

            FluentActions.Invoking(() => SendAsync(query)).Should().Throw<NotFoundException>();
        }
    }
}
