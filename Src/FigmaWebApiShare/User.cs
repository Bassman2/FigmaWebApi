using WebServiceClient.Attributes;

namespace FigmaWebApi;

[Model]
public class User
{
    public string Id { get; set; } = null!;

    public string? Handle { get; set; }

    public string? ImgageUrl { get; set; }

    public string? Email { get; set; }
}
