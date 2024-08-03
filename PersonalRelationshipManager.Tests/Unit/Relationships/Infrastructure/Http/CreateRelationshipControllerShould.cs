using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.ValueObjects;
using PersonalRelationshipManager.Relationships.Infrastructure.Http;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Tests.Unit.Relationships.Infrastructure.Http;

public class CreateRelationshipControllerShould
{
    private readonly Mock<IUseCase<CreateRelationshipDto, Result<Relationship>>> _createRelationshipUseCase;
    private readonly CreateRelationshipController _createRelationshipController;

    public CreateRelationshipControllerShould()
    {
        _createRelationshipUseCase = new Mock<IUseCase<CreateRelationshipDto, Result<Relationship>>>();
        _createRelationshipController = new CreateRelationshipController(_createRelationshipUseCase.Object);
    }

    [Fact]
    public void ExecuteCreateRelationshipUseCaseWithReceivedRelationship()
    {
        var createRelationshipDto = new CreateRelationshipDto();

        _ = _createRelationshipController.CreateRelationship(new CreateRelationshipRequest());

        _createRelationshipUseCase.Verify(useCase => useCase.Execute(createRelationshipDto));
    }

    [Fact]
    public async Task RespondWithStatus201AndRelationshipIdWhenCreateRelationshipSuccessful()
    {
        var id = new RelationshipId(Guid.NewGuid());
        var createRelationshipRequest = new CreateRelationshipRequest();
        var createRelationshipDto = new CreateRelationshipDto();
        _createRelationshipUseCase.Setup(useCase => useCase.Execute(createRelationshipDto))
            .ReturnsAsync(Result<Relationship>.Ok(new Relationship(id)));

        var actionResult = await _createRelationshipController.CreateRelationship(createRelationshipRequest);

        var andWhichConstraint = actionResult.Should().BeOfType<CreatedResult>();
        andWhichConstraint
            .Which.StatusCode.Should().Be(StatusCodes.Status201Created);
        andWhichConstraint.Which.Value.Should().Be(new CreateRelationshipResponse(id));
    }
}