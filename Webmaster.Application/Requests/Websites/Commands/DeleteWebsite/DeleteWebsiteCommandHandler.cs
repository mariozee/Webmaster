using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Webmaster.Application.Common.Exceptions;
using Webmaster.Application.Domain.Entities;
using Webmaster.Application.Interfaces;

namespace Webmaster.Application.Requests.Websites.Commands.DeleteWebsite
{
    public class DeleteWebsiteCommandHandler : IRequestHandler<DeleteWebsiteCommand, int>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteWebsiteCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteWebsiteCommand request, CancellationToken cancellationToken)
        {
            var website = await this.dbContext.Websites
                .FirstOrDefaultAsync(w => w.Id == request.WebsiteId && w.Deleted == false);
            if (website == null)
                throw new NotFoundException(nameof(Website), request.WebsiteId);

            website.Deleted = true;
            await dbContext.SaveChangesAsync();

            return website.Id;
        }
    }
}
