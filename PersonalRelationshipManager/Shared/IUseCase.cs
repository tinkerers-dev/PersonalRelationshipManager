namespace PersonalRelationshipManager.Shared;

public interface IUseCase<TInput, TOutput>
{
    Task<TOutput> Execute(TInput input);
}