using WebServiceClient.Attributes;

namespace FigmaWebApi.Model;

[CastAttribute("User")]
internal class UserModel
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    [JsonPropertyName("img_url")]
    public string? ImgageUrl { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }
}
