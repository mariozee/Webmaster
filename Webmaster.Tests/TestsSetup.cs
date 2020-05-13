using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Respawn;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Webmaster.Api;
using Webmaster.Persistence;

namespace Webmaster.Tests
{
    [SetUpFixture]
    public class TestsSetup
    {
        private static IConfiguration configuration;
        private static IServiceScopeFactory scopeFactory;
        private static Checkpoint checkpoint;

        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            configuration = builder.Build();

            var services = new ServiceCollection();

            var startup = new Startup(configuration);

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "Webmaster.Api"));

            startup.ConfigureServices(services);

            scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();            

            checkpoint = new Checkpoint 
            {
                TablesToIgnore = new [] { "__EFMigrationsHistory", "WebsiteCategory" },
                WithReseed = true
            };

            using var scope = scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<WebmasterDbContext>();
            context.Database.Migrate();
        }

        public static async Task ResetState()
        {
            await checkpoint.Reset(configuration.GetConnectionString("WebmasterDatabase"));
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<WebmasterDbContext>();

            context.Add(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }
    }
}
