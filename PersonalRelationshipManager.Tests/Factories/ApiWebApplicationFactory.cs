using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;
using Testcontainers.PostgreSql;

namespace PersonalRelationshipManager.Tests.Factories;

public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    private PostgreSqlContainer _postgreSqlContainer;


    public override async ValueTask DisposeAsync()
    {
        await _postgreSqlContainer.DisposeAsync().AsTask();
    }


    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        _postgreSqlContainer = new PostgreSqlBuilder().Build();
        _postgreSqlContainer.StartAsync().Wait();

        var databaseSettings = new DatabaseSettings
        {
            ConnectionString = _postgreSqlContainer.GetConnectionString()
        };

        builder.ConfigureServices(services => { services.AddSingleton(Options.Create(databaseSettings)); });

        builder.ConfigureAppConfiguration(_ => { });
    }
}