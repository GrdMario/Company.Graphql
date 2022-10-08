namespace Company.Graphql.Blocks.Application.Contracts
{
    public interface IDatabaseTransaction
    {
        Guid Id { get; }

        void Commit();

        Task CommitAsync(CancellationToken cancellationToken);
    }
}