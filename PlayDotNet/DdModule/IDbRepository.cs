namespace PlayDotNet.DdModule;

public interface IDbRepository
{
    Task<IEnumerable<int>?> TouchDb();
}