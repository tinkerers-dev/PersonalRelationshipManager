using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Errors;
using PersonalRelationshipManager.Relationships.Domain.Repositories;
using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Application.UseCases;

public class CreateRelationshipUseCase(
    IRelationshipsRepository relationshipsRepository,
    IGuidService guidService)
    : IUseCase<CreateRelationshipDto, Result<Relationship>>
{
    public async Task<Result<Relationship>> Execute(CreateRelationshipDto input)
    {
        var id = guidService.RandomGuid();

        try
        {
            var relationship = new Relationship(id, input.Type, input.Name, input.Nickname, input.Phone, input.Email,
                input.ContactMethods);
            await relationshipsRepository.SaveRelationship(relationship);
            return Result<Relationship>.Ok(relationship);
        } catch (Exception e)
        {
            return Result<Relationship>.Failure(new UnableToCreateRelationshipError(e));
        }
    }
}