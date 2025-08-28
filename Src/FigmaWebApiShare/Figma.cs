namespace FigmaWebApi;

public class Figma : JsonService
{
    public Figma(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Figma(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    //protected override string? AuthenticationTestUrl => "v1/me";


    //public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    //{
    //    WebServiceException.ThrowIfNotConnected(client);

    //    var res = await GetFromJsonAsync<HealthModel>("api/health", cancellationToken);
    //    return res?.Version;
    //}

    
    public async Task<User?> GetUserAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<UserModel>("v1/me", cancellationToken);
        return res?.CastTo();
    }
}
