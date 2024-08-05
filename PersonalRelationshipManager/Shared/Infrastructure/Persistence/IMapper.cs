namespace PersonalRelationshipManager.Shared.Infrastructure.Persistence;

public interface IMapper<TDomain, TDatabase>
{
    TDatabase ToDatabase(TDomain domain);
    TDomain ToDomain(TDatabase database);
}