using System.Text.Json.Serialization;

namespace Api.Extensions.TelegramAuthentication.Models;

public class TelegramAuthData
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("language_code")]
    public string LanguageCode { get; set; }

    [JsonPropertyName("allows_write_to_pm")]
    public bool AllowsWriteToPm { get; set; }

    [JsonPropertyName("photo_url")]
    public string PhotoUrl { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> AdditionalData { get; set; }
}

public class TelegramAuthHeader
{
    public TelegramAuthData User { get; set; }
    public string ChatInstance { get; set; }
    public string ChatType { get; set; }
    public long AuthDate { get; set; }
    public string Signature { get; set; }
    public string Hash { get; set; }
}
