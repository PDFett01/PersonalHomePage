using System.Text.Json.Serialization;

namespace PersonalHomePage.Models;

public class NowPlayingResponseModel
{
    public DatesModel? Dates { get; set; }
    public int? Page { get; set; }
    public IEnumerable<NowPlayingModel>? Results { get; set; }
    [JsonPropertyName("total_pages")]
    public int? TotalPages { get; set; }
    [JsonPropertyName("total_results")]
    public int? TotalResults { get; set; }

}
