using Microsoft.AspNetCore.Mvc;
using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Http;

[ApiController]
[Route("/relationships")]
public class CreateRelationshipController(IUseCase<CreateRelationshipDto, IResult<Relationship>> useCase)
{

    [HttpPost]
    public async Task CreateRelationship(CreateRelationshipRequest createRelationshipRequest)
    {
        var result = await useCase.Execute(new CreateRelationshipDto());
        
        
    }
}