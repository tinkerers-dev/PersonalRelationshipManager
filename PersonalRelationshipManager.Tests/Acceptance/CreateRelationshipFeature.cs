using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;

namespace PersonalRelationshipManager.Tests.Acceptance;

public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configurationBuilder => { });
    }
}

public class CreateRelationshipFeature(ApiWebApplicationFactory<Program> factory)
    : IClassFixture<ApiWebApplicationFactory<Program>>
{
    [Fact]
    public async Task UserShouldBeAbleToCreateARelationship()
    {
        var httpClient = factory.CreateClient();

        var newRelationship = new CreateRelationshipRequest
        {
            Type = "friend",
            Name = "John Doe",
            NickName = "Jonny",
            Email = "john.doe@gmail.com",
            Phone = "123456789",
            Birthday = new DateTime(1992, 03, 15),
            ContactMethods = new string[]
            {
                "WhatsApp",
                "Telegram"
            }
        };
        var response = await httpClient.PostAsJsonAsync("/relationships", newRelationship);

        response.EnsureSuccessStatusCode();

        response.StatusCode.Should().Be(HttpStatusCode.Created);
        response.Content.Should().NotBeNull();
    }
}