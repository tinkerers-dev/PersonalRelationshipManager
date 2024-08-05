using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Errors;
using PersonalRelationshipManager.Relationships.Infrastructure.Http;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared;
using PersonalRelationshipManager.Tests.Builders;

namespace PersonalRelationshipManager.Tests.Relationships.Infrastructure.Http;

public class CreateRelationshipControllerShould
{
    private readonly Mock<IUseCase<CreateRelationshipDto, Result<Relationship>>> _createRelationshipUseCase;
    private readonly CreateRelationshipController _createRelationshipController;
    private readonly CreateRelationshipRequest _createRelationshipRequest = CreateRelationshipRequestBuilder.AFriend().Build();

    public CreateRelationshipControllerShould()
    {
        _createRelationshipUseCase = new Mock<IUseCase<CreateRelationshipDto, Result<Relationship>>>();
        _createRelationshipController = new CreateRelationshipController(_createRelationshipUseCase.Object);
    }

    [Fact]
    public async Task RespondWithStatus201AndRelationshipIdWhenCreateRelationshipSuccessful()
    {
        var id = Guid.NewGuid();
        var relationship = RelationshipBuilder.AFriend().WithId(id).Build();
        _createRelationshipUseCase.Setup(useCase => useCase.Execute(It.IsAny<CreateRelationshipDto>()))
            .ReturnsAsync(Result<Relationship>.Ok(relationship));

        var actionResult = await _createRelationshipController.CreateRelationship(_createRelationshipRequest);

        var andWhichConstraint = actionResult.Should().BeOfType<CreatedResult>();
        andWhichConstraint
            .Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        andWhichConstraint.Which.Value.Should().Be(new CreateRelationshipResponse(relationship.GetId()));
    }

    [Fact]
    public async Task RespondWithStatusCode500WhenRelationshipCouldNotBeCreated()
    {
        _createRelationshipUseCase.Setup(useCase => useCase.Execute(It.IsAny<CreateRelationshipDto>()))
            .ReturnsAsync(Result<Relationship>.Failure(new UnableToCreateRelationshipError()));

        var actionResult = await _createRelationshipController.CreateRelationship(_createRelationshipRequest);

        actionResult.Should().BeOfType<ObjectResult>().Which.StatusCode.Should()
            .Be(StatusCodes.Status500InternalServerError);
    }
}