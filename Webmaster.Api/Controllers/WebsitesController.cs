using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Webmaster.Application.Requests.Websites.Commands.CreateWebsite;
using Webmaster.Application.Requests.Websites.Commands.DeleteWebsite;
using Webmaster.Application.Requests.Websites.Commands.UpdateWebsite;
using Webmaster.Application.Requests.Websites.Queries.GetWebsite;
using Webmaster.Application.Requests.Websites.Queries.ListWwebsites;

namespace Webmaster.Api.Controllers
{
    [ApiController]
    [Route("api/websites")]
    public class WebsitesController : ApplicationController
    {
        [HttpGet("")]
        public async Task<IActionResult> List()
        {
            var websitesDtos = await this.Mediator.Send(new ListWebsitesQuery());

            return this.Ok(websitesDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var websiteDto = await this.Mediator.Send(new GetWebsiteQuery { WebsiteId = id });

            return this.Ok(websiteDto);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateWebsiteCommand command)
        {
            int websiteId = await this.Mediator.Send(command);

            return this.Ok(websiteId);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateWebsiteCommand command)
        {
            var updatedWebsiteDto = await this.Mediator.Send(command);

            return this.Ok(updatedWebsiteDto);
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedWebsiteId = await this.Mediator.Send(new DeleteWebsiteCommand { WebsiteId = id });

            return this.Ok(deletedWebsiteId);
        }
    }
}