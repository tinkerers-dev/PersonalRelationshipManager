using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.Options;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;
using PersonalRelationshipManager.Tests.Factories;
using Testcontainers.PostgreSql;

namespace PersonalRelationshipManager.Tests.Acceptance;

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