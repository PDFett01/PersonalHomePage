using PersonalHomePage.Models;

namespace PersonalHomePage.Services.Interfaces;

public interface IMovieService
{
    Task<NowPlayingResponseModel> NowPlaying();
    Task<NowPlayingResponseModel> Upcoming();
}
