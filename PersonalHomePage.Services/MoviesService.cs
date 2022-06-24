using PersonalHomePage.Services.Interfaces;
using System.Text.Json;
using PersonalHomePage.Models;
using Microsoft.Extensions.Configuration;

namespace PersonalHomePage.Services;

public class MoviesService : IMovieService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;

    private string baseUri = "https://api.themoviedb.org/3/movie/";
    public NowPlayingResponseModel? response { get; set; }

    public MoviesService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
    {
        _httpClientFactory = httpClientFactory;
        _config = configuration;
    }
    public async Task<NowPlayingResponseModel> NowPlaying()
    {
        string path = "now_playing";
        string url = CreateUrl(path);

        var httpClient = _httpClientFactory.CreateClient();

        var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,url);

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            response = await JsonSerializer.DeserializeAsync<NowPlayingResponseModel>(contentStream, options);
        }

        return response;
    }

    public async Task<NowPlayingResponseModel> Upcoming()
    {
        string path = "upcoming";
        string url = CreateUrl(path);

        var httpClient = _httpClientFactory.CreateClient();

        var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get, url);

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            response = await JsonSerializer.DeserializeAsync<NowPlayingResponseModel>(contentStream, options);
        }

        return response;
    }

    private string CreateUrl (string path) 
    {
        string apiKey = _config["Movies:ServiceApiKey"];
        string url = baseUri + path + apiKey;
        return url;
    }
}