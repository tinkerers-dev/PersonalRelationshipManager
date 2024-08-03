using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;

namespace PersonalRelationshipManager.Tests.Acceptance;

public class CreateRelationshipFeature(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task UserShouldBeAbleToCreateARelationship()
    {
        var httpClient = factory.CreateClient();

        var newRelationship = new CreateRelationshipRequest();
        var response  = await httpClient.PostAsJsonAsync("/relationships", newRelationship);

        response.EnsureSuccessStatusCode();

        response.StatusCode.Should().Be(HttpStatusCode.Created);

    }
}