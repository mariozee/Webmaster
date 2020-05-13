using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Requests.Websites.Queries.ListWwebsites;

namespace Webmaster.Tests.Application.Requests.Websites.Queries
{
    using static TestsSetup;

    public class ListWebsitesTests : TestBase
    {       
        [Test]
        public async Task ShouldReturnOneWebsite()
        {
            Website website = new Website
            {
                Name = "test",
                Url = "test.com",
                CategoryId = 1,
                ImagePath = "not existing one",
                Email = "test@email",
                Password = "123456"
            };

            await AddAsync(website);

            var query = new ListWebsitesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
        }

        [Test]
        public async Task ShouldReturnNoMoreThanTenWebsites()
        {
            for (int i = 0; i < 15; i++)
            {
                Website website = new Website
                {
                    Name = "test",
                    Url = "test.com",
                    CategoryId = 1,
                    ImagePath = "not existing one",
                    Email = "test@email",
                    Password = "123456"
                };

                await AddAsync(website);
            }

            var query = new ListWebsitesQuery();

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
            result.Should().HaveCountLessOrEqualTo(10);
        }
    }
}
