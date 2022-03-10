namespace PlayDotNet.DdModule;

public class DbService
{
    private readonly IDbRepository _repository;

    public DbService(IDbRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<int>?> GetFromDb(bool yes)
    {
        if (yes)
        {
            return await _repository.TouchDb();
        }
        else
        {
            return null;
        }
    }
}