using Microsoft.AspNetCore.Mvc;
using PersonalHomePage.Models;
using PersonalHomePage.Services;
using PersonalHomePage.Services.Interfaces;

namespace PersonalHomePage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _moviesService;
        public MoviesController(IMovieService moviesService)
        {
            _moviesService = moviesService; 
        }

        [HttpGet]
        [Route("GetNowPlayingMovies")]
        public async Task<NowPlayingResponseModel> GetNowPlayingMovies()
        {
            return await _moviesService.NowPlaying();
        }

        [HttpGet]
        [Route("Upcoming")]
        public async Task<NowPlayingResponseModel> GetUpcomingMovies() 
        {
            return await _moviesService.Upcoming();
        }
    }
}
