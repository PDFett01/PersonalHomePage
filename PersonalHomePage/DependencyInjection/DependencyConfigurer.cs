using PersonalHomePage.Services;
using PersonalHomePage.Services.Interfaces;

namespace PersonalHomePage.DependencyInjection;

public class DependencyConfigurer : IDependencyConfigurer
{
    public void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
    {
        ConfigureDependencies(services, configuration);
    }

    private void ConfigureDependencies(IServiceCollection services, IConfiguration configuration) 
    {
        services.AddTransient<IMovieService, MoviesService>();
    }
}
