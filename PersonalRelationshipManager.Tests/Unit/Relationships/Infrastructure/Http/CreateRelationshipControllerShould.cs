using Moq;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Infrastructure.Http;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Tests.Unit.Relationships.Infrastructure.Http;

public class CreateRelationshipControllerShould
{
    [Fact]
    public void ExecuteCreateRelationshipUseCaseWithReceivedRelationship()
    {
        var createRelationshipUseCase = new Mock<IUseCase<CreateRelationshipDto, IResult<Relationship>>>();
        var createRelationshipDto = new CreateRelationshipDto();
        var createRelationshipController = new CreateRelationshipController(createRelationshipUseCase.Object);

        _ = createRelationshipController.CreateRelationship(new CreateRelationshipRequest());

        createRelationshipUseCase.Verify(useCase => useCase.Execute(createRelationshipDto));
    }
}