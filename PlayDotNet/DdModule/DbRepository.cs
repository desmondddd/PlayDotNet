using System.Collections;

namespace PlayDotNet.DdModule;

public class DbRepository : IDbRepository
{
    public async Task<IEnumerable<int>?> TouchDb()
    {
        return await Task.FromResult(Enumerable.Range(1, 5));
    }
}