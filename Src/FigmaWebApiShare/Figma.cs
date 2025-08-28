using System.Xml;
using System.Xml.XPath;

namespace FigmaWebApi;

public class Figma : JsonService
{
    public Figma(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Figma(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    //protected override string? AuthenticationTestUrl => "v1/me";


    public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var relNotes = await GetStringAsync("https://www.figma.com/de-de/release-notes/feed/atom.xml", cancellationToken);

        if (relNotes == null)
            return "0.0.0.0";

        var doc = XDocument.Parse(relNotes);
        //var list = doc.XPathSelectElements("feed/entry/updated").Select(e => e.Value).ToList();

        XNamespace atom = "http://www.w3.org/2005/Atom";

        var nsManager = new XmlNamespaceManager(new NameTable());
        nsManager.AddNamespace("atom", atom.NamespaceName);

        var date = doc.XPathSelectElements("//atom:entry/atom:updated", nsManager).
            Select(u => DateTime.Parse(u.Value, null, System.Globalization.DateTimeStyles.RoundtripKind).Date).Max();

        return $"{date.Year}.{date.Month}.{date.Day}";
    }

    
    public async Task<User?> GetUserAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetFromJsonAsync<UserModel>("v1/me", cancellationToken);
        return res?.CastTo();
    }
}
