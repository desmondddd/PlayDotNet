using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PlayDotNet.Test;

public abstract class AbstractIntegrationTest
{
    protected readonly HttpClient Client;

    protected AbstractIntegrationTest()
    {
        var webapp = new WebApplicationFactory<Program>();
        Client = webapp.CreateDefaultClient();
    }
}