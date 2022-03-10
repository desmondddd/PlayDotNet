using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PlayDotNet.Test;

public abstract class AbstractIntegrationTest
{
    protected readonly HttpClient client;

    protected AbstractIntegrationTest()
    {
        var webapp = new WebApplicationFactory<Program>();
        this.client = webapp.CreateDefaultClient();
    }
}