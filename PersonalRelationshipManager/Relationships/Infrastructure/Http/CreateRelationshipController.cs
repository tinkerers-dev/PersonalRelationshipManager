using System.Net;
using Microsoft.AspNetCore.Mvc;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Http;

[ApiController]
[Route("/relationships")]
public class CreateRelationshipController(IUseCase<CreateRelationshipDto, Result<Relationship>> useCase)
{
    [HttpPost]
    public async Task<IActionResult> CreateRelationship(CreateRelationshipRequest createRelationshipRequest)
    {
        var result = await useCase.Execute(new CreateRelationshipDto());

        if (result.IsFailure())
        {
            return new ObjectResult(result.Error)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        var relationship = result.Value;
        var relationshipId = relationship.GetId();

        return new CreatedResult("", new CreateRelationshipResponse(relationshipId))
        {
            StatusCode = StatusCodes.Status201Created
        };
    }
}