namespace ModularMonolithShop.Shared.Persistence.Seed;

public interface IDataSeeder
{
    Task SeedAllAsync(CancellationToken cancellationToken);
}