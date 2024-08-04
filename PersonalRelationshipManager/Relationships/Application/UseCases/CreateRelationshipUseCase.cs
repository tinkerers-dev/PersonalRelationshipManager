using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Repositories;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Application.UseCases;

public class CreateRelationshipUseCase(
    IRelationshipRepository relationshipRepository,
    IGuidService guidService)
    : IUseCase<CreateRelationshipDto, Result<Relationship>>
{
    public async Task<Result<Relationship>> Execute(CreateRelationshipDto input)
    {
        var id = guidService.RandomGuid();
        var relationship = new Relationship(id, input.Type, input.Name, input.Nickname, input.Phone, input.Email,
            input.ContactMethods);
        await relationshipRepository.SaveRelationship(relationship);
        return Result<Relationship>.Ok(relationship);
    }
}