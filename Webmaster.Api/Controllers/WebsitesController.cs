using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Webmaster.Api.Controllers
{
    [ApiController]
    [Route("api/websites")]
    public class WebsitesController : ApplicationController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.Ok();
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create()
        {
            return this.Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update()
        {
            return this.Ok();
        }

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return this.Ok();
        }
    }
}